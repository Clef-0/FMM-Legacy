using SharpSvn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        private void dlModWorkerStarter_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            List<ListViewItem> mods = (List<ListViewItem>)e.Argument;

            int i = 0;
            worker.ReportProgress(i);

            foreach (ListViewItem item in mods)
            {
                tabControl1.Invoke((MethodInvoker)delegate { tabControl1.Enabled = false; });
                string remLocation = "https://github.com/Clef-0/FMM-Mods/trunk/" + item.SubItems[5].Text;
                Debug.WriteLine(remLocation);
                string locLocation = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mods", "tagmods", item.SubItems[5].Text.Replace("/", "\\"));
                Debug.WriteLine(locLocation);
                dlModWorker.RunWorkerAsync(new string[] { remLocation, locLocation });
                do {
                    Thread.Sleep(100);
                } while (dlModWorker.IsBusy);

                i++;
                float progress = ((float)i / (float)mods.Count()) * 100;
                worker.ReportProgress(Convert.ToInt32(progress));
            }
            tabControl1.Invoke((MethodInvoker)delegate { tabControl1.Enabled = true; });
        }

        private void dlModWorkerStarter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            percentageLabel.Text = "Downloading mods: " + e.ProgressPercentage.ToString() + "%";
        }

        private void dlModWorkerStarter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Selected mods downloaded.\nRefresh your \"My Mods\" window.");
            tabControl1.Invoke((MethodInvoker)delegate { tabControl1.Enabled = true; });
            statusStrip1.Invoke((MethodInvoker)delegate { percentageLabel.Text = ""; });
        }

        private void dlModWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SvnClient client = new SvnClient();

            string[] args = (string[])e.Argument;
            string remLocation = args[0];
            string locLocation = args[1];
            remLocation = remLocation.Replace(System.IO.Path.GetFileName(new Uri(remLocation).LocalPath), "");

            locLocation = Path.GetDirectoryName(locLocation);
            Debug.WriteLine(remLocation + "  &&  " + locLocation);

            BackgroundWorker worker = sender as BackgroundWorker;
            if (Directory.Exists(locLocation))
            {
                Directory.Delete(locLocation, true);
            }
            Directory.CreateDirectory(locLocation);
            if (Directory.Exists(Path.Combine(locLocation, ".svn")))
            {
                client.CleanUp(locLocation);
            }

            client.CheckOut(new Uri(remLocation), locLocation);

            fexeProcessDirectory(locLocation); // aka the "thanks a lot, flatgrass" function
        }

        private void fexeProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                fexeProcessFile(fileName);

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                fexeProcessDirectory(subdirectory);
        }

        private void fexeProcessFile(string path)
        {
            if (Path.GetExtension(path) == ".fexe")
            {
                if (File.Exists(Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".ini")))
                {
                    File.Delete(Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".ini"));
                }
                File.Move(path, Path.Combine(System.IO.Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(path) + ".exe"));

                // startInfo for extractor
                ProcessStartInfo startInfo = new ProcessStartInfo();
                if (showInstallers == false)
                {
                    startInfo.CreateNoWindow = true;
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                }
                startInfo.FileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(path) + ".exe");
                startInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory();

                // start extractor
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
        }

        private void dlModWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Error == null))
            {
                percentageLabel.Text = ("Error: " + e.Error.Message);
            }
            else
            {
                percentageLabel.Text = "";
            }
        }
    }
}
