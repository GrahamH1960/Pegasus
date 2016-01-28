using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Insphere.SecsToTool.QuickStarts
{
	/// <summary>
	/// Summary description for Launcher.
	/// </summary>
	public class Launcher : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listMessage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnInitialization;
		private System.Windows.Forms.Button btnAllStream;
		private System.Windows.Forms.LinkLabel linkClearMessage;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button cmdHandleEvent;
		private System.Windows.Forms.CheckBox isLogMessage;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Launcher()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnInitialization = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAllStream = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.listMessage = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.linkClearMessage = new System.Windows.Forms.LinkLabel();
			this.cmdHandleEvent = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.isLogMessage = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnInitialization
			// 
			this.btnInitialization.Location = new System.Drawing.Point(16, 16);
			this.btnInitialization.Name = "btnInitialization";
			this.btnInitialization.Size = new System.Drawing.Size(232, 64);
			this.btnInitialization.TabIndex = 0;
			this.btnInitialization.Text = "Initialization using Daisy Chain approach";
			this.btnInitialization.Click += new System.EventHandler(this.btnInitialization_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Gainsboro;
			this.label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(264, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(504, 64);
			this.label1.TabIndex = 1;
			this.label1.Text = @"SecsToTool.Net is a asynchronous programming model through socket send/receive,  each reply or acknowledgement sent by equipment will be notified in the Secondary Event. This example demonstrate how to implement a series of Initialization to equipment using Daisy Chain approach.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAllStream
			// 
			this.btnAllStream.Location = new System.Drawing.Point(16, 176);
			this.btnAllStream.Name = "btnAllStream";
			this.btnAllStream.Size = new System.Drawing.Size(232, 64);
			this.btnAllStream.TabIndex = 2;
			this.btnAllStream.Text = "All Streams example references";
			this.btnAllStream.Click += new System.EventHandler(this.btnAllStream_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Gainsboro;
			this.label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(264, 176);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(504, 64);
			this.label2.TabIndex = 3;
			this.label2.Text = "This sample comprises of all Streams and Functions implemented in SecsToTool.Net." +
				"  It does not contained a scenario example as you can find in the previous sampl" +
				"e application but rather it provides a unit testing and handling for all message" +
				"s";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listMessage
			// 
			this.listMessage.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listMessage.ItemHeight = 16;
			this.listMessage.Location = new System.Drawing.Point(16, 344);
			this.listMessage.Name = "listMessage";
			this.listMessage.Size = new System.Drawing.Size(752, 308);
			this.listMessage.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 320);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 24);
			this.label3.TabIndex = 5;
			this.label3.Text = "Message Logger";
			// 
			// linkClearMessage
			// 
			this.linkClearMessage.Location = new System.Drawing.Point(192, 320);
			this.linkClearMessage.Name = "linkClearMessage";
			this.linkClearMessage.Size = new System.Drawing.Size(120, 24);
			this.linkClearMessage.TabIndex = 6;
			this.linkClearMessage.TabStop = true;
			this.linkClearMessage.Text = "Clear Message";
			this.linkClearMessage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearMessage_LinkClicked);
			// 
			// cmdHandleEvent
			// 
			this.cmdHandleEvent.Location = new System.Drawing.Point(16, 96);
			this.cmdHandleEvent.Name = "cmdHandleEvent";
			this.cmdHandleEvent.Size = new System.Drawing.Size(232, 64);
			this.cmdHandleEvent.TabIndex = 7;
			this.cmdHandleEvent.Text = "Handle Event/Alarm sent by Equipment";
			this.cmdHandleEvent.Click += new System.EventHandler(this.cmdHandleEvent_Click);
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Gainsboro;
			this.label4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(264, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(504, 64);
			this.label4.TabIndex = 8;
			this.label4.Text = "This sample shows how you could handle the events/alarms sent by Equipment and tr" +
				"igger the relevant Host command. It also shows how to make use of the MappingVal" +
				"ue of SV/EC/DV so that your code will have a minimum equipment specific definiti" +
				"on. ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// isLogMessage
			// 
			this.isLogMessage.Checked = true;
			this.isLogMessage.CheckState = System.Windows.Forms.CheckState.Checked;
			this.isLogMessage.Location = new System.Drawing.Point(320, 320);
			this.isLogMessage.Name = "isLogMessage";
			this.isLogMessage.Size = new System.Drawing.Size(248, 24);
			this.isLogMessage.TabIndex = 9;
			this.isLogMessage.Text = "Log Message";
			// 
			// Launcher
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(784, 672);
			this.Controls.Add(this.isLogMessage);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmdHandleEvent);
			this.Controls.Add(this.linkClearMessage);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listMessage);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnAllStream);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnInitialization);
			this.Name = "Launcher";
			this.Text = "QuickStart Sample Launcher";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			System.Windows.Forms.Application.Run(new Launcher());
		}

		public void btnInitialization_Click(object sender, System.EventArgs e) {
			InitializationExample initialization = new InitializationExample();
			
			initialization.MessageIn+=new DelInitializationExample(InitializationMessageIn);
			initialization.MessageError += new DelInitializationExample(initialization_MessageError);
			// Start the initialization.
			initialization.StartInitialization();
		}

		private void InitializationMessageIn(string message) {
			if (this.isLogMessage.Checked)
				this.listMessage.Items.Add(message);
		}

		private void linkClearMessage_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			this.listMessage.Items.Clear(); 
		}

		private void btnAllStream_Click(object sender, System.EventArgs e) {
			AllStreamLibrarySample sample = new AllStreamLibrarySample();
			sample.Show();
		}

		private void cmdHandleEvent_Click(object sender, System.EventArgs e) {
			HandlingEquipmentEvent equipmentEventDemo = new HandlingEquipmentEvent();

			equipmentEventDemo.EquipmentEventIn += new DelEquipmentEventSample(OnEquipmentEventIn);

			// This will start the establish communication and wait for S6F11 from equipment
			equipmentEventDemo.StartListeningForEvent();
		}

		private void OnEquipmentEventIn(string message) {
			if (this.isLogMessage.Checked)
				listMessage.Items.Add(message);
		}

		private void initialization_MessageError(string message) {
			listMessage.Items.Add(message);
		}
	}
}
