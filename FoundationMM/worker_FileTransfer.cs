using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
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
                        File.Copy(Path.Combine(mapsPath, file), Path.Combine(mapsPath, "fmmbak", file), true);
                        i++;
                        float progress = ((float)i / (float)files.Count()) * 100;
                        worker.ReportProgress(Convert.ToInt32(progress));
                    }
                }
            }
            else
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
                        File.Copy(Path.Combine(mapsPath, "fmmbak", file), Path.Combine(mapsPath, file), true);
                        i++;
                        float progress = ((float)i / (float)files.Count()) * 100;
                        worker.ReportProgress(Convert.ToInt32(progress));
                    }
                }
            }
        }

        private void fileTransferWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            percentageLabel.Text = "Preparing clean files: " + e.ProgressPercentage.ToString() + "%";
        }

        private void fileTransferWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                percentageLabel.Text = "Canceled!";
            }
            else if (!(e.Error == null))
            {
                percentageLabel.Text = ("Error: " + e.Error.Message);
            }
            else
            {
                string mapsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "maps");

                if (modInstallWorker.IsBusy != true)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    openGameRoot.Enabled = false;
                    openMods.Enabled = false;
                    button7.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    modInstallWorker.RunWorkerAsync(new string[] { mapsPath });
                }
            }
        }
    }
}
