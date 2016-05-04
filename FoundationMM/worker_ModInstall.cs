using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        public void modInstallWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;

            // Save File Storing Checked Items And Order

            string fmmdat = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.dat");
            FileStream fmmdatWiper = File.Open(fmmdat, FileMode.OpenOrCreate);
            fmmdatWiper.SetLength(0);
            fmmdatWiper.Close();

            StreamWriter fmmdatWriter = new StreamWriter(fmmdat);
            foreach (ListViewItem item in listView1.CheckedItems.Cast<ListViewItem>().AsEnumerable().Reverse())
            {
                fmmdatWriter.WriteLine(item.SubItems[0].Text);
            }
            fmmdatWriter.Close();

            worker.ReportProgress(i);

            //apply mods
            foreach (ListViewItem item in listView1.CheckedItems.Cast<ListViewItem>().AsEnumerable().Reverse())
            {
                // init variables
                string fmFile = Path.Combine(Directory.GetCurrentDirectory(), "mods", item.SubItems[3].Text);
                string batFile = Path.Combine(Path.GetDirectoryName(fmFile), "fm_temp.bat");

                try
                {
                    // duplicate .fm as temp .bat installer.
                    File.Copy(fmFile, batFile, true);

                    // startInfo for installer
                    ProcessStartInfo startInfo = new ProcessStartInfo();
#if !DEBUG
                    startInfo.CreateNoWindow = true;
                    startInfo.UseShellExecute = false;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
#endif
                    startInfo.FileName = batFile;
                    startInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory();

                    // start installer
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }

                    i++;
                    float progress = ((float)i / (float)listView1.CheckedItems.Cast<ListViewItem>().Count()) * 100;
                    worker.ReportProgress(Convert.ToInt32(progress));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error installing " + item.SubItems[0].Text + ".\nPlease consult the #eldorito IRC for help.\n\n\"" + ex.Message + "\"", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    try
                    {
                        // delete installer
                        File.Delete(batFile);
                    }
                    catch
                    {
                        MessageBox.Show("Whoops. That's not good. Tell Clef, please.");
                    }
                }
            }
        }

        private void modInstallWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            percentageLabel.Text = "Installing mods: " + e.ProgressPercentage.ToString() + "%";
        }

        private void modInstallWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            percentageLabel.Text = "";
            MessageBox.Show("Selected mods applied.");
            button1.Enabled = true;
            button2.Enabled = true;
            openGameRoot.Enabled = true;
            openMods.Enabled = true;
            button7.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }
    }
}
