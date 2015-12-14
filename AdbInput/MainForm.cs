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
		private static readonly string ALLOWED_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ:";
		private static readonly Dictionary<char, int> EVENT_CHARS = new Dictionary<char, int>
	    {
	        { '#', 18 },
			{ '*', 17 },
			{ ' ', 62 },
			{ '.', 56 },
			{ '@', 77 },
			{ ':', 77 },
			{ '/', 76 },
	    };
	
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		void SubmitButtonClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process process = new System.Diagnostics.Process();
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
			startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			startInfo.FileName = "adb.exe";
			
			int i = 0;
			String parts = "";
			var text = adbTextBox.Text;
			foreach (var part in text)
			{
				i++;
				if ( ALLOWED_CHARS.Contains(part.ToString()) )
				{
					parts += part;
					if (i < text.Length)
						continue;
				}
				if (parts.Length > 0)
				{
					startInfo.Arguments = "shell input text \""+parts+"\"";
					process.StartInfo = startInfo;
					process.Start();
					process.WaitForExit();
				}
				parts = "";
				
				if (EVENT_CHARS.ContainsKey(part))
					startInfo.Arguments = "shell input keyevent " + EVENT_CHARS[part];
				else
					continue;
				process.StartInfo = startInfo;
				process.Start();
				process.WaitForExit();
			}
		}
	}
}
