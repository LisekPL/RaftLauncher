using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		string gameFolder = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData), "..\\LocalLow\\Raft");
		int startingVersionId;
		Thread downloading, unZipping;
		bool updateVersionsList, connectionError;
		Versions versions;

		public Form1()
		{
			InitializeComponent ();
		}

		void Start(object sender, EventArgs e)
		{
			downloading = new Thread (StartLauncher);
			downloading.Start ();
		}
		void StartLauncher()
		{
			if (!Directory.Exists (gameFolder))
				Directory.CreateDirectory (gameFolder);

			if (File.Exists (gameFolder + "\\versions.xml"))
			{
				XmlSerializer serializer = new XmlSerializer (typeof (Versions));

				FileStream file = new FileStream (gameFolder + "\\versions.xml", FileMode.Open);
				versions = serializer.Deserialize (file) as Versions;

				file.Close ();

				updateVersionsList = true;
			}

			CreateFolder (gameFolder + "\\downloading");
			try
			{
				using (var klient = new WebClient ())
				{
					klient.DownloadFile (new Uri ("https://pastebin.com/raw/HztQYnHf"), gameFolder + "\\downloading\\versions.xml");

					XmlSerializer serializer = new XmlSerializer (typeof (Versions));

					FileStream file = new FileStream (gameFolder + "\\downloading\\versions.xml", FileMode.Open);
					Versions versionsToTest = serializer.Deserialize (file) as Versions;

					file.Close ();

					if (versionsToTest != null)
					{
						versions = versionsToTest;
						if (File.Exists (gameFolder + "\\versions.xml"))
							File.Delete (gameFolder + "\\versions.xml");

						if (File.Exists (gameFolder + "\\downloading\\versions.xml"))
							File.Move (gameFolder + "\\downloading\\versions.xml", gameFolder + "\\versions.xml");
					}
					else
					{
						if (File.Exists (gameFolder + "\\versions.xml"))
							File.Delete (gameFolder + "\\downloading\\versions.xml");
					}
					updateVersionsList = true;
				}
			}
			catch
			{
				connectionError = true;
			}
		}

		void Timer1_Tick(object sender, EventArgs e)
		{
			if (updateVersionsList)
			{
				comboBoxVersions.Items.Clear ();
				comboBoxVersions.Items.AddRange (versions.displayName);
				comboBoxVersions.SelectedIndex = 0;

				if (!buttonPlay.Enabled)
					buttonPlay.Enabled = true;

				updateVersionsList = false;
			}
			if (connectionError)
			{
				infoLabel.Text = "No internet connection.";
			}
		}

		void ButtonPlay_Click(object sender, EventArgs e)
		{
			startingVersionId = comboBoxVersions.SelectedIndex;

			buttonPlay.Visible = false;
			comboBoxVersions.Visible = false;
			downloadPercentage.Text = "0%";

			try
			{
				Process.Start (gameFolder + "\\versions\\" + versions.folderName[startingVersionId] + "\\" + versions.exeName[startingVersionId] + ".exe");
				Application.Exit ();
			}
			catch
			{
				CreateFolder (gameFolder + "\\versions\\" + versions.folderName[startingVersionId]);

				using (var client = new WebClient ())
				{
					client.DownloadFileAsync (new Uri (versions.link [startingVersionId]), gameFolder + "\\downloading\\" + versions.folderName[startingVersionId] + ".zip");

					progressBarDownload.Visible = true;

					client.DownloadProgressChanged += Client_DownloadProgressChanged;
					client.DownloadFileCompleted += Client_DownloadFileCompleted;
				}
			}
		}

		void CreateFolder(string folder)
		{
			if (!Directory.Exists (folder))
				Directory.CreateDirectory (folder);
		}

		void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			progressBarDownload.Value = e.ProgressPercentage;
			downloadPercentage.Text = e.ProgressPercentage + "%\n" +
				((float)e.BytesReceived / 1048576).ToString("n1", CultureInfo.CreateSpecificCulture("pl-PL")) + "/" + ((float)e.TotalBytesToReceive / 1048576).ToString("n1") + "MB";
		}

		void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			progressBarDownload.Value = 100;
			downloadPercentage.Text = "100%";

			unZipping = new Thread (UnzipGame);
			unZipping.Start ();
		}

		void UnzipGame()
		{
			ZipFile.ExtractToDirectory (gameFolder + "\\downloading\\" + versions.folderName[startingVersionId] + ".zip", gameFolder + "\\versions\\");
			File.Delete (gameFolder + "\\downloading\\" + versions.folderName[startingVersionId] + ".zip");
			Process.Start (gameFolder + "\\versions\\" + versions.folderName[startingVersionId] + "\\" + versions.exeName[startingVersionId] + ".exe");
			Application.Exit ();
		}
	}
}
