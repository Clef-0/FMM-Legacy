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
        bool showInstallers = false;

        private void modInstallWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            outputPanel.Invoke((MethodInvoker)delegate { outputPanel.Visible = true; });
            
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
                string fmFile = Path.Combine(Directory.GetCurrentDirectory(), "mods", item.SubItems[5].Text);
                string batFile = Path.Combine(Path.GetDirectoryName(fmFile), "fm_temp.bat");

                try
                {
                    // duplicate .fm as temp .bat installer.
                    File.Copy(fmFile, batFile, true);

                    // startInfo for installer
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    if (showInstallers == false)
                    {
                        startInfo.CreateNoWindow = true;
                        startInfo.UseShellExecute = false;
                        startInfo.RedirectStandardOutput = true;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    }
                    startInfo.FileName = batFile;
                    startInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory();

                    textBox1.Invoke(new appendNewOutputCallback(this.appendNewOutput), new object[] { "[" + item.SubItems[0].Text + "]" });

                    // start installer
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        if (startInfo.RedirectStandardOutput == true)
                        {
                            string standard_output;
                            while (!exeProcess.StandardOutput.EndOfStream)
                            {
                                standard_output = exeProcess.StandardOutput.ReadLine();
                                if (standard_output.StartsWith("FMM_OUTPUT "))
                                {
                                    standard_output = standard_output.Trim().Replace("FMM_OUTPUT ", "");
                                    textBox1.Invoke(new appendNewOutputCallback(this.appendNewOutput), new object[] { standard_output });
                                }
                                else if (standard_output.StartsWith("FMM_ALERT "))
                                {
                                    standard_output = standard_output.Trim().Replace("FMM_ALERT ", "");
                                    Invoke(new showMessageBoxCallback(this.showMessageBox), new object[] { standard_output });
                                }
                            }
                        }

                        exeProcess.WaitForExit();
                    }

                    i++;
                    float progress = ((float)i / (float)listView1.CheckedItems.Cast<ListViewItem>().Count()) * 100;
                    worker.ReportProgress(Convert.ToInt32(progress));
                }
                catch (Exception ex)
                {
                    FlashWindowEx(this);
                    MessageBox.Show("Error installing " + item.SubItems[0].Text + ".\nPlease consult the #eldorito IRC for help.\n\n\"" + ex.Message + "\"", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    File.Delete(batFile);
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
            FlashWindowEx(this);
            MessageBox.Show("Selected mods applied.");
            textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = ""; });
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            openGameRoot.Enabled = true;
            openMods.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            outputPanel.Visible = false;
            tabControl1.Enabled = true;
            statusStrip1.Invoke((MethodInvoker)delegate { refreshMods.Enabled = true; });
        }
    }
}
