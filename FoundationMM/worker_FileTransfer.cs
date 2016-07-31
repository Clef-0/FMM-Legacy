using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
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
                            if (!areBakAndMainEqual(Path.Combine(mapsPath, "fmmbak", file), Path.Combine(mapsPath, file)))
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
        
        private bool areBakAndMainEqual(string file1, string file2)
        {
            if (file1 == file2)
            {
                return true;
            }

            using (FileStream fs1 = File.OpenRead(file1))
            {
                using (FileStream fs2 = File.OpenRead(file2))
                {
                    if (fs1.Length != fs2.Length)
                    {
                        return false;
                    }

                    int count;
                    const int size = 0x1000000;

                    var buffer = new byte[size];
                    var buffer2 = new byte[size];

                    while ((count = fs1.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs2.Read(buffer2, 0, buffer2.Length);

                        for (int i = 0; i < count; i++)
                        {
                            if (buffer[i] != buffer2[i])
                            {
                                return false;
                            }
                        }
                    }
                }
            }

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
