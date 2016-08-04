using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Linq;

using Ini;

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
        BackgroundWorker dlFilesWorker = new BackgroundWorker();
        BackgroundWorker dlModWorkerStarter = new BackgroundWorker();
        BackgroundWorker dlModWorker = new BackgroundWorker();

        bool refreshinprog = false;

        private void Window_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
            listView1.AllowDrop = true;

            outputPanel.Dock = DockStyle.Fill;
            
            ToolTip incPriToolTip = new ToolTip();
            incPriToolTip.SetToolTip(this.button1, "Higher priority installs a mod later.\nThis means it can overwrite changes from other mods.");
            ToolTip topPriToolTip = new ToolTip();
            topPriToolTip.SetToolTip(this.button3, "Higher priority installs a mod later.\nThis means it can overwrite changes from other mods.");
            ToolTip decPriToolTip = new ToolTip();
            decPriToolTip.SetToolTip(this.button2, "Lower priority installs a mod earlier.\nThis means other mods can overwrite its changes.");
            ToolTip botPriToolTip = new ToolTip();
            botPriToolTip.SetToolTip(this.button4, "Lower priority installs a mod earlier.\nThis means other mods can overwrite its changes.");
            ToolTip deleteToolTip = new ToolTip();
            deleteToolTip.SetToolTip(this.button7, "Deletes a selected mod's installer files.\nIf installed, the mod will be removed from your game next time you apply.");
            ToolTip rootDirToolTip = new ToolTip();
            rootDirToolTip.SetToolTip(this.openGameRoot, "Opens your Halo Online root directory.");
            ToolTip modsDirToolTip = new ToolTip();
            modsDirToolTip.SetToolTip(this.openMods, "Opens your FMM mods directory.");
            ToolTip applyToolTip = new ToolTip();
            applyToolTip.SetToolTip(this.button5, "Installs checked mods to your Halo Online installation.");
            ToolTip launchToolTip = new ToolTip();
            launchToolTip.SetToolTip(this.button6, "Opens 'eldorado.exe' from FMM's current directory.");
            ToolTip dlToolTip = new ToolTip();
            dlToolTip.SetToolTip(this.button16, "Downloads checked mods to your 'My Mods' list.");


            deleteOldBackupWorker.WorkerSupportsCancellation = true;
            deleteOldBackupWorker.DoWork += new DoWorkEventHandler(deleteOldBackup_DoWork);

            dlModWorkerStarter.WorkerSupportsCancellation = true;
            dlModWorkerStarter.WorkerReportsProgress = true;
            dlModWorkerStarter.DoWork += new DoWorkEventHandler(dlModWorkerStarter_DoWork);
            dlModWorkerStarter.ProgressChanged += new ProgressChangedEventHandler(dlModWorkerStarter_ProgressChanged);
            dlModWorkerStarter.RunWorkerCompleted += new RunWorkerCompletedEventHandler(dlModWorkerStarter_RunWorkerCompleted);

            dlModWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(dlModWorker_RunWorkerCompleted);
            dlModWorker.WorkerSupportsCancellation = true;
            dlModWorker.WorkerReportsProgress = true;
            dlModWorker.DoWork += new DoWorkEventHandler(dlModWorker_DoWork);

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

            dlFilesWorker.WorkerSupportsCancellation = true;
            dlFilesWorker.WorkerReportsProgress = true;
            dlFilesWorker.DoWork += new DoWorkEventHandler(dlFilesWorker_DoWork);
            dlFilesWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(dlFilesWorker_RunWorkerCompleted);


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

                Form thisForm = (Form)sender;
                thisForm.Width = Convert.ToInt32(ini.IniReadValue("FMMPrefs", "Width"));
                thisForm.Height = Convert.ToInt32(ini.IniReadValue("FMMPrefs", "Height"));
                if (ini.IniReadValue("FMMPrefs", "DevMode").ToLower() == "true")
                {
                    devModeGroupBox.Visible = true;
                }

                string savedversion = ini.IniReadValue("FMMPrefs", "EDVersion");
                string actualversion = FileVersionInfo.GetVersionInfo(Path.Combine(Directory.GetCurrentDirectory(), "mtndew.dll")).FileVersion;

                if (savedversion != actualversion)
                {
                    string mapsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "maps");
                    deleteOldBackupWorker.RunWorkerAsync(new string[] { mapsPath });
                    ini.IniWriteValue("FMMPrefs", "EDVersion", actualversion);
                    showMessageBox("You appear to have updated ElDorito. Please reinstall mods you wish to keep using.");
                }
            }

