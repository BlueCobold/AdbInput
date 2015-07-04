/*
 * Created by SharpDevelop.
 * User: BlueCobold
 * Date: 06.06.2015
 * Time: 11:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdbInput
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		void SubmitButtonClick(object sender, EventArgs e)
		{
			int i = 0;
			String parts = "";
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			var text = adbTextBox.Text;
			foreach (var part in text)
			{
				i++;
				if (part >= 'a' && part <='z' ||
				    part >= 'A' && part <='Z' ||
				    part >= '0' && part <='9' )
				{
					parts += part;
					if (i < text.Length)
						continue;
				}
				if (parts.Length > 0)
				{
					startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
					startInfo.Arguments = "shell input text \""+parts+"\"";
					startInfo.FileName = "adb.exe";
					process.StartInfo = startInfo;
					process.Start();
					process.WaitForExit();
				}
				
				startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				startInfo.FileName = "adb.exe";
				if (part == '#')
					startInfo.Arguments = "shell input keyevent 18";
				else if (part == '*')
					startInfo.Arguments = "shell input keyevent 17";
				else if (part == ' ')
					startInfo.Arguments = "shell input keyevent 62";
				else
					continue;
				process.StartInfo = startInfo;
				process.Start();
				process.WaitForExit();
				parts = "";
			}
		}
	}
}
