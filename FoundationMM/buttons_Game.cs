using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        bool isRestoringVsBackingUp = false;

        private void launchDewritoClick(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "eldorado.exe")))
            {
                Process.Start(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "eldorado.exe"), "-launcher");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Cannot find eldorado.exe. If it has been renamed, FMM cannot run ElDewrito for you.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void applyClick(object sender, EventArgs e)
        {
            infobar.Visible = false;
            if (listView1.CheckedItems.Count == 0)
            {
                string fmmdat = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.dat");
                FileStream fmmdatWiper = File.Open(fmmdat, FileMode.OpenOrCreate);
                fmmdatWiper.SetLength(0);
                fmmdatWiper.Close();

                string mapsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "maps");
                DirectoryInfo dir1 = Directory.CreateDirectory(Path.Combine(mapsPath, "fmmbak"));
                DirectoryInfo dir2 = Directory.CreateDirectory(Path.Combine(mapsPath, "fmmbak", "fonts"));
                DirectoryInfo dir3 = Directory.CreateDirectory(Path.Combine(mapsPath, "fonts"));

                isRestoringVsBackingUp = false;

                if (File.Exists(Path.Combine(mapsPath, "fmmbak", "tags.dat")))
                {
                    if (restoreCleanWorker.IsBusy != true || !isFileLocked(new FileInfo(Path.Combine(mapsPath, "tags.dat"))))
                    {
                        button1.Enabled = false;
                        button2.Enabled = false;
                        openGameRoot.Enabled = false;
                        openMods.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        statusStrip1.Invoke((MethodInvoker)delegate { refreshMods.Enabled = false; });
                        restoreCleanWorker.RunWorkerAsync(new string[] { mapsPath });
                    }
                }
                else
                {
                    MessageBox.Show("No clean files stored.");
                }
            }
            else
            {
                DialogResult confirmApply = MessageBox.Show("Are you sure you want to apply these mods?\nMods downloaded from unsafe locations may harm your computer.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmApply == DialogResult.No) { return; }

                string mapsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "maps");

                // Backup tags and stuff
                DirectoryInfo dir1 = Directory.CreateDirectory(Path.Combine(mapsPath, "fmmbak"));
                DirectoryInfo dir2 = Directory.CreateDirectory(Path.Combine(mapsPath, "fmmbak", "fonts"));
                DirectoryInfo dir3 = Directory.CreateDirectory(Path.Combine(mapsPath, "fonts"));

                isRestoringVsBackingUp = false;

                if (File.Exists(Path.Combine(mapsPath, "fmmbak", "tags.dat")))
                {
                    isRestoringVsBackingUp = true;
                }

                if (fileTransferWorker.IsBusy != true || !isFileLocked(new FileInfo(Path.Combine(mapsPath, "tags.dat"))))
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    openGameRoot.Enabled = false;
                    openMods.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    tabControl1.Enabled = false;
                    statusStrip1.Invoke((MethodInvoker)delegate { refreshMods.Enabled = false; });
                    fileTransferWorker.RunWorkerAsync(new string[] { mapsPath });
                }
            }
        }

        private bool isFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
    }
}
