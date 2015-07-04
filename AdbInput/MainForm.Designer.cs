/*
 * Created by SharpDevelop.
 * User: BlueCobold
 * Date: 06.06.2015
 * Time: 11:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace AdbInput
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.adbTextBox = new System.Windows.Forms.TextBox();
			this.submitButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// adbTextBox
			// 
			this.adbTextBox.Location = new System.Drawing.Point(13, 13);
			this.adbTextBox.Multiline = true;
			this.adbTextBox.Name = "adbTextBox";
			this.adbTextBox.Size = new System.Drawing.Size(829, 72);
			this.adbTextBox.TabIndex = 0;
			// 
			// submitButton
			// 
			this.submitButton.Location = new System.Drawing.Point(13, 92);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(829, 23);
			this.submitButton.TabIndex = 1;
			this.submitButton.Text = "submit";
			this.submitButton.UseVisualStyleBackColor = true;
			this.submitButton.Click += new System.EventHandler(this.SubmitButtonClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(854, 129);
			this.Controls.Add(this.submitButton);
			this.Controls.Add(this.adbTextBox);
			this.Name = "MainForm";
			this.Text = "AdbInput";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button submitButton;
		private System.Windows.Forms.TextBox adbTextBox;
	}
}
