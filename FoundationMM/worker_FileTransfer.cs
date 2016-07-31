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
        
        // borrowed from James Johnson @ StackOverflow because Clef's code sucked ass
        private bool areBakAndMainEqual(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
            fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1byte - file2byte) == 0);
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
