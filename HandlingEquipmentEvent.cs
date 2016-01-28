using System;

// Import the SecsToTool Driver namespace
using Insphere.SecsToTool.Application;
// Import the SecsDataItem namespance
using Insphere.SecsToTool.Common;

// Declare a simple delegate to broadcast our message to subscriber.
public delegate void DelEquipmentEventSample(string message);

// The purpose of this class is to demonstrate how to handle the event sent by Equipment. The event here refers to the message initiated by Equipment alone and not the reply.
// 
public class HandlingEquipmentEvent
{
	// Declare the SECsHost object
	private SECsHost hostController;

	// Declare a simple event to broadcast the event sent by equipment
	public event DelEquipmentEventSample EquipmentEventIn;

	public HandlingEquipmentEvent()
	{
		// create an instance of SECsHost object
		
		hostController = SECsFactory.CreateInstance();
		
		// hook up event sent by the equipment.
		hostController.SECsPrimaryIn += new Insphere.SecsToTool.Application.SECsBase.SECsPrimaryInEventHandler(hostController_SECsPrimaryIn);

		// hook up reply/acknowledgement sent by the equipment
		hostController.SECsSecondaryIn += new Insphere.SecsToTool.Application.SECsBase.SECsSecondaryInEventHandler(hostController_SECsSecondaryIn);

		// hook up the error messages from the library
		hostController.SECsHostError += new Insphere.SecsToTool.Application.SECsBase.SECsHostErrorHandler(hostController_SECsHostError);
	}

	public void StartListeningForEvent() {
		Logger("Step 1: Initialize the Tool Model");
		hostController.Initialize(AppDomain.CurrentDomain.BaseDirectory + "\\ToolModel1.xml");

		Logger("Step 2: Open HSMS connection port");
		hostController.Connect(); 

		// Now we will wait for the Equipment to acknowledge and notify at the Primary Event
	}

	private void hostController_SECsPrimaryIn(object sender, SECsPrimaryInEventArgs e) {
		switch (e.EventId) {
			case PrimaryEventType.Connected:
				Logger("Equipment Connected");
				
				Logger("Step 3: Initiate Establish Communication via S1F13 to equipment");
				// Trigger the S1F13 message to equipment. Now note that our establish communication carry a InitializationChain Context
				hostController.EstablishCommunication(); 

				// Wait for the reply from Equipment in Secondary Event
				break;

			case PrimaryEventType.EventReport:
				HandleEventReport(e.Inputs);
				break;

			case PrimaryEventType.AlarmSet:
				HandleAlarmReport(e.Inputs);
				break;
 
			case PrimaryEventType.AlarmCleared: 
				// In this demo, assuming we are not interested in the specific alarm clear event, so we just broadcast the alarm event.
				Logger("Alarm: " + e.Inputs.DataItem["Ln"]["ALID"].Value + " is cleared");
				break;

			
		}
	}

	private void HandleEventReport(SECsMessage inputs) {
		string eventName = inputs.DataItem["Ln"]["CEID"].Value.ToString();

		// Note that in SecsToTool.Net all equipment specific Identifier such as CEID, ALID, SVID, etc are hidden to the code level.
		// This will greatly make our code reusable for other type of equipment.
		switch (eventName) {
			case "MaterialArrived":	// CEID=2001 in our ToolModel1.xml
				// Assuming this event is fired when equipment detected a cassette of wafers being placed onto the LoadPort
				// We want to retrieve the MaterialID and ProcessState from the first report attach to this event.
				SECsItem materialReport = inputs.DataItem["Ln"]["Ln"][0]; // We know that in our ToolModel1.xml we only attach 1 report to this event

				// Retrieve the MaterialId value
				string MaterialId = materialReport["Ln"][0].Value.ToString(); 

				// Retrieve the ProcessState, System will automatically find the mapping value as defined in our ToolModel1.xml
				// In case equipment sent some value in which mapping value is not found in the model, the original value will be returned.
				string ProcessState = materialReport["Ln"][1].Value.ToString(); 

				// Now we want to Start the Lot only if the equipment state is in Standby Mode.
				if (ProcessState == "Standby") {

					// Using the QueryHostCommandParameters method to get all its parameters defined in the ToolModel1.xml
					// The system will automatically generate the parameter container with all the necessary format type built
					SECsItem parameters = hostController.QueryHostCommandParameters("Start Lot");
			
					parameters["Lot Id"].Value = "Lot000001";
					
					Logger("Equipment is in Standby mode! Now send Start Lot Host command to equipment");
					// Send Start Lot host command to Equipment
					// Note: System will automatically lookup for the actual PARAM_NAME, HCMD_NAME before sending out the message
					hostController.HostCommand("Start Lot", parameters);

				}
				else {
					// We do not want to start the lot if Process state is not in Standby mode.
					Logger("State: " + ProcessState + ". Equipment is not in standby state. Lot will not be started");
				}

				break;

			case "ProcessCompleted": // CEID=2002 in our ToolModel1.xml
				Logger("Process Completed");
				break;
		}
	} 


