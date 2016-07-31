using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        private void restoreCleanWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] args = (string[])e.Argument;

            string mapsPath = args[0];

            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;
            foreach (string file in files)
            {
                if ((worker.CancellationPending == true))
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

        private void restoreCleanWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            percentageLabel.Text = "Restoring clean files: " + e.ProgressPercentage.ToString() + "%";
        }

        private void restoreCleanWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                percentageLabel.Text = "";
                MessageBox.Show("Clean files restored.");
                button1.Enabled = true;
                button2.Enabled = true;
                openGameRoot.Enabled = true;
                openMods.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                tabControl1.Enabled = true;
                statusStrip1.Invoke((MethodInvoker)delegate { refreshMods.Enabled = true; });
            }
        }
    }
}
