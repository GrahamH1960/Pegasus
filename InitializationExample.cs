using System;

// Import the SecsToTool Driver namespace
using Insphere.SecsToTool.Application;
// Import the SecsDataItem namespance
using Insphere.SecsToTool.Common;

/// <summary>
/// Declare a simple delegate to broadcast our message to subscriber.
/// </summary>
public delegate void DelInitializationExample(string message);


/// <summary>
/// This class provides the example for Host to perform Initialization to Equipment upon Establish Communication through S1F13.
/// This example provides user a guide of how to perform initialization using the Asynchronous Daisy Chain approach
/// </summary>
public class InitializationExample
{
	/// <summary>
	/// Declare the SECsHost object
	/// </summary>
	private SECsHost hostController;

	/// <summary>
	/// Declare a Daisy chain context
	/// </summary>
	private const string InitializationChainContext = "Establish Communication Chain";

	/// <summary>
	/// Declare a simple event to broadcast our activity
	/// </summary>
	public event DelInitializationExample MessageIn;

	public event DelInitializationExample MessageError;

	/// <summary>
	/// Constructor instance
	/// </summary>
	public InitializationExample()
	{
		// create an instance of SECsHost object
		
		hostController = SECsFactory.CreateInstance();

		// hook up event sent by the equipment.
		hostController.SECsPrimaryIn += new Insphere.SecsToTool.Application.SECsBase.SECsPrimaryInEventHandler(OnPrimaryIn);

		// hook up reply/acknowledgement sent by the equipment
		hostController.SECsSecondaryIn += new Insphere.SecsToTool.Application.SECsBase.SECsSecondaryInEventHandler(OnSecondaryIn);

		// hook up the error messages from the library
		hostController.SECsHostError += new Insphere.SecsToTool.Application.SECsBase.SECsHostErrorHandler(OnErrorNotification);
	}

	/// <summary>
	/// Start Initialization to the equipment
	/// </summary>
	public void StartInitialization() {
		Logger("Step 1: Initialize the Tool Model");
		hostController.Initialize(AppDomain.CurrentDomain.BaseDirectory + "\\ToolModel1.xml");

		Logger("Step 2: Open HSMS connection port");
		hostController.Connect(); 

		// Now we will wait for the Equipment to acknowledge and notify at the Primary Event
	}

	/// <summary>
	/// Equipment primary event handler
	/// </summary>
	/// <param name="sender">event sender</param>
	/// <param name="e">event parameters</param>
	private void OnPrimaryIn(object sender, SECsPrimaryInEventArgs e) {
		switch (e.EventId) {
			case PrimaryEventType.Connected:	// this signal that we have successfully connected to the equipment
				Logger("Equipment Connected");
				// Use Tag to set the context for our Daisy Chain method
				hostController.Tag = InitializationChainContext;

				Logger("Step 3: Initiate Establish Communication via S1F13 to equipment");
				// Trigger the S1F13 message to equipment. Now note that our establish communication carry a InitializationChain Context
				hostController.EstablishCommunication(); 

				// Wait for the reply from Equipment in Secondary Event
				break;
			case PrimaryEventType.EventReport:
				Logger("Received event: " + e.Inputs.DataItem["Ln"]["CEID"].Value);
				break;

		}
	}