	private void HandleAlarmReport(SECsMessage inputs) {
		// retrieve the Alarm Id
		string alarmName = inputs.DataItem["Ln"]["ALID"].Value.ToString();

		// retrieve the Alarm Category
		string alarmCategory = inputs.DataItem["Ln"]["ALCD"].Value.ToString();

		// retrieve the Alarm Description
		string alarmDescription = inputs.DataItem["Ln"]["ALTX"].Value.ToString();
		
		Logger("Alarm occured! Name: " + alarmName + ", Category: " + alarmCategory + ", Description: " + alarmDescription);

		// Let's say we want to monitor a specific alarm occurrence in order to trigger some action
		// The following example shows that when MotionError occurs, Host want to query some status variable's current value.
		switch (alarmName) {
			case "MotionError":
				SECsItem svList = new SECsItem();

				// Add the Status variables that we want to query the value back
				svList.Add("Potential Energy"); // SVID: 201
				svList.Add("FaradayPosition"); // SVID: 203

				Logger("Query Potential Energy and FaradayPosition value");
				// Query equipment status variable's value by the defined svList
				hostController.EquipmentStatusVariables(svList); 

				break;

		}

	}
	private void hostController_SECsSecondaryIn(object sender, SECsSecondaryInEventArgs e) {
		switch (e.EventId) {
			case SecondaryEventType.EstablishCommunicationReply: // S1F14. Replies from S1F13 message 
				// Check if equipment accept our S1F13 request
				if (e.Outputs.DataItem["Ln"]["COMMACK"].Value.ToString()  == "0")  { // 0 means OK
					Logger("Establish Communication accepted");

					Logger("Now wait for event: MaterialArrived (CEID:2001) to be sent by Equipment!!!");
				}
				else
					Logger("Establish Communication not accepted. Initialization terminated!");
				
				break;

			case SecondaryEventType.HostCommandReply: // S2F42. Replies from our HostCommand (S2F41) message.
				if (e.Outputs.DataItem["Ln"]["HACK"].Value.ToString() == "0") {
					Logger("Host command: " + e.Inputs.DataItem["Ln"]["RCMD"].Value.ToString() + " is accepted by equipment");
					Logger("Now we will wait for other event/alarm from equipment...");
				}
				else
					Logger("Host command: " + e.Inputs.DataItem["Ln"]["RCMD"].Value.ToString() + " is not accepted by equipment. HACK: " + e.Outputs.DataItem["Ln"]["HACK"].Value.ToString());
				
				break;

			case SecondaryEventType.EquipmentStatusVariablesReply: // S1F4. Replies from our EquipmentStatusVariables() method
				for (int i=0; i < e.Outputs.DataItem["Ln"].Count; i++) {
					Logger("SV: " +  e.Outputs.DataItem["Ln"][i].Name + ", Value: " +  e.Outputs.DataItem["Ln"][i].Value.ToString());
				}
				
				break;
		}
	}

	private void hostController_SECsHostError(object sender, SECsHostErrorEventArgs e) {
		Logger("Error Source: " + e.Source + ". Message: " + e.Message);
	}

	private void Logger(string message) {
		if (EquipmentEventIn != null) 
			EquipmentEventIn(message);
	}

	
}