#endif

            Log("Looking for installers...");
            lookForFMMInstallers();
            Log("Adding installers to list...");
            addFMMInstallersToList();
            Log("Ordering installers as saved...");
            checkFMMInstallerOrder();

            Log("Downloading mod list...");
            refreshinprog = true;
            dlFilesWorker.RunWorkerAsync(new string[] { Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mods", "tagmods") });
            

            Log("Counting available mods...");
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

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tabControl1.Enabled == false)
            {
                DialogResult dialogResult = MessageBox.Show("FMM is working, and cancelling may leave critical files corrupt or missing.\n\nAre you sure you want to cancel?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (dialogResult == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

            Form thisForm = (Form)sender;
            string identifier = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.ini");
            if (File.Exists(identifier))
            {
                IniFile ini = new IniFile(identifier);
                ini.IniWriteValue("FMMPrefs", "Width", thisForm.Width.ToString());
                ini.IniWriteValue("FMMPrefs", "Height", thisForm.Height.ToString());
            }
        }

        int enabledTab = 0;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            enabledTab = tabControl1.SelectedIndex;
            int modCount = 0;
            if (enabledTab == 0)
            {
                refreshMods.Visible = true;
                modNumberLabel.Visible = true;
                modCount = listView1.Items.Count;
            }
            else if (enabledTab == 1)
            {
                refreshMods.Visible = true;
                modNumberLabel.Visible = true;
                modCount = listView2.Items.Count;
            }
            else if (enabledTab == 2)
            {
                refreshMods.Visible = false;
                modNumberLabel.Visible = false;
            }

            if (modCount == 1)
            {
                modNumberLabel.Text = "1 mod available";
            }
            else
            {
                modNumberLabel.Text = modCount + " mods available";
            }
        }

        bool listView1DND = false;
        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (listView1DND) { return; }
            if (((Control.ModifierKeys & Keys.Shift) != 0))
            {
                listView1DND = true;
                e.NewValue = e.CurrentValue;
                if (listView1.CheckedItems.Count == listView1.Items.Count)
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        item.Checked = false;
                    }
                }
                else
                {
                    foreach (ListViewItem item in listView1.Items)
                    {
                        item.Checked = true;
                    }
                }
            }
            listView1DND = false;
        }

        bool listView2DND = false;
        private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (listView2DND) { return; }
            if (((Control.ModifierKeys & Keys.Shift) != 0))
            {
                listView2DND = true;
                e.NewValue = e.CurrentValue;
                if (listView2.CheckedItems.Count == listView2.Items.Count)
                {
                    foreach (ListViewItem item in listView2.Items)
                    {
                        item.Checked = false;
                    }
                }
                else
                {
                    foreach (ListViewItem item in listView2.Items)
                    {
                        item.Checked = true;
                    }
                }
            }
            listView2DND = false;
        }

        private int sortColumn1 = -1;

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn1)
            {
                sortColumn1 = e.Column;
                listView1.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (listView1.Sorting == SortOrder.Ascending)
                {
                    listView1.Sorting = SortOrder.Descending;
                }
                else
                {
                    listView1.Sorting = SortOrder.Ascending;
                }
            }
            
            listView1.Sort();
            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.Sorting);
            checkFMMInstallerOrder();
        }

        private int sortColumn2 = -1;

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn2)
            {
                sortColumn2 = e.Column;
                listView2.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (listView2.Sorting == SortOrder.Ascending)
                {
                    listView2.Sorting = SortOrder.Descending;
                }
                else
                {
                    listView2.Sorting = SortOrder.Ascending;
                }
            }

            listView2.Sort();
            listView2.ListViewItemSorter = new ListViewItemComparer(e.Column, listView2.Sorting);
            checkFMMInstallerOrder();
        }

        private void outputPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