	private void OnSecondaryIn(object sender, SECsSecondaryInEventArgs e) {
		switch (e.EventId) {
			case SecondaryEventType.EstablishCommunicationReply: // S1F14. Replies from S1F13 message 
				// Check if equipment accept our S1F13 request
				if (e.Outputs.DataItem["Ln"]["COMMACK"].Value.ToString()  == "0")  { // 0 means OK
					Logger("Establish Communication accepted");
					// Check if it is a Initialization Chain Context
					if (e.Tag.Equals(InitializationChainContext)) {
						// Continue our initialization

						// Keep setting the Daisy Chain context
						hostController.Tag = InitializationChainContext;

						Logger("Step 4: Synchronous Host current date & time with Equipment");
						hostController.DateTimeSetRequest(); 
					}
				}
				else
					Logger("Establish Communication not accepted. Initialization terminated!");
				break;

			case SecondaryEventType.DateTimeSetReply: // S2F32. Acknowledgement from our DateTimeSetRequest()
				if (e.Outputs.DataItem["TIACK"].Value.ToString() == "0") { // 0 Means OK
					Logger("DateTimeSet acknowledged OK");
					// Check if it is a Initialization Chain Context
					if (e.Tag.Equals(InitializationChainContext)) {
						// Continue our initialization

						// Keep setting the Daisy Chain context
						hostController.Tag = InitializationChainContext;

						Logger("Step 5: Disable all the alarm activation status at Equipment");
						hostController.EnableAlarm(false); 
					}
				}
				break;

			case SecondaryEventType.DisableAlarmReportReply: // S5F4. Acknowledgement from our EnableAlarm(false) - Disable all alarm
				if (e.Outputs.DataItem["ACKC5"].Value.ToString() == "0") {
					Logger("Disable all Alarms accepted by equipment");

					// Check if it is a Initialization Chain Context
					if (e.Tag.Equals(InitializationChainContext)) {
						// Continue our initialization

						// Keep setting the Daisy Chain context
						hostController.Tag = InitializationChainContext;

						Logger("Step 6: Enable all the alarm as defined in our ToolModel1.xml");
						hostController.EnableAlarm(true); 
					}
				}
				else
					Logger("Disable all Alarms not accepted by equipment. Initialization terminated!");

				break;

			case SecondaryEventType.EnableAlarmReportReply: // S5F4. Enable Alarm acknowledgement
				if (e.Outputs.DataItem["ACKC5"].Value.ToString() == "0") {
					Logger("Enable all Alarms accepted by equipment");
					
					// Check if it is a Initialization Chain Context
					if (e.Tag.Equals(InitializationChainContext)) {
						// Continue our initialization

						// Keep setting the Daisy Chain context
						hostController.Tag = InitializationChainContext;

						Logger("Step 7: Delete equipment existing report definition");
						hostController.DefineReports(DefineReportType.DeleteReports);
  
					}
				}
				else
					Logger("Enable Alarms not accepted by equipment. Initialization terminated!");

				break;

			case SecondaryEventType.DeleteAllReportsReply: // S2F34. Delete all reports acknowledgement 
				if (e.Outputs.DataItem["DRACK"].Value.ToString() == "0") {
					Logger("Delete all report accepted");

					// Check if it is a Initialization Chain Context
					if (e.Tag.Equals(InitializationChainContext)) {
						// Continue our initialization

						// Keep setting the Daisy Chain context
						hostController.Tag = InitializationChainContext;

						Logger("Step 8: Define all reports and its associated variables as defined in out ToolModel1.xml");
						hostController.DefineReports(DefineReportType.DefineReports);
  
					}
				}
				else
					Logger("Delete all report not accepted. Initialization terminated!");

				break;

			case SecondaryEventType.DefineReportsReply: // S2F34. Define reports acknowledgement
				if (e.Outputs.DataItem["DRACK"].Value.ToString() == "0") {
					Logger("Define all report accepted");

					// Check if it is a Initialization Chain Context
					if (e.Tag.Equals(InitializationChainContext)) {
						// Continue our initialization

						// Keep setting the Daisy Chain context
						hostController.Tag = InitializationChainContext;

						Logger("Step 9: Unlink equipment event report definition");
						hostController.LinkEventReport(LinkEventReportType.UnlinkEventReports); 
  
					}
				}
				else
					Logger("Define all report not accepted. Initialization terminated!");

				break;

			case SecondaryEventType.UnlinkEventReportsReply: // S2F36 Unlink event report acknowledgement
				if (e.Outputs.DataItem["LRACK"].Value.ToString() == "0") {
					Logger("Unlink event report is accepted");

					// Check if it is a Initialization Chain Context
					if (e.Tag.Equals(InitializationChainContext)) {
						// Continue our initialization

						// Keep setting the Daisy Chain context
						hostController.Tag = InitializationChainContext;

						Logger("Step 10: Link event report definition to equipment as defined in our ToolModel1.xml");
						hostController.LinkEventReport(LinkEventReportType.LinkEventReports); 
  
					}
				}
				else
					Logger("Unlink event report is not accepted. Initialization terminated!");

				break;

			case SecondaryEventType.LinkEventReportsReply: // S2F36 Link event report acknowledgement
				if (e.Outputs.DataItem["LRACK"].Value.ToString() == "0") {
					Logger("Unlink event report is accepted");

					Logger("Daisy Chain Demo completed.");
					
					// This will disconnect our connection to equipment
					hostController.Disconnect();
					Logger("Communication disconnected");
				}
				else
					Logger("Unlink event report is not accepted. Initialization terminated!");

				break;

		}
	}

	private void Logger(string message) {
		if (MessageIn != null) 
			MessageIn(message);
	}

	private void LogError(string message) {
		if (MessageError != null)
			MessageError(message);
	}

	private void OnErrorNotification(object sender, SECsHostErrorEventArgs e) {
		LogError("Error source: " + e.Source + ", Message: " + e.Message);
	}
}
