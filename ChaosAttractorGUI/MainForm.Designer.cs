namespace ChaosAttractorGUI
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblMaxOutput = new System.Windows.Forms.Label();
			this.checkBoxFlatten = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox.Location = new System.Drawing.Point(2, 41);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(400, 400);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "[ Hit enter or spacebar ]";
			// 
			// lblMaxOutput
			// 
			this.lblMaxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMaxOutput.Location = new System.Drawing.Point(134, 25);
			this.lblMaxOutput.Name = "lblMaxOutput";
			this.lblMaxOutput.Size = new System.Drawing.Size(258, 13);
			this.lblMaxOutput.TabIndex = 2;
			this.lblMaxOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBoxFlatten
			// 
			this.checkBoxFlatten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBoxFlatten.AutoSize = true;
			this.checkBoxFlatten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxFlatten.Location = new System.Drawing.Point(344, 5);
			this.checkBoxFlatten.Name = "checkBoxFlatten";
			this.checkBoxFlatten.Size = new System.Drawing.Size(55, 17);
			this.checkBoxFlatten.TabIndex = 300;
			this.checkBoxFlatten.Text = "Flatten";
			this.checkBoxFlatten.UseVisualStyleBackColor = true;
			this.checkBoxFlatten.CheckedChanged += new System.EventHandler(this.checkBoxFlatten_CheckedChanged);			
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 443);
			this.Controls.Add(this.lblMaxOutput);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.checkBoxFlatten);
			this.Name = "MainForm";
			this.Text = "Chaos Attractor";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblMaxOutput;
		private System.Windows.Forms.CheckBox checkBoxFlatten;
	}
}

