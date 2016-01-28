using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

using Insphere.SecsToTool.Application;  
using Insphere.SecsToTool.Common;

namespace Insphere.SecsToTool.QuickStarts
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class AllStreamLibrarySample : System.Windows.Forms.Form
	{
		#region Windows UI Variables

		private System.Windows.Forms.Button cmdConnect;
		private System.Windows.Forms.Button cmdDisconnect;
		private System.Windows.Forms.Button cmdEstComm;
		private System.Windows.Forms.Button cmdAreYouThere;
		private System.Windows.Forms.Button cmdOffline;
		private System.Windows.Forms.Button cmdOnline;
		private System.Windows.Forms.Button cmdNewEC;
		private System.Windows.Forms.Button cmdDateTimeReq;
		private System.Windows.Forms.Button cmdRemoteCommand;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button cmdSVRequest1;
		private System.Windows.Forms.Button cmdSVRequest2;
		private System.Windows.Forms.Button cmdSVNamelist1;
		private System.Windows.Forms.Button cmdSVNamelist2;
		private System.Windows.Forms.Button cmdECQuery1;
		private System.Windows.Forms.Button cmdECQuery2;
		private System.Windows.Forms.Button cmdECNamelist1;
		private System.Windows.Forms.Button cmdECNamelist2;
		private System.Windows.Forms.Button cmdDTSet;
		private System.Windows.Forms.Button cmdEnableEvent1;
		private System.Windows.Forms.Button cmdDisableEvent;
		private System.Windows.Forms.Button cmdHostCommand;
		private System.Windows.Forms.Button cmdDeleteReports;
		private System.Windows.Forms.Button cmdDefineReport;
		private System.Windows.Forms.Button cmdUnlinkEventReport;
		private System.Windows.Forms.Button cmdLinkEventReport;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button cmdEnableAllAlarm;
		private System.Windows.Forms.Button cmdEnableAlarm;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button cmdEventReportRequest;
		private System.Windows.Forms.Button cmdListAlarm;
		private System.Windows.Forms.Button cmdListEnabledAlarm;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		
		#region Application Local Variables
		
		private SECsHost secsHost;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Button cmdPPSend;
		private System.Windows.Forms.Button cmdPPRequest;
		private System.Windows.Forms.Button cmdDeletePP;
		private System.Windows.Forms.Button cmdCurrentEPPD;
		private System.Windows.Forms.LinkLabel linkClearMessage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox listMessage;
		private bool isConnected;

		#endregion

		#region Constructor & Destructor
		public AllStreamLibrarySample()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion
		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmdConnect = new System.Windows.Forms.Button();
			this.cmdDisconnect = new System.Windows.Forms.Button();
			this.cmdEstComm = new System.Windows.Forms.Button();
			this.cmdAreYouThere = new System.Windows.Forms.Button();
			this.cmdOffline = new System.Windows.Forms.Button();
			this.cmdOnline = new System.Windows.Forms.Button();
			this.cmdNewEC = new System.Windows.Forms.Button();
			this.cmdDateTimeReq = new System.Windows.Forms.Button();
			this.cmdRemoteCommand = new System.Windows.Forms.Button();
			this.cmdSVRequest1 = new System.Windows.Forms.Button();
			this.cmdSVNamelist1 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cmdSVNamelist2 = new System.Windows.Forms.Button();
			this.cmdSVRequest2 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.cmdListEnabledAlarm = new System.Windows.Forms.Button();
			this.cmdListAlarm = new System.Windows.Forms.Button();
			this.cmdEnableAlarm = new System.Windows.Forms.Button();
			this.cmdEnableAllAlarm = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.cmdLinkEventReport = new System.Windows.Forms.Button();
			this.cmdUnlinkEventReport = new System.Windows.Forms.Button();
			this.cmdDefineReport = new System.Windows.Forms.Button();
			this.cmdDeleteReports = new System.Windows.Forms.Button();
			this.cmdHostCommand = new System.Windows.Forms.Button();
			this.cmdDisableEvent = new System.Windows.Forms.Button();
			this.cmdEnableEvent1 = new System.Windows.Forms.Button();
			this.cmdDTSet = new System.Windows.Forms.Button();
			this.cmdECNamelist2 = new System.Windows.Forms.Button();
			this.cmdECNamelist1 = new System.Windows.Forms.Button();
			this.cmdECQuery2 = new System.Windows.Forms.Button();
			this.cmdECQuery1 = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.cmdEventReportRequest = new System.Windows.Forms.Button();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.cmdCurrentEPPD = new System.Windows.Forms.Button();
			this.cmdDeletePP = new System.Windows.Forms.Button();
			this.cmdPPRequest = new System.Windows.Forms.Button();
			this.cmdPPSend = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.linkClearMessage = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.listMessage = new System.Windows.Forms.ListBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmdConnect
			// 
			this.cmdConnect.Location = new System.Drawing.Point(8, 16);
			this.cmdConnect.Name = "cmdConnect";
			this.cmdConnect.Size = new System.Drawing.Size(120, 27);
			this.cmdConnect.TabIndex = 9;
			this.cmdConnect.Text = "Connect";
			this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
			// 
			// cmdDisconnect
			// 
			this.cmdDisconnect.Location = new System.Drawing.Point(136, 16);
			this.cmdDisconnect.Name = "cmdDisconnect";
			this.cmdDisconnect.Size = new System.Drawing.Size(90, 27);
			this.cmdDisconnect.TabIndex = 12;
			this.cmdDisconnect.Text = "Disconnect";
			this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
			// 
			// cmdEstComm
			// 
			this.cmdEstComm.Location = new System.Drawing.Point(488, 16);
			this.cmdEstComm.Name = "cmdEstComm";
			this.cmdEstComm.Size = new System.Drawing.Size(90, 27);
			this.cmdEstComm.TabIndex = 13;
			this.cmdEstComm.Text = "S1F13";
			this.cmdEstComm.Click += new System.EventHandler(this.cmdEstComm_Click);
			// 
			// cmdAreYouThere
			// 
			this.cmdAreYouThere.Location = new System.Drawing.Point(8, 16);
			this.cmdAreYouThere.Name = "cmdAreYouThere";
			this.cmdAreYouThere.Size = new System.Drawing.Size(90, 26);
			this.cmdAreYouThere.TabIndex = 14;
			this.cmdAreYouThere.Text = "S1F1";
			this.cmdAreYouThere.Click += new System.EventHandler(this.cmdAreYouThere_Click);
			// 
			// cmdOffline
			// 
			this.cmdOffline.Location = new System.Drawing.Point(584, 16);
			this.cmdOffline.Name = "cmdOffline";
			this.cmdOffline.Size = new System.Drawing.Size(90, 26);
			this.cmdOffline.TabIndex = 15;
			this.cmdOffline.Text = "S1F15";
			this.cmdOffline.Click += new System.EventHandler(this.cmdOffline_Click);
			// 
			// cmdOnline
			// 
			this.cmdOnline.Location = new System.Drawing.Point(680, 16);
			this.cmdOnline.Name = "cmdOnline";
			this.cmdOnline.Size = new System.Drawing.Size(90, 27);
			this.cmdOnline.TabIndex = 16;
			this.cmdOnline.Text = "S1F17";
			this.cmdOnline.Click += new System.EventHandler(this.cmdOnline_Click);
			// 
			// cmdNewEC
			// 
			this.cmdNewEC.Location = new System.Drawing.Point(200, 16);
			this.cmdNewEC.Name = "cmdNewEC";
			this.cmdNewEC.Size = new System.Drawing.Size(90, 27);
			this.cmdNewEC.TabIndex = 19;
			this.cmdNewEC.Text = "S2F15";
			this.cmdNewEC.Click += new System.EventHandler(this.cmdNewEC_Click);
			// 
			// cmdDateTimeReq
			// 
			this.cmdDateTimeReq.Location = new System.Drawing.Point(296, 16);
			this.cmdDateTimeReq.Name = "cmdDateTimeReq";
			this.cmdDateTimeReq.Size = new System.Drawing.Size(90, 26);
			this.cmdDateTimeReq.TabIndex = 20;
			this.cmdDateTimeReq.Text = "S2F17";
			this.cmdDateTimeReq.Click += new System.EventHandler(this.cmdDateTimeReq_Click);
			// 
			// cmdRemoteCommand
			// 
			this.cmdRemoteCommand.Location = new System.Drawing.Point(392, 16);
			this.cmdRemoteCommand.Name = "cmdRemoteCommand";
			this.cmdRemoteCommand.Size = new System.Drawing.Size(90, 26);
			this.cmdRemoteCommand.TabIndex = 23;
			this.cmdRemoteCommand.Text = "S2F21";
			this.cmdRemoteCommand.Click += new System.EventHandler(this.cmdRemoteCommand_Click);
			// 
			// cmdSVRequest1
			// 
			this.cmdSVRequest1.Location = new System.Drawing.Point(104, 16);
			this.cmdSVRequest1.Name = "cmdSVRequest1";
			this.cmdSVRequest1.Size = new System.Drawing.Size(90, 26);
			this.cmdSVRequest1.TabIndex = 24;
			this.cmdSVRequest1.Text = "S1F3 (1)";
			this.cmdSVRequest1.Click += new System.EventHandler(this.cmdSVRequest1_Click);
			// 
			// cmdSVNamelist1
			// 
			this.cmdSVNamelist1.Location = new System.Drawing.Point(296, 16);
			this.cmdSVNamelist1.Name = "cmdSVNamelist1";
			this.cmdSVNamelist1.Size = new System.Drawing.Size(90, 26);
			this.cmdSVNamelist1.TabIndex = 25;
			this.cmdSVNamelist1.Text = "S1F11 (1)";
			this.cmdSVNamelist1.Click += new System.EventHandler(this.cmdSVNamelist1_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Location = new System.Drawing.Point(8, 72);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(784, 120);
			this.tabControl1.TabIndex = 26;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cmdSVNamelist2);
			this.tabPage1.Controls.Add(this.cmdSVRequest2);
			this.tabPage1.Controls.Add(this.cmdAreYouThere);
			this.tabPage1.Controls.Add(this.cmdEstComm);
			this.tabPage1.Controls.Add(this.cmdSVRequest1);
			this.tabPage1.Controls.Add(this.cmdSVNamelist1);
			this.tabPage1.Controls.Add(this.cmdOffline);
			this.tabPage1.Controls.Add(this.cmdOnline);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(776, 91);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Stream 1";
			// 
			// cmdSVNamelist2
			// 
			this.cmdSVNamelist2.Location = new System.Drawing.Point(392, 16);
			this.cmdSVNamelist2.Name = "cmdSVNamelist2";
			this.cmdSVNamelist2.Size = new System.Drawing.Size(90, 26);
			this.cmdSVNamelist2.TabIndex = 26;
			this.cmdSVNamelist2.Text = "S1F11 (2)";
			this.cmdSVNamelist2.Click += new System.EventHandler(this.cmdSVNamelist2_Click);
			// 
			// cmdSVRequest2
			// 
			this.cmdSVRequest2.Location = new System.Drawing.Point(200, 16);
			this.cmdSVRequest2.Name = "cmdSVRequest2";
			this.cmdSVRequest2.Size = new System.Drawing.Size(90, 26);
			this.cmdSVRequest2.TabIndex = 25;
			this.cmdSVRequest2.Text = "S1F3 (2)";
			this.cmdSVRequest2.Click += new System.EventHandler(this.cmdSVRequest2_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.cmdListEnabledAlarm);
			this.tabPage3.Controls.Add(this.cmdListAlarm);
			this.tabPage3.Controls.Add(this.cmdEnableAlarm);
			this.tabPage3.Controls.Add(this.cmdEnableAllAlarm);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(776, 91);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Stream 5";
			// 
			// cmdListEnabledAlarm
			// 
			this.cmdListEnabledAlarm.Location = new System.Drawing.Point(296, 8);
			this.cmdListEnabledAlarm.Name = "cmdListEnabledAlarm";
			this.cmdListEnabledAlarm.Size = new System.Drawing.Size(90, 26);
			this.cmdListEnabledAlarm.TabIndex = 28;
			this.cmdListEnabledAlarm.Text = "S5F7";
			this.cmdListEnabledAlarm.Click += new System.EventHandler(this.cmdListEnabledAlarm_Click);
			// 
			// cmdListAlarm
			// 
			this.cmdListAlarm.Location = new System.Drawing.Point(200, 8);
			this.cmdListAlarm.Name = "cmdListAlarm";
			this.cmdListAlarm.Size = new System.Drawing.Size(90, 26);
			this.cmdListAlarm.TabIndex = 27;
			this.cmdListAlarm.Text = "S5F5";
			this.cmdListAlarm.Click += new System.EventHandler(this.cmdListAlarm_Click);
			// 
			// cmdEnableAlarm
			// 
			this.cmdEnableAlarm.Location = new System.Drawing.Point(104, 8);
			this.cmdEnableAlarm.Name = "cmdEnableAlarm";
			this.cmdEnableAlarm.Size = new System.Drawing.Size(90, 26);
			this.cmdEnableAlarm.TabIndex = 26;
			this.cmdEnableAlarm.Text = "S5F3 (2)";
			this.cmdEnableAlarm.Click += new System.EventHandler(this.cmdEnableAlarm_Click);
			// 
			// cmdEnableAllAlarm
			// 
			this.cmdEnableAllAlarm.Location = new System.Drawing.Point(8, 8);
			this.cmdEnableAllAlarm.Name = "cmdEnableAllAlarm";
			this.cmdEnableAllAlarm.Size = new System.Drawing.Size(90, 26);
			this.cmdEnableAllAlarm.TabIndex = 25;
			this.cmdEnableAllAlarm.Text = "S5F3 (1)";
			this.cmdEnableAllAlarm.Click += new System.EventHandler(this.cmdEnableAllAlarm_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.cmdLinkEventReport);
			this.tabPage2.Controls.Add(this.cmdUnlinkEventReport);
			this.tabPage2.Controls.Add(this.cmdDefineReport);
			this.tabPage2.Controls.Add(this.cmdDeleteReports);
			this.tabPage2.Controls.Add(this.cmdHostCommand);
			this.tabPage2.Controls.Add(this.cmdDisableEvent);
			this.tabPage2.Controls.Add(this.cmdEnableEvent1);
			this.tabPage2.Controls.Add(this.cmdDTSet);
			this.tabPage2.Controls.Add(this.cmdECNamelist2);
			this.tabPage2.Controls.Add(this.cmdECNamelist1);
			this.tabPage2.Controls.Add(this.cmdECQuery2);
			this.tabPage2.Controls.Add(this.cmdECQuery1);
			this.tabPage2.Controls.Add(this.cmdNewEC);
			this.tabPage2.Controls.Add(this.cmdDateTimeReq);
			this.tabPage2.Controls.Add(this.cmdRemoteCommand);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(776, 91);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Stream 2";
			// 
			// cmdLinkEventReport
			// 
			this.cmdLinkEventReport.Location = new System.Drawing.Point(296, 48);
			this.cmdLinkEventReport.Name = "cmdLinkEventReport";
			this.cmdLinkEventReport.Size = new System.Drawing.Size(90, 26);
			this.cmdLinkEventReport.TabIndex = 35;
			this.cmdLinkEventReport.Text = "S2F35 (2)";
			this.cmdLinkEventReport.Click += new System.EventHandler(this.cmdLinkEventReport_Click);
			// 
			// cmdUnlinkEventReport
			// 
			this.cmdUnlinkEventReport.Location = new System.Drawing.Point(200, 48);
			this.cmdUnlinkEventReport.Name = "cmdUnlinkEventReport";
			this.cmdUnlinkEventReport.Size = new System.Drawing.Size(90, 26);
			this.cmdUnlinkEventReport.TabIndex = 34;
			this.cmdUnlinkEventReport.Text = "S2F35 (1)";
			this.cmdUnlinkEventReport.Click += new System.EventHandler(this.cmdUnlinkEventReport_Click);
			// 
			// cmdDefineReport
			// 
			this.cmdDefineReport.Location = new System.Drawing.Point(104, 48);
			this.cmdDefineReport.Name = "cmdDefineReport";
			this.cmdDefineReport.Size = new System.Drawing.Size(90, 26);
			this.cmdDefineReport.TabIndex = 33;
			this.cmdDefineReport.Text = "S2F33 (2)";
			this.cmdDefineReport.Click += new System.EventHandler(this.cmdDefineReport_Click);
			// 
			// cmdDeleteReports
			// 
			this.cmdDeleteReports.Location = new System.Drawing.Point(8, 48);
			this.cmdDeleteReports.Name = "cmdDeleteReports";
			this.cmdDeleteReports.Size = new System.Drawing.Size(90, 26);
			this.cmdDeleteReports.TabIndex = 32;
			this.cmdDeleteReports.Text = "S2F33 (1)";
			this.cmdDeleteReports.Click += new System.EventHandler(this.cmdDeleteReports_Click);
			// 
			// cmdHostCommand
			// 
			this.cmdHostCommand.Location = new System.Drawing.Point(584, 48);
			this.cmdHostCommand.Name = "cmdHostCommand";
			this.cmdHostCommand.Size = new System.Drawing.Size(90, 26);
			this.cmdHostCommand.TabIndex = 31;
			this.cmdHostCommand.Text = "S2F41";
			this.cmdHostCommand.Click += new System.EventHandler(this.cmdHostCommand_Click);
			// 
			// cmdDisableEvent
			// 
			this.cmdDisableEvent.Location = new System.Drawing.Point(488, 48);
			this.cmdDisableEvent.Name = "cmdDisableEvent";
			this.cmdDisableEvent.Size = new System.Drawing.Size(90, 26);
			this.cmdDisableEvent.TabIndex = 30;
			this.cmdDisableEvent.Text = "S2F37 (2)";
			this.cmdDisableEvent.Click += new System.EventHandler(this.cmdDisableEvent_Click);
			// 
			// cmdEnableEvent1
			// 
			this.cmdEnableEvent1.Location = new System.Drawing.Point(392, 48);
			this.cmdEnableEvent1.Name = "cmdEnableEvent1";
			this.cmdEnableEvent1.Size = new System.Drawing.Size(90, 26);
			this.cmdEnableEvent1.TabIndex = 29;
			this.cmdEnableEvent1.Text = "S2F37 (1)";
			this.cmdEnableEvent1.Click += new System.EventHandler(this.cmdEnableEvent1_Click);
			// 
			// cmdDTSet
			// 
			this.cmdDTSet.Location = new System.Drawing.Point(680, 16);
			this.cmdDTSet.Name = "cmdDTSet";
			this.cmdDTSet.Size = new System.Drawing.Size(90, 26);
			this.cmdDTSet.TabIndex = 28;
			this.cmdDTSet.Text = "S2F31";
			this.cmdDTSet.Click += new System.EventHandler(this.cmdDTSet_Click);
			// 
			// cmdECNamelist2
			// 
			this.cmdECNamelist2.Location = new System.Drawing.Point(584, 16);
			this.cmdECNamelist2.Name = "cmdECNamelist2";
			this.cmdECNamelist2.Size = new System.Drawing.Size(90, 26);
			this.cmdECNamelist2.TabIndex = 27;
			this.cmdECNamelist2.Text = "S2F29 (2)";
			this.cmdECNamelist2.Click += new System.EventHandler(this.cmdECNamelist2_Click);
			// 
			// cmdECNamelist1
			// 
			this.cmdECNamelist1.Location = new System.Drawing.Point(488, 16);
			this.cmdECNamelist1.Name = "cmdECNamelist1";
			this.cmdECNamelist1.Size = new System.Drawing.Size(90, 26);
			this.cmdECNamelist1.TabIndex = 26;
			this.cmdECNamelist1.Text = "S2F29 (1)";
			this.cmdECNamelist1.Click += new System.EventHandler(this.cmdECNamelist1_Click);
			// 
			// cmdECQuery2
			// 
			this.cmdECQuery2.Location = new System.Drawing.Point(104, 16);
			this.cmdECQuery2.Name = "cmdECQuery2";
			this.cmdECQuery2.Size = new System.Drawing.Size(90, 26);
			this.cmdECQuery2.TabIndex = 25;
			this.cmdECQuery2.Text = "S2F13 (2)";
			this.cmdECQuery2.Click += new System.EventHandler(this.cmdECQuery2_Click);
			// 
			// cmdECQuery1
			// 
			this.cmdECQuery1.Location = new System.Drawing.Point(8, 16);
			this.cmdECQuery1.Name = "cmdECQuery1";
			this.cmdECQuery1.Size = new System.Drawing.Size(90, 26);
			this.cmdECQuery1.TabIndex = 24;
			this.cmdECQuery1.Text = "S2F13 (1)";
			this.cmdECQuery1.Click += new System.EventHandler(this.cmdECQuery1_Click);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.cmdEventReportRequest);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(776, 91);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Stream 6";
			// 
			// cmdEventReportRequest
			// 
			this.cmdEventReportRequest.Location = new System.Drawing.Point(8, 8);
			this.cmdEventReportRequest.Name = "cmdEventReportRequest";
			this.cmdEventReportRequest.Size = new System.Drawing.Size(90, 26);
			this.cmdEventReportRequest.TabIndex = 26;
			this.cmdEventReportRequest.Text = "S6F15";
			this.cmdEventReportRequest.Click += new System.EventHandler(this.cmdEventReportRequest_Click);
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.cmdCurrentEPPD);
			this.tabPage5.Controls.Add(this.cmdDeletePP);
			this.tabPage5.Controls.Add(this.cmdPPRequest);
			this.tabPage5.Controls.Add(this.cmdPPSend);
			this.tabPage5.Location = new System.Drawing.Point(4, 25);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(776, 91);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Stream 7";
			// 
			// cmdCurrentEPPD
			// 
			this.cmdCurrentEPPD.Location = new System.Drawing.Point(296, 8);
			this.cmdCurrentEPPD.Name = "cmdCurrentEPPD";
			this.cmdCurrentEPPD.Size = new System.Drawing.Size(90, 26);
			this.cmdCurrentEPPD.TabIndex = 30;
			this.cmdCurrentEPPD.Text = "S7F19";
			this.cmdCurrentEPPD.Click += new System.EventHandler(this.cmdCurrentEPPD_Click);
			// 
			// cmdDeletePP
			// 
			this.cmdDeletePP.Location = new System.Drawing.Point(200, 8);
			this.cmdDeletePP.Name = "cmdDeletePP";
			this.cmdDeletePP.Size = new System.Drawing.Size(90, 26);
			this.cmdDeletePP.TabIndex = 29;
			this.cmdDeletePP.Text = "S7F17";
			this.cmdDeletePP.Click += new System.EventHandler(this.cmdDeletePP_Click);
			// 
			// cmdPPRequest
			// 
			this.cmdPPRequest.Location = new System.Drawing.Point(104, 8);
			this.cmdPPRequest.Name = "cmdPPRequest";
			this.cmdPPRequest.Size = new System.Drawing.Size(90, 26);
			this.cmdPPRequest.TabIndex = 28;
			this.cmdPPRequest.Text = "S7F5";
			this.cmdPPRequest.Click += new System.EventHandler(this.cmdPPRequest_Click);
			// 
			// cmdPPSend
			// 
			this.cmdPPSend.Location = new System.Drawing.Point(8, 8);
			this.cmdPPSend.Name = "cmdPPSend";
			this.cmdPPSend.Size = new System.Drawing.Size(90, 26);
			this.cmdPPSend.TabIndex = 27;
			this.cmdPPSend.Text = "S7F3";
			this.cmdPPSend.Click += new System.EventHandler(this.cmdPPSend_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdConnect);
			this.groupBox1.Controls.Add(this.cmdDisconnect);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(784, 56);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			// 
			// linkClearMessage
			// 
			this.linkClearMessage.Location = new System.Drawing.Point(184, 200);
			this.linkClearMessage.Name = "linkClearMessage";
			this.linkClearMessage.Size = new System.Drawing.Size(120, 24);
			this.linkClearMessage.TabIndex = 30;
			this.linkClearMessage.TabStop = true;
			this.linkClearMessage.Text = "Clear Message";
			this.linkClearMessage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClearMessage_LinkClicked);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 200);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 24);
			this.label3.TabIndex = 29;
			this.label3.Text = "Message Logger";
			// 
			// listMessage
			// 
			this.listMessage.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listMessage.ItemHeight = 16;
			this.listMessage.Location = new System.Drawing.Point(8, 224);
			this.listMessage.Name = "listMessage";
			this.listMessage.Size = new System.Drawing.Size(784, 308);
			this.listMessage.TabIndex = 28;
			// 
			// AllStreamLibrarySample
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(800, 544);
			this.Controls.Add(this.linkClearMessage);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listMessage);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tabControl1);
			this.Name = "AllStreamLibrarySample";
			this.Text = "All Stream Library Sample";
			this.Load += new System.EventHandler(this.AllStreamLibrarySample_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Common & Initialization
		
		private void cmdConnect_Click(object sender, System.EventArgs e) {
			secsHost.Connect(); 
		}

		private void cmdDisconnect_Click(object sender, System.EventArgs e) {
			secsHost.Disconnect();
		}

		private void Logger(string message) {
			listMessage.Items.Add(message);
		}
		#endregion

		#region SecsHost Event Handler
		private void secsHost_SECsPrimaryIn(object sender, SECsPrimaryInEventArgs e) {
			switch(e.EventId) {
				case PrimaryEventType.Connected:
					this.Text = "All Stream Library Sample (Connected)";
					isConnected = true;
					break;

				case PrimaryEventType.Disconnected:
					this.Text = "All Stream Library Sample (Disconnected)";
					isConnected = false;
					break;

				case PrimaryEventType.EventReport:
					HandleEventReport(e.Inputs);
					break;

				case PrimaryEventType.AlarmSet:
					HandleAlarmSet(e.Inputs);
					break;

				case PrimaryEventType.AlarmCleared:
					HandleAlarmClear(e.Inputs);
					break;
				
			}
		}
		
		private void secsHost_SECsSecondaryIn(object sender, SECsSecondaryInEventArgs e) {
			switch (e.EventId) {
				#region Steam 1 Handler
				case SecondaryEventType.AreYouThereReply: //S1F1 Reply
					HandleAreYouThereReply(e.Outputs);
					break;

				case SecondaryEventType.EquipmentStatusVariablesReply:	//S1F3 Reply
					HandleEquipmentSVReply(e.Outputs);
					break;

				case SecondaryEventType.EquipmentStatusVariableNamelistReply: //S1F11 Reply
					HandleEquipmentSVNamelistReply(e.Outputs);
					break;

				case SecondaryEventType.EstablishCommunicationReply: //S1F13 Reply
					HandleEstablishCommunicationReply(e.Outputs);
					break;
				
				case SecondaryEventType.RequestOfflineReply: //S1F15 Reply
					HandleEquipmentOffineReply(e.Outputs);
					break;

				case SecondaryEventType.RequestOnlineReply: //S1F17 Reply
					HandleEquipmentOnlineReply(e.Outputs);
					break;
					#endregion

				#region Stream 2 Handler
				case SecondaryEventType.EquipmentConstantListReply: // S2F13 Reply
					HandleEqupmentConstantListReply(e.Outputs);
					break;
				
				case SecondaryEventType.NewEquipmentConstantReply: // S2F15 Reply
					HandleEquipmentConstantUpdateReply(e.Outputs);
					break;

				case SecondaryEventType.DateTimeReply: // S2F17 Reply
					HandleEquipmentDateTimeReply(e.Outputs);
					break;

				case SecondaryEventType.RemoteCommandReply: // S2F21 Reply
					HandleRemoteCommandReply(e.Outputs);
					break;
				
				case SecondaryEventType.EquipmentConstantNamelistReply:	// S2F29 Reply
					HandleEquipmentECNamelistReply(e.Outputs);
					break;
				
				case SecondaryEventType.DateTimeSetReply: // S2F31 Reply
					HandleDateTimeSetReply(e.Outputs);
					break;

				case SecondaryEventType.DeleteAllReportsReply:	// S2F33 Reply
					HandleDeleteAllReportReply(e.Outputs);
					break;

				case SecondaryEventType.DefineReportsReply:	// S2F33 Reply
					HandleDefineAllReportReply(e.Outputs);
					break;

				case SecondaryEventType.UnlinkEventReportsReply:	// S2F35 Reply
					HandleUnlinkEventReportReply(e.Outputs);
					break;

				case SecondaryEventType.LinkEventReportsReply:	// S2F35 Reply
					HandleLinkEventReportReply(e.Outputs);
					break;

				case SecondaryEventType.EnableEventReportReply: // S2F37 Reply Enable
					HandleEnableEventReportReply(e.Outputs);
					break;

				case SecondaryEventType.DisableEventReportReply: // S2F37 Reply Disable
					HandleDisableEventReportReply(e.Outputs);
					break;

				case SecondaryEventType.HostCommandReply:	// S2F41 Reply
					HandleHostCommandReply(e.Outputs);
					break;
				
				 
				#endregion

				#region Stream 5 Handler
				case SecondaryEventType.EnableAlarmReportReply:		// S5F3 Reply
					HandleEnableAlarmReportReply(e.Outputs);
					break;

				case SecondaryEventType.DisableAlarmReportReply:	// S5F3 Reply
					HandleDisableAlarmReportReply(e.Outputs);
					break;

				case SecondaryEventType.ListAlarmsReply:	// S5F5 Reply
					HandleListAlarmsReply(e.Outputs);
					break;

				case SecondaryEventType.ListEnabledAlarmsReply:		// S5F7 Reply
					HandleListEnabledAlarmReply(e.Outputs);
					break;

				#endregion

				#region Stream 6 Handler
				case SecondaryEventType.EventReportReply:		// S6F15 Reply
					HandleEventReportReply(e.Outputs);
					break;

				#endregion

				case SecondaryEventType.ProcessProgramSendReply:	// S7F3 Reply
					Logger("Process Program Send Ack: " + e.Outputs.DataItem["ACKC7"].Value.ToString());
					break;
				
				case SecondaryEventType.ProcessProgramDataReply:	// S7F5 Reply
					HandleProcessProgramDataReply(e.Outputs);
					break;

				case SecondaryEventType.ProcessProgramDeleteAck:	// S7F18 Ack
					Logger("Process Program Delete Ack: " + e.Outputs.DataItem["ACKC7"].Value.ToString()); 
					break;

				case SecondaryEventType.CurrentEPPDReply:	// S7F20 Reply
					HandleCurrentEPPDReply(e.Outputs);
					break;
			}
		}

		private void secsHost_SECsHostError(object sender, SECsHostErrorEventArgs e) {
			Logger(e.Message);
		}

		#endregion

		#region Stream 1 Command Button
		/// <summary>
		/// S1F1 Are You There
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdAreYouThere_Click(object sender, System.EventArgs e) {
			secsHost.Tag = "Establish Communication";
			secsHost.AreYouThere(); 
		}

		/// <summary>
		/// S1F3 Query All SVs
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdSVRequest1_Click(object sender, System.EventArgs e) {
			secsHost.EquipmentStatusVariables();
		}

		/// <summary>
		/// S1F3 Query specified SVs
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdSVRequest2_Click(object sender, System.EventArgs e) {
			SECsItem svList = new SECsItem();
			svList.Add("ProcessState");
			
			secsHost.EquipmentStatusVariables(svList);
		}

		/// <summary>
		/// S1F11 Select all SV Namelist
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdSVNamelist1_Click(object sender, System.EventArgs e) {
			secsHost.EquipmentStatusVariableNamelist(); 
		}

		/// <summary>
		/// S1F11 Select specified SVs Namelist
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdSVNamelist2_Click(object sender, System.EventArgs e) {
			SECsItem svList = new SECsItem();
			svList.Add("ControlState");
			secsHost.EquipmentStatusVariableNamelist(svList); 
			
		}

		/// <summary>
		/// S1F13 Establish Communication
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdEstComm_Click(object sender, System.EventArgs e) {
			secsHost.EstablishCommunication(); 
		}

		/// <summary>
		/// S1F15
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdOffline_Click(object sender, System.EventArgs e) {
			secsHost.RequestOffline();
		}

		/// <summary>
		/// S1F17
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdOnline_Click(object sender, System.EventArgs e) {
			secsHost.RequestOnline(); 
		}
		#endregion

		#region Stream 1 Secondary Reply Handler
		/// <summary>
		/// Handle S1F1 reply from equipment
		/// </summary>
		/// <param name="output">
		///		- MDLN
		///		- SOFTREV
		/// </param>
		private void HandleAreYouThereReply(SECsMessage output) {
			StringBuilder msgOutput = new StringBuilder();
			// Retrieve the value of MDLN
			msgOutput.Append("MDLN: " + output.DataItem["Ln"]["MDLN"].Value + "\n");
			// Retrieve the value of SOFTREV
			msgOutput.Append("SOFTREV: " + output.DataItem["Ln"]["SOFTREV"].Value + "\n");
			
			Logger(msgOutput.ToString());
		}

		/// <summary>
		/// Handle S1F3 (Equipment status variable value) reply from equipment
		/// </summary>
		/// <param name="output">List the current value of the selected SVs pre-defined in the equipment</param>
		private void HandleEquipmentSVReply(SECsMessage output) {
			StringBuilder msgOutput = new StringBuilder();
			
			// Retrieve all the SV's value
			for (int i=0; i<output.DataItem["Ln"].Count; i++) {
				if (output.DataItem["Ln"][i].Value.ToString()  != SECsHost.SECsNull)
					msgOutput.Append(output.DataItem["Ln"][i].Name + ": " + output.DataItem["Ln"][i].Value + "\n"); 
				else
					msgOutput.Append(output.DataItem["Ln"][i].Name + ": " + "Does not exist" + "\n"); 
			}
			Logger(msgOutput.ToString());
		}

		/// <summary>
		/// Handle S1F11 (Equipment status variable namelist value) reply from equipment
		/// </summary>
		/// <param name="output"></param>
		private void HandleEquipmentSVNamelistReply(SECsMessage output) {
			StringBuilder msgOutput = new StringBuilder();
			
			// Retrieve all the SV's namelist value
			for (int i=0; i<output.DataItem["Ln"].Count; i++) {

				if ((output.DataItem["Ln"][i][1].Value.ToString()  == SECsHost.SECsNull) && (output.DataItem["Ln"][i][2].Value.ToString()  == SECsHost.SECsNull)) {  
					msgOutput.Append(output.DataItem["Ln"][i][0].Name + ": " + "does not exist" + "\n"); 
					msgOutput.Append(output.DataItem["Ln"][i][1].Name + ": " + "does not exist" + "\n"); 
					msgOutput.Append(output.DataItem["Ln"][i][2].Name + ": " + "does not exist" + "\n"); 
					msgOutput.Append("---------------------------------------------------\n");
				}
				else {
					msgOutput.Append(output.DataItem["Ln"][i][0].Name + ": " + output.DataItem["Ln"][i][0].Value + "\n"); 
					msgOutput.Append(output.DataItem["Ln"][i][1].Name + ": " + output.DataItem["Ln"][i][1].Value + "\n"); 
					msgOutput.Append(output.DataItem["Ln"][i][2].Name + ": " + output.DataItem["Ln"][i][2].Value + "\n"); 
					msgOutput.Append("---------------------------------------------------\n");
				}

																																			

			}
			Logger(msgOutput.ToString());
		}

		/// <summary>
		/// Handle S1F13 (Establish communication) reply from equipment
		/// </summary>
		/// <param name="output">COMM ACK, MDLN, SOFTREV</param>
		private void HandleEstablishCommunicationReply(SECsMessage output) {
			if (output.DataItem["Ln"]["COMMACK"].Value.ToString()  == "0") {
				StringBuilder msgOutput = new StringBuilder();
				msgOutput.Append("Establish Communication successfull\n");
				msgOutput.Append("MDLN: " + output.DataItem["Ln"]["Ln"]["MDLN"].Value + "\n"); 
				msgOutput.Append("SOFT REV " + output.DataItem["Ln"]["Ln"]["SOFTREV"].Value + "\n");
				Logger(msgOutput.ToString());
			}
			else
				Logger("Establish communication failed! Equipment acknowledge Non zero");
		}
		
		/// <summary>
		/// Handle S1F15 (Request Offline) reply from equipment
		/// </summary>
		/// <param name="output"></param>
		private void HandleEquipmentOffineReply(SECsMessage output) {
			if (output.DataItem["OFLACK"].Value.ToString() == "0") {
				Logger("Equipment Offline Request Successfull");
			}
			else {
				Logger("Equipment Offline Requestt Unsuccessfull");
			}
		}

		/// <summary>
		/// Handle S1F17 (Request Online) reply from equipment
		/// </summary>
		/// <param name="output"></param>
		private void HandleEquipmentOnlineReply(SECsMessage output) {
			if (output.DataItem["ONLACK"].Value.ToString() == "0") {
				Logger("Equipment Online Request Successfull");
			}
			else {
				Logger("Equipment Online Request Unsuccessfull");
			}

		}

		#endregion

		#region Stream 2 Command Button
		/// <summary>
		/// S2F13 Query all ECs
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdECQuery1_Click(object sender, System.EventArgs e) {
			// Query all equipment constant list from equipment. Empty List
			secsHost.EquipmentConstantListRequest(); 
		}

		/// <summary>
		/// S2F13 Query specified ECs
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdECQuery2_Click(object sender, System.EventArgs e) {
			// Initialize the list of EC to query to equipment.
			SECsItem ecList = new SECsItem();
			ecList.Add("Inkless Mode");
			ecList.Add("ProcessBinCode");
			
			// Query equipment constant list for equipment by a defined EC list
			secsHost.EquipmentConstantListRequest(ecList); 

		}

		/// <summary>
		/// S2F15 Set EC
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdNewEC_Click(object sender, System.EventArgs e) {
			SECsItem ecListValue = new SECsItem();
			
			ecListValue.Add("Inkless Mode", "12");
			ecListValue.Add("ProcessBinCode", "323");
			secsHost.EquipmentConstantUpdate(ecListValue); 

		}

		/// <summary>
		/// S2F17 Request date time
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdDateTimeReq_Click(object sender, System.EventArgs e) {
			secsHost.DateTimeRequest();
		}

		/// <summary>
		/// S2F21 Remote Command
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdRemoteCommand_Click(object sender, System.EventArgs e) {
			secsHost.RemoteCommand("Start Equipment");
		}
		
		/// <summary>
		/// S2F29 Select all EC Namelist
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdECNamelist1_Click(object sender, System.EventArgs e) {
			// Query all equipment constant namelist
			secsHost.EquipmentConstantNamelist(); 
		}

		/// <summary>
		/// S2F29 Select specified EC Namelist
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdECNamelist2_Click(object sender, System.EventArgs e) {
			SECsItem ecList = new SECsItem();
			ecList.Add("Inkless Mode");
			
			// Query equipment constant namelist by a defined EC list
			secsHost.EquipmentConstantNamelist(ecList); 
		}

		/// <summary>
		/// S2F31 Set equipment date time
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdDTSet_Click(object sender, System.EventArgs e) {
			DateTime myDateTime = new DateTime(2004,2,21, 12, 45,12,2);
			
			secsHost.DateTimeSetRequest(myDateTime);
 
			// alternatively you can invoke the following method
			// to set the datetime of equipment based on the current system time
			// secsHost.DateTimeSetRequest();
		}

		/// <summary>
		/// S2F33 Delete all reports and its link to CEID in the equipment
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdDeleteReports_Click(object sender, System.EventArgs e) {
			// Delete all reports and variables associated to it in equipment
			secsHost.DefineReports(DefineReportType.DeleteReports);		
		}

		/// <summary>
		/// S2F33 Define reports and variables associated to the report in the equipment
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdDefineReport_Click(object sender, System.EventArgs e) {
			secsHost.DefineReports(DefineReportType.DefineReports); 
			
		}
		
		/// <summary>
		/// S2F35 Delete the CEID and its associated reports in the equipment
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdUnlinkEventReport_Click(object sender, System.EventArgs e) {
			// Delete all event reports associated to the CEID
			secsHost.LinkEventReport(LinkEventReportType.UnlinkEventReports); 
		}

		/// <summary>
		/// S2F35 Link reports to CEID
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdLinkEventReport_Click(object sender, System.EventArgs e) {
			// Link all event reports associated to the CEID as defined in the model
			secsHost.LinkEventReport(LinkEventReportType.LinkEventReports); 

		}

		/// <summary>
		/// S2F37 Disable events
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdDisableEvent_Click(object sender, System.EventArgs e) {
			SECsItem eventList =  new SECsItem();
			// Add events to be disabled
			// Add logical name of the CEID
			eventList.Add("EquipmentStarted");
			
			// Disable events
			secsHost.EnableEventReport(eventList, false); 
			
			// alternatively you can invoke the following method
			// to disable all event report from equipment
			// secsHost.EnableEventReport(false);

		}

		/// <summary>
		/// S2F37 Enable events
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdEnableEvent1_Click(object sender, System.EventArgs e) {
//			SECsItem eventList =  new SECsItem();
//			// Add events to be enabled
//			// Add logical name of the CEID
//			eventList.Add("EquipmentStarted");
//			
//			// Enable events
//			secsHost.EnableEventReport(eventList, true); 

			// alternatively you can invoke the following method 
			// to enable all event report from equipment
			 secsHost.EnableEventReport(true);
		}

		/// <summary>
		/// S2F41 Send Host command to equipment
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdHostCommand_Click(object sender, System.EventArgs e) {
			// Get parameters of the host command by specifying the command logical name
			SECsItem parameters = secsHost.QueryHostCommandParameters("Lot TrackIn");
			
			if (parameters != null) {
				// Initializing the paramaters value
				parameters["LotId"].Value = "Eqp_0001";
				parameters["Quantity"].Value = "1000";

				// send host command by specifying the command logical name and parameters
				secsHost.HostCommand("Lot TrackIn", parameters);
			}
			
		}
		#endregion
		
		#region Stream 2 Secondary Reply Handler
		private void HandleEqupmentConstantListReply(SECsMessage output) {
			StringBuilder msgOutput = new StringBuilder();
			
			// Retrieve all the EC's value
			for (int i=0; i<output.DataItem["Ln"].Count; i++) {
				if (output.DataItem["Ln"][i].Value.ToString()  != SECsHost.SECsNull) 
					msgOutput.Append(output.DataItem["Ln"][i].Name + ": " + output.DataItem["Ln"][i].Value + "\n"); 
				else
					msgOutput.Append(output.DataItem["Ln"][i].Name + ": " + "does not exist" + "\n"); 

			}
			Logger(msgOutput.ToString());

		}

		private void HandleEquipmentConstantUpdateReply(SECsMessage output) {
			
			if (output.DataItem["EAC"].Value.ToString() == "0") 
				Logger("Equipment constant update successfully");
			else
				Logger("Equipment constant update not successfull");

		}
		
		private void HandleEquipmentDateTimeReply(SECsMessage output) {
			Logger(output.DataItem["TIME"].Value.ToString());
		}

		private void HandleRemoteCommandReply(SECsMessage output) {
			Logger("Remote Command reply: " + output.DataItem["CMDA"].Value.ToString());
		}

		private void HandleEquipmentECNamelistReply(SECsMessage output) {
			StringBuilder msgOutput = new StringBuilder();
			int index;
			// Retrieve all the EC's namelist value
			for (int i=0; i<output.DataItem["Ln"].Count; i++) {

				if ((output.DataItem["Ln"][i][1].Value.ToString()  == SECsHost.SECsNull) && (output.DataItem["Ln"][i][2].Value.ToString()  == SECsHost.SECsNull) && (output.DataItem["Ln"][i][3].Value.ToString()  == SECsHost.SECsNull) && (output.DataItem["Ln"][i][4].Value.ToString()  == SECsHost.SECsNull) && (output.DataItem["Ln"][i][5].Value.ToString()  == SECsHost.SECsNull)) {  
					for (index = 0; index < 6; index++)
						msgOutput.Append(output.DataItem["Ln"][i][index].Name + ": " + "does not exist" + "\n"); 
						
					msgOutput.Append("---------------------------------------------------\n");
				}
				else {
					for (index = 0; index < 6; index++)
						msgOutput.Append(output.DataItem["Ln"][i][index].Name + ": " + output.DataItem["Ln"][i][index].Value + "\n"); 
					
					msgOutput.Append("---------------------------------------------------\n");
				}

																																			

			}
			Logger(msgOutput.ToString());
		}

		private void HandleDateTimeSetReply(SECsMessage output) {
			if (output.DataItem["TIACK"].Value.ToString() == "0") 
				Logger("Successfully set equipment time");
			else
				Logger("Unsuccessfully set equipment time");
		}

		private void HandleDeleteAllReportReply(SECsMessage output) {
			if (output.DataItem["DRACK"].Value.ToString() == "0") 
				Logger("Delete all report accepted");
			else
				Logger("Delete all report not accepted");
		}	

		private void HandleDefineAllReportReply(SECsMessage output) {
			if (output.DataItem["DRACK"].Value.ToString() == "0") 
				Logger("Define report is accepted");
			else
				Logger("Define report is not accepted");
		}

		private void HandleUnlinkEventReportReply(SECsMessage output) {
			if (output.DataItem["LRACK"].Value.ToString() == "0") 
				Logger("Unlink event report is accepted");
			else
				Logger("Unlink event report is not accepted");
		}
		
		private void HandleLinkEventReportReply(SECsMessage output) {
			if (output.DataItem["LRACK"].Value.ToString() == "0") 
				Logger("Link event report is accepted");
			else
				Logger("Link event report is not accepted");
		}
		
		private void HandleEnableEventReportReply(SECsMessage output) {
			if (output.DataItem["ERACK"].Value.ToString() == "0")
				Logger("Successfully enable event report");
			else
				Logger("Fail to enable event report");
		}

		private void HandleDisableEventReportReply(SECsMessage output) {
			if (output.DataItem["ERACK"].Value.ToString() == "0")
				Logger("Successfully disable event report");
			else
				Logger("Fail to disable event report");
		}

		private void HandleHostCommandReply(SECsMessage output) {
			if (output.DataItem["Ln"]["HACK"].Value.ToString() == "0") {
				Logger("Successfully sent host command to equipment");
			} else {
				StringBuilder msgOutput = new StringBuilder();
				msgOutput.Append("HACK" + output.DataItem["Ln"]["HACK"].Value + "\n");
				msgOutput.Append("List of negative ack parameters\n");

				for (int i=0; i < output.DataItem["Ln"]["Ln"].Count; i ++) {
					msgOutput.Append(output.DataItem["Ln"]["Ln"][i][0].Name + ": " + output.DataItem["Ln"]["Ln"][i][0].Value + "\n");
					msgOutput.Append(output.DataItem["Ln"]["Ln"][i][1].Name + ": " + output.DataItem["Ln"]["Ln"][i][1].Value + "\n");
				}
				Logger(msgOutput.ToString());
			}
		}

		#endregion

		#region Stream 5 Command Button
		/// <summary>
		/// S5F3 Enable all alarms
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdEnableAllAlarm_Click(object sender, System.EventArgs e) {
			// Enable all alarm in the equipment
			secsHost.EnableAlarm(true); 

			// to disable all alarm simply invoke:
			// secsHost.EnableAlarm(false);
		}
		
		/// <summary>
		/// S5F3 Enable individual alarm
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdEnableAlarm_Click(object sender, System.EventArgs e) {
			// Enable individual alarm by the logical name
			secsHost.EnableAlarm("MotorError", true);

			// to disable alarm simply invoke:
			// secsHost.EnableAlarm("MotorError", false);
		}
		
		/// <summary>
		/// S5F5 List specified alarms currently configured at the equipment
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdListAlarm_Click(object sender, System.EventArgs e) {
			SECsItem alList = new SECsItem();

			// Add the actual ALID to query the alarm details configured in the equipment
			alList.Add("MotorError"); 
 
			secsHost.ListAlarms(alList);

			// alternatively, user can choose to list all alarm by invoking the following method:
			// secsHost.ListAlarms();

		}

		/// <summary>
		/// S5F7 List all enabled alarms at the equipment
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdListEnabledAlarm_Click(object sender, System.EventArgs e) {
			
			// List all enabled alarms configured in the equipment.
			secsHost.ListEnabledAlarms();
		}
		#endregion

		#region Stream 5 Secondary Reply Handler
		private void HandleEnableAlarmReportReply(SECsMessage output) {
			if (output.DataItem["ACKC5"].Value.ToString() == "0")
				Logger("Enable Alarms accepted by equipment");
			else
				Logger("Enable Alarms not accepted by equipment");
		}

		private void HandleDisableAlarmReportReply(SECsMessage output) {
			if (output.DataItem["ACKC5"].Value.ToString() == "0")
				Logger("Disable Alarms accepted by equipment");
			else
				Logger("Disable Alarms not accepted by equipment");
		}

		private void HandleListAlarmsReply(SECsMessage output) {
			StringBuilder sb = new StringBuilder();

			for (int i=0; i<output.DataItem[0].Count; i++) {
				sb.Append("Alarm Category: " + output.DataItem[0][i]["ALCD"].Value.ToString() + "\n");
				sb.Append("Alarm Category Description: " + output.DataItem[0][i]["ALCDESC"].Value.ToString() + "\n");
				sb.Append("Alarm Id: " + output.DataItem[0][i]["ALID"].Value.ToString() + "\n");
				sb.Append("Alarm Description: " + output.DataItem[0][i]["ALTX"].Value.ToString() + "\n");
				sb.Append("---------------------------------------------------\n");
			}

			Logger(sb.ToString());
		}

		private void HandleListEnabledAlarmReply(SECsMessage output) {
			StringBuilder sb = new StringBuilder();

			for (int i=0; i<output.DataItem[0].Count; i++) {
				sb.Append("Alarm Category: " + output.DataItem[0][i]["ALCD"].Value.ToString() + "\n");
				sb.Append("Alarm Category Description: " + output.DataItem[0][i]["ALCDESC"].Value.ToString() + "\n");
				sb.Append("Alarm Id: " + output.DataItem[0][i]["ALID"].Value.ToString() + "\n");
				sb.Append("Alarm Description: " + output.DataItem[0][i]["ALTX"].Value.ToString() + "\n");
				sb.Append("---------------------------------------------------\n");
			}

			Logger(sb.ToString());
		}

		private void HandleAlarmSet(SECsMessage input) {
			StringBuilder sb = new StringBuilder();
			sb.Append("Alarm Set\n");

			sb.Append("Alarm Category: " + input.DataItem[0]["ALCD"].Value.ToString() + "\n");
			sb.Append("Alarm Category Description: " + input.DataItem[0]["ALCDESC"].Value.ToString() + "\n");
			sb.Append("Alarm ID: " + input.DataItem[0]["ALID"].Value.ToString() + "\n");
			sb.Append("Alarm Text: " + input.DataItem[0]["ALTX"].Value.ToString() + "\n");

			Logger(sb.ToString());
		}

		private void HandleAlarmClear(SECsMessage input) {
			StringBuilder sb = new StringBuilder();
			sb.Append("Alarm Clear\n");

			sb.Append("Alarm Category: " + input.DataItem[0]["ALCD"].Value.ToString() + "\n");
			sb.Append("Alarm Category Description: " + input.DataItem[0]["ALCDESC"].Value.ToString() + "\n");
			sb.Append("Alarm ID: " + input.DataItem[0]["ALID"].Value.ToString() + "\n");
			sb.Append("Alarm Text: " + input.DataItem[0]["ALTX"].Value.ToString() + "\n");
			
			Logger(sb.ToString());
		}
		#endregion

		#region Stream 6 Command Button
		/// <summary>
		/// S6F15 Request equipment to send the specified event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdEventReportRequest_Click(object sender, System.EventArgs e) {
			// Request equipment to send the event report by specifying the logical event name
			// as defined in the model.
			secsHost.EventReportRequest("EquipmentStarted"); 
		}
		#endregion
		
		#region Stream 6 Secondary Reply Handler
		private void HandleEventReportReply(SECsMessage output) {
			Logger(GetEventReportBody(output));
			
		}

		private void HandleEventReport(SECsMessage input) {
			Logger(GetEventReportBody(input));
			
		}

		private string GetEventReportBody(SECsMessage output) {
			StringBuilder sb = new StringBuilder();
			// Retrieve the Event logical name
			sb.Append("Event (CEID): " + output.DataItem["Ln"]["CEID"].Value.ToString() + "\n");
			sb.Append("---------------------------\n");
			sb.Append("Report(s)");
			for (int i=0; i< output.DataItem["Ln"]["Ln"].Count; i++) {
				// Retrieve Report Logical Name
				sb.Append("\t Rpt ID: " + output.DataItem["Ln"]["Ln"][i][0].Value.ToString() + "\n");
				
				// Retrieve all the variables for that report
				// variables are all in logical name
				for (int j=0; j<output.DataItem["Ln"]["Ln"][i][1].Count; j++) {
					sb.Append("\t\t " + output.DataItem["Ln"]["Ln"][i][1][j].Name + ": " + output.DataItem["Ln"]["Ln"][i][1][j].Value.ToString() + "\n");
				}
			}

			return sb.ToString();

		}
		#endregion
		
		private void HandleProcessProgramDataReply(SECsMessage outputs) {
			// Retrieve the PPID
			string ppid = outputs.DataItem["Ln"]["PPID"].Value.ToString();

			// Check is the PPBODY format is binary, otherwise you need to use normal text stream writer.
			if (outputs.DataItem["Ln"]["PPBODY"].Format == SECsFormat.Binary) {
				// Create a binary writer to contain the Recipe body
				FileStream fs = new FileStream(ppid, FileMode.Create, FileAccess.Write);
				
				BinaryWriter w = new BinaryWriter(fs);
				// Write PPBODY to the file.
				w.Write((byte[])outputs.DataItem["Ln"]["PPBODY"].Value);
				
				w.Close();
				fs.Close();
				Logger("Process Program saved to file!");
			}

		}

		private void HandleCurrentEPPDReply(SECsMessage outputs) {
			StringBuilder sb = new StringBuilder();
			
			sb.Append("List of PPIDs: \n");
			for (int i=0; i<outputs.DataItem["Ln"].Count; i++) {
				sb.Append(outputs.DataItem["Ln"][i].Value.ToString() + "\n");
			}

			Logger(sb.ToString());
		}

		private void AllStreamLibrarySample_Load(object sender, System.EventArgs e) {
			secsHost = SECsFactory.CreateInstance(); 
			
			try {
				secsHost.Initialize(AppDomain.CurrentDomain.BaseDirectory + "\\ToolModel1.xml");
			} catch (SECsHostException shex) {
				Logger(shex.Message);
			}

			if (secsHost.IsInitialized) {
				secsHost.SECsPrimaryIn += new Insphere.SecsToTool.Application.SECsBase.SECsPrimaryInEventHandler(secsHost_SECsPrimaryIn);
				secsHost.SECsSecondaryIn += new Insphere.SecsToTool.Application.SECsBase.SECsSecondaryInEventHandler(secsHost_SECsSecondaryIn);
				secsHost.SECsHostError += new Insphere.SecsToTool.Application.SECsBase.SECsHostErrorHandler(secsHost_SECsHostError);
			} else
				Logger("secsHost is not initialized");

			
		}
		
		/// <summary>
		/// Download unformatted recipe (binary) to equipment
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdPPSend_Click(object sender, System.EventArgs e) {
			
			// Open Recipe2.prg file.
			string recipeFileName = "Recipe2.prg";	// Big recipe >2MB
			FileStream fs = new FileStream(recipeFileName, FileMode.Open, FileAccess.Read);
			// Create binary reader
			BinaryReader r = new BinaryReader(fs);

			// Read the binary content of Recipe2.prg
			byte[] ppbody = r.ReadBytes((int)fs.Length);
			Debug.WriteLine(recipeFileName + ": " + ppbody.Length.ToString());
			// Send Recipe download to equipment
			secsHost.SendProcessProgram(recipeFileName, ppbody);
  
			r.Close();
			fs.Close();
			
		}

		private void cmdPPRequest_Click(object sender, System.EventArgs e) {
			secsHost.ProcessProgramRequest("RecipeFromEquipment.prg");
		}

		private void cmdDeletePP_Click(object sender, System.EventArgs e) {
		
			// Construct a list of PPID that we want equipment to delete
			SECsItem ppList = new SECsItem();
			ppList.Add("Recipe1.prg");
			ppList.Add("Recipe2.prg");
			
			// Send out the Delete Recipe Message
			secsHost.DeleteProcessProgram(ppList);

		}

		private void cmdCurrentEPPD_Click(object sender, System.EventArgs e) {
			// Request equipment to send all the PPIDs from its directory
			secsHost.CurrentEPPDRequest();
		}

		private void linkClearMessage_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e) {
			listMessage.Items.Clear();
		}

		private void cmdInitialize_Click(object sender, System.EventArgs e) {
		
		}

//		[STAThread]
//		static void Main() {
//			System.Windows.Forms.Application.Run(new AllStreamLibrarySample());
//		}
	}
}
