using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        bool restoreFiles = true;

        private void fileTransferWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] args = (string[])e.Argument;

            string mapsPath = args[0];


            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;
            if (!File.Exists(Path.Combine(mapsPath, "fmmbak", "tags.dat")))
            {
                foreach (string file in files)
                {
                    if ((worker.CancellationPending == true))
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        File.Copy(Path.Combine(mapsPath, file), Path.Combine(mapsPath, "fmmbak", file), true); i++;
                        float progress = ((float)i / (float)files.Count()) * 100;
                        worker.ReportProgress(Convert.ToInt32(progress));
                    }
                }
            }
            else
            {
                foreach (string file in files)
                {
                    if ((worker.CancellationPending == true) || (restoreFiles == false))
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        if (File.Exists(Path.Combine(mapsPath, "fmmbak", file)) && File.Exists(Path.Combine(mapsPath, file)))
                        {
                            if (!areBakAndMainEqual(new FileInfo(Path.Combine(mapsPath, "fmmbak", file)), new FileInfo(Path.Combine(mapsPath, file))))
                            {
                                File.Copy(Path.Combine(mapsPath, "fmmbak", file), Path.Combine(mapsPath, file), true);
                            }
                            i++;
                            float progress = ((float)i / (float)files.Count()) * 100;
                            worker.ReportProgress(Convert.ToInt32(progress));
                        }
                    }
                }
            }
        }
        
        static bool areBakAndMainEqual(FileInfo first, FileInfo second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }

            FileStream firstFS = first.OpenRead();
            FileStream secondFS = second.OpenRead();

            byte[] firstHash = System.Security.Cryptography.MD5.Create().ComputeHash(firstFS);
            byte[] secondHash = System.Security.Cryptography.MD5.Create().ComputeHash(secondFS);

            for (int i = 0; i < firstHash.Length; i++)
            {
                if (firstHash[i] != secondHash[i])
                {
                    firstFS.Close();
                    secondFS.Close();
                    return false;
                }
            }
            firstFS.Close();
            secondFS.Close();
            return true;
        }

        private void fileTransferWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string mapsPath = Path.Combine(Directory.GetCurrentDirectory(), "maps");
            if (isRestoringVsBackingUp == true)
            {
                percentageLabel.Text = "Restoring clean files: " + e.ProgressPercentage.ToString() + "%";
            }
            else
            {
                percentageLabel.Text = "Preparing a backup: " + e.ProgressPercentage.ToString() + "%";
            }
        }

        private void fileTransferWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Error == null))
            {
                percentageLabel.Text = ("Error: " + e.Error.Message);
            }
            else
            {
                string mapsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "maps");

                tabControl1.Enabled = true;

                if (modInstallWorker.IsBusy != true)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    openGameRoot.Enabled = false;
                    openMods.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    outputPanel.Visible = true;
                    tabControl1.Enabled = false;
                    modInstallWorker.RunWorkerAsync(new string[] { mapsPath });
                }
            }
        }
    }
}
