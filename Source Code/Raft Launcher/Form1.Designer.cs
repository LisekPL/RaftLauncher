namespace WindowsFormsApp1
{
	partial class Form1
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Wymagana metoda obsługi projektanta — nie należy modyfikować 
		/// zawartość tej metody z edytorem kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.buttonPlay = new System.Windows.Forms.Button();
			this.progressBarDownload = new System.Windows.Forms.ProgressBar();
			this.downloadPercentage = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.comboBoxVersions = new System.Windows.Forms.ComboBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.infoLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonPlay
			// 
			this.buttonPlay.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonPlay.Enabled = false;
			this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonPlay.Location = new System.Drawing.Point(8, 141);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(102, 46);
			this.buttonPlay.TabIndex = 0;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
			// 
			// progressBarDownload
			// 
			this.progressBarDownload.Location = new System.Drawing.Point(8, 141);
			this.progressBarDownload.Name = "progressBarDownload";
			this.progressBarDownload.Size = new System.Drawing.Size(232, 46);
			this.progressBarDownload.TabIndex = 7;
			this.progressBarDownload.Visible = false;
			// 
			// downloadPercentage
			// 
			this.downloadPercentage.BackColor = System.Drawing.Color.Transparent;
			this.downloadPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.downloadPercentage.Location = new System.Drawing.Point(246, 141);
			this.downloadPercentage.Name = "downloadPercentage";
			this.downloadPercentage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.downloadPercentage.Size = new System.Drawing.Size(80, 46);
			this.downloadPercentage.TabIndex = 8;
			this.downloadPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// comboBoxVersions
			// 
			this.comboBoxVersions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxVersions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxVersions.FormattingEnabled = true;
			this.comboBoxVersions.Location = new System.Drawing.Point(116, 141);
			this.comboBoxVersions.Name = "comboBoxVersions";
			this.comboBoxVersions.Size = new System.Drawing.Size(206, 28);
			this.comboBoxVersions.TabIndex = 9;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(-2, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(340, 134);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 14;
			this.pictureBox2.TabStop = false;
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.Location = new System.Drawing.Point(116, 174);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(0, 13);
			this.infoLabel.TabIndex = 15;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 196);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.buttonPlay);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.comboBoxVersions);
			this.Controls.Add(this.progressBarDownload);
			this.Controls.Add(this.downloadPercentage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Raft Launcher";
			this.Load += new System.EventHandler(this.Start);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.ProgressBar progressBarDownload;
		private System.Windows.Forms.Label downloadPercentage;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ComboBox comboBoxVersions;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label infoLabel;
	}
}

