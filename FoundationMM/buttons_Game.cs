using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        private void launchDewritoClick(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "eldorado.exe"), "-launcher");
        }

        private void applyClick(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count == 0) { return; }

            DialogResult confirmApply = MessageBox.Show("Are you sure you want to apply these mods?\nMods downloaded from unsafe locations may harm your computer.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmApply == DialogResult.No) { return; }

            string mapsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "maps");

            // Backup tags and stuff
            DirectoryInfo dir1 = Directory.CreateDirectory(Path.Combine(mapsPath, "fmmbak"));
            DirectoryInfo dir2 = Directory.CreateDirectory(Path.Combine(mapsPath, "fmmbak", "fonts"));
            DirectoryInfo dir3 = Directory.CreateDirectory(Path.Combine(mapsPath, "fonts"));


            if (fileTransferWorker.IsBusy != true || !IsFileLocked(new FileInfo(Path.Combine(mapsPath, "tags.dat"))))
            {
                button1.Enabled = false;
                button2.Enabled = false;
                openGameRoot.Enabled = false;
                openMods.Enabled = false;
                button7.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                fileTransferWorker.RunWorkerAsync(new string[] { mapsPath });
            }
        }

        public bool IsFileLocked(FileInfo file)
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

        private void cleanClick(object sender, EventArgs e)
        {
            string fmmdat = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.dat");
            FileStream fmmdatWiper = File.Open(fmmdat, FileMode.OpenOrCreate);
            fmmdatWiper.SetLength(0);
            fmmdatWiper.Close();

            string mapsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "maps");
            DirectoryInfo dir1 = Directory.CreateDirectory(Path.Combine(mapsPath, "fmmbak"));
            DirectoryInfo dir2 = Directory.CreateDirectory(Path.Combine(mapsPath, "fmmbak", "fonts"));
            DirectoryInfo dir3 = Directory.CreateDirectory(Path.Combine(mapsPath, "fonts"));
            if (File.Exists(Path.Combine(mapsPath, "fmmbak", "tags.dat")))
            {
                if (restoreCleanWorker.IsBusy != true || !IsFileLocked(new FileInfo(Path.Combine(mapsPath, "tags.dat"))))
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    openGameRoot.Enabled = false;
                    openMods.Enabled = false;
                    button7.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    restoreCleanWorker.RunWorkerAsync(new string[] { mapsPath });
                }
            }
            else
            {
                MessageBox.Show("No clean files stored.");
            }
        }
    }
}
