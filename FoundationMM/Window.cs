﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ini;
using System.Diagnostics;
using System.Threading;

namespace FoundationMM
{
    public partial class Window : Form
    {
        string[] files = {
                    @"fonts\font_package.bin",
                    "audio.dat",
                    "bunkerworld.map",
                    "chill.map",
                    "cyberdyne.map",
                    "deadlock.map",
                    "guardian.map",
                    "mainmenu.map",
                    "resources.dat",
                    "riverworld.map",
                    "s3d_avalanche.map",
                    "s3d_edge.map",
                    "s3d_reactor.map",
                    "s3d_turf.map",
                    "shrine.map",
                    "string_ids.dat",
                    "tags.dat",
                    "textures.dat",
                    "textures_b.dat",
                    "video.dat",
                    "zanzibar.map"
                };

        List<string> locatedFMMInstallers = new List<string>();

        public Window()
        {
            InitializeComponent();
        }

        BackgroundWorker deleteOldBackupWorker = new BackgroundWorker();
        BackgroundWorker fileTransferWorker = new BackgroundWorker();
        BackgroundWorker modInstallWorker = new BackgroundWorker();
        BackgroundWorker restoreCleanWorker = new BackgroundWorker();

        private void Form1_Load(object sender, EventArgs e)
        {
            deleteOldBackupWorker.WorkerSupportsCancellation = true;
            deleteOldBackupWorker.DoWork += new DoWorkEventHandler(deleteOldBackup_DoWork);

            fileTransferWorker.WorkerSupportsCancellation = true;
            fileTransferWorker.WorkerReportsProgress = true;
            fileTransferWorker.DoWork += new DoWorkEventHandler(fileTransferWorker_DoWork);
            fileTransferWorker.ProgressChanged += new ProgressChangedEventHandler(fileTransferWorker_ProgressChanged);
            fileTransferWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(fileTransferWorker_RunWorkerCompleted);

            modInstallWorker.WorkerSupportsCancellation = true;
            modInstallWorker.WorkerReportsProgress = true;
            modInstallWorker.DoWork += new DoWorkEventHandler(modInstallWorker_DoWork);
            modInstallWorker.ProgressChanged += new ProgressChangedEventHandler(modInstallWorker_ProgressChanged);
            modInstallWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(modInstallWorker_RunWorkerCompleted);

            restoreCleanWorker.WorkerSupportsCancellation = true;
            restoreCleanWorker.WorkerReportsProgress = true;
            restoreCleanWorker.DoWork += new DoWorkEventHandler(restoreCleanWorker_DoWork);
            restoreCleanWorker.ProgressChanged += new ProgressChangedEventHandler(restoreCleanWorker_ProgressChanged);
            restoreCleanWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(restoreCleanWorker_RunWorkerCompleted);

            DirectoryInfo dir0 = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "mods", "tagmods"));
#if !DEBUG
            if (!File.Exists(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mtndew.dll")))
            {
                MessageBox.Show("The FMM zip should be extracted to the root of your ElDewrito directory.");

                Application.Exit();
                return;
            }

            string identifier = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.ini");
            if (!File.Exists(identifier))
            {
                IniFile ini = new IniFile(identifier);
                FileVersionInfo mtndewVersion = FileVersionInfo.GetVersionInfo(Path.Combine(Directory.GetCurrentDirectory(), "mtndew.dll"));
                ini.IniWriteValue("FMMPrefs", "EDVersion", mtndewVersion.FileVersion);
            }
            else
            {
                IniFile ini = new IniFile(identifier);
                string savedversion = ini.IniReadValue("FMMPrefs", "EDVersion");
                string actualversion = FileVersionInfo.GetVersionInfo(Path.Combine(Directory.GetCurrentDirectory(), "mtndew.dll")).FileVersion;

                if (savedversion != actualversion)
                {
                    string mapsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "maps");
                    deleteOldBackupWorker.RunWorkerAsync(new string[] { mapsPath });
                    ini.IniWriteValue("FMMPrefs", "EDVersion", actualversion);
                }
            }

#endif

            lookForFMMInstallers();
            addFMMInstallersToList();
            checkFMMInstallerOrder();

            
            int modCount = listView1.Items.Count;
            if (modCount == 1)
            {
                modNumberLabel.Text = "1 mod available";
            }
            else
            {
                modNumberLabel.Text = modCount + " mods available";
            }
        }

        private void deleteOldBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] args = (string[])e.Argument;
            string mapsPath = args[0];


            BackgroundWorker worker = sender as BackgroundWorker;
            if (File.Exists(Path.Combine(mapsPath, "fmmbak", "tags.dat")))
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
                        File.Delete(Path.Combine(mapsPath, "fmmbak", file));
                    }
                }
            }
        }

        private void lookForFMMInstallers()
        {
            string modsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mods", "tagmods");
            processDirectory(modsPath);
        }
        
        private void processDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                processFile(fileName);
            
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                processDirectory(subdirectory);
        }

        private void processFile(string path)
        {
            if (Path.GetExtension(path) == ".fm")
            {
                locatedFMMInstallers.Add(path);
            }
        }

        private void addFMMInstallersToList()
        {
            foreach (string fmfile in locatedFMMInstallers)
            {
                string location = Path.GetDirectoryName(fmfile);
                string identifier = Path.Combine(location, Path.GetFileNameWithoutExtension(fmfile) + ".ini");
                if (File.Exists(identifier))
                {
                    IniFile ini = new IniFile(identifier);
                    string modName = ini.IniReadValue("FMMInfo", "Name");
                    string modAuthor = ini.IniReadValue("FMMInfo", "Author");
                    string modDesc = ini.IniReadValue("FMMInfo", "Desc");

                    string modLocation = fmfile.Replace(Path.Combine(Directory.GetCurrentDirectory(), "mods\\"), "");
                    listView1.Items.Add(new ListViewItem(new[] { modName, modAuthor, modDesc, modLocation }));
                }
            }
        }

        private void checkFMMInstallerOrder()
        {
            string fmmdat = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.dat");
            if (File.Exists(fmmdat))
            {
                IEnumerable<string> lines = File.ReadLines(fmmdat);
                foreach (string modName in lines)
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.SubItems[0].Text == modName)
                        {
                            try
                            {
                                listView1.Items.Remove(item);
                                listView1.Items.Insert(0, item);
                                item.Checked = true;
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        private void launchDewritoClick(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "eldorado.exe"), "-launcher");
        }

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

        private void upClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selected = listView1.SelectedItems[0];
                    int indx = selected.Index;

                    if (indx != 0)
                    {
                        listView1.Items.Remove(selected);
                        listView1.Items.Insert(indx - 1, selected);
                        listView1.Items[indx - 1].Selected = true;
                        listView1.Select();
                    }
                }
            }
            catch {}
        }

        private void downClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selected = listView1.SelectedItems[0];
                    int indx = selected.Index;
                    int totl = listView1.Items.Count;

                    if (indx != totl - 1)
                    {
                        listView1.Items.Remove(selected);
                        listView1.Items.Insert(indx + 1, selected);
                        listView1.Items[indx + 1].Selected = true;
                        listView1.Select();
                    }
                }
            }
            catch {}
        }

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
                        File.Copy(Path.Combine(mapsPath, "fmmbak", file), Path.Combine(mapsPath, file), true);
                        i++;
                    float progress = ((float)i / (float)files.Count()) * 100;
                    worker.ReportProgress(Convert.ToInt32(progress));
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
                button7.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
            }
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

        private void openModsButton(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mods", "tagmods"));
        }

        private void openGameRootButton(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", System.IO.Directory.GetCurrentDirectory());
        }
    }
}
