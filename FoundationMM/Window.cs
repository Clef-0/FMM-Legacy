using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ini;

namespace FoundationMM
{
    public partial class Window : Form
    {
        string[] files = {
                    @"fonts\font_package.bin",
                    "audio.dat",
                    "bunkerworld.map",
                    "chill.map",
                    "cyberdyne.map",
                    "deadlock.map",
                    "guardian.map",
                    "mainmenu.map",
                    "resources.dat",
                    "riverworld.map",
                    "s3d_avalanche.map",
                    "s3d_edge.map",
                    "s3d_reactor.map",
                    "s3d_turf.map",
                    "shrine.map",
                    "string_ids.dat",
                    "tags.dat",
                    "textures.dat",
                    "textures_b.dat",
                    "video.dat",
                    "zanzibar.map"
                };

        List<string> locatedFMMInstallers = new List<string>();

        public Window()
        {
            InitializeComponent();
        }

        BackgroundWorker deleteOldBackupWorker = new BackgroundWorker();
        BackgroundWorker fileTransferWorker = new BackgroundWorker();
        BackgroundWorker modInstallWorker = new BackgroundWorker();
        BackgroundWorker restoreCleanWorker = new BackgroundWorker();

        private void Window_Load(object sender, EventArgs e)
        {
            deleteOldBackupWorker.WorkerSupportsCancellation = true;
            deleteOldBackupWorker.DoWork += new DoWorkEventHandler(deleteOldBackup_DoWork);

            fileTransferWorker.WorkerSupportsCancellation = true;
            fileTransferWorker.WorkerReportsProgress = true;
            fileTransferWorker.DoWork += new DoWorkEventHandler(fileTransferWorker_DoWork);
            fileTransferWorker.ProgressChanged += new ProgressChangedEventHandler(fileTransferWorker_ProgressChanged);
            fileTransferWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(fileTransferWorker_RunWorkerCompleted);

            modInstallWorker.WorkerSupportsCancellation = true;
            modInstallWorker.WorkerReportsProgress = true;
            modInstallWorker.DoWork += new DoWorkEventHandler(modInstallWorker_DoWork);
            modInstallWorker.ProgressChanged += new ProgressChangedEventHandler(modInstallWorker_ProgressChanged);
            modInstallWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(modInstallWorker_RunWorkerCompleted);

            restoreCleanWorker.WorkerSupportsCancellation = true;
            restoreCleanWorker.WorkerReportsProgress = true;
            restoreCleanWorker.DoWork += new DoWorkEventHandler(restoreCleanWorker_DoWork);
            restoreCleanWorker.ProgressChanged += new ProgressChangedEventHandler(restoreCleanWorker_ProgressChanged);
            restoreCleanWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(restoreCleanWorker_RunWorkerCompleted);

            DirectoryInfo dir0 = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "mods", "tagmods"));
#if !DEBUG
            if (!File.Exists(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mtndew.dll")))
            {
                MessageBox.Show("The FMM zip should be extracted to the root of your ElDewrito directory.");

                Application.Exit();
                return;
            }

            string identifier = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.ini");
            if (!File.Exists(identifier))
            {
                IniFile ini = new IniFile(identifier);
                FileVersionInfo mtndewVersion = FileVersionInfo.GetVersionInfo(Path.Combine(Directory.GetCurrentDirectory(), "mtndew.dll"));
                ini.IniWriteValue("FMMPrefs", "EDVersion", mtndewVersion.FileVersion);
            }
            else
            {
                IniFile ini = new IniFile(identifier);

                Form thisForm = (Form)sender;
                thisForm.Width = Convert.ToInt32(ini.IniReadValue("FMMPrefs", "Width"));
                thisForm.Height = Convert.ToInt32(ini.IniReadValue("FMMPrefs", "Height"));

                string savedversion = ini.IniReadValue("FMMPrefs", "EDVersion");
                string actualversion = FileVersionInfo.GetVersionInfo(Path.Combine(Directory.GetCurrentDirectory(), "mtndew.dll")).FileVersion;

                if (savedversion != actualversion)
                {
                    string mapsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "maps");
                    deleteOldBackupWorker.RunWorkerAsync(new string[] { mapsPath });
                    ini.IniWriteValue("FMMPrefs", "EDVersion", actualversion);
                }
            }

#endif

            lookForFMMInstallers();
            addFMMInstallersToList();
            checkFMMInstallerOrder();

            
            int modCount = listView1.Items.Count;
            if (modCount == 1)
            {
                modNumberLabel.Text = "1 mod available";
            }
            else
            {
                modNumberLabel.Text = modCount + " mods available";
            }
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form thisForm = (Form)sender;
            string identifier = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.ini");
            if (File.Exists(identifier))
            {
                IniFile ini = new IniFile(identifier);
                ini.IniWriteValue("FMMPrefs", "Width", thisForm.Width.ToString());
                ini.IniWriteValue("FMMPrefs", "Height", thisForm.Height.ToString());
            }
        }
    }
}
