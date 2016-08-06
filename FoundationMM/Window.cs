using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Linq;

using Ini;
using System.Drawing;

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

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        private void Window_Load(object sender, EventArgs e)
        {
            // attempt double buffering on OSes that support it.
            try
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetDoubleBuffered(listView1);
                SetDoubleBuffered(listView2);
                SetDoubleBuffered(infobarDesc);
                SetDoubleBuffered(infobar2Desc);
            }
            catch
            {
                // lol okay then
                // if that's how you want to be
            }

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
            string identifier = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.ini");
            string langIdentifier = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm_lang.ini");
#if !DEBUG
            if (!File.Exists(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mtndew.dll")))
            {
                MessageBox.Show("The FMM zip should be extracted to the root of your ElDewrito directory.");

                Application.Exit();
                return;
            }

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

            refreshMods.ToolTipText = "Reloads the current tab's mod list.";

            //languages
            if (!File.Exists(langIdentifier))
            {
                IniFile ini = new IniFile(langIdentifier);
                ini.IniWriteValue("FMMLang", "Tab_MyMods", tabPage1.Text);
                ini.IniWriteValue("FMMLang", "Tab_DownloadableMods", tabPage2.Text);
                ini.IniWriteValue("FMMLang", "GroupBox_Mods", groupBox1.Text);
                ini.IniWriteValue("FMMLang", "GroupBox_Directories", groupBox2.Text);
                ini.IniWriteValue("FMMLang", "GroupBox_DeveloperMode", devModeGroupBox.Text);
                ini.IniWriteValue("FMMLang", "GroupBox_Game", groupBox3.Text);
                ini.IniWriteValue("FMMLang", "Button_IncreasePriority", button1.Text);
                ini.IniWriteValue("FMMLang", "Button_DecreasePriority", button2.Text);
                ini.IniWriteValue("FMMLang", "Button_DeleteSelectedMod", button7.Text);
                ini.IniWriteValue("FMMLang", "Button_OpenGameFolder", openGameRoot.Text);
                ini.IniWriteValue("FMMLang", "Button_OpenModsFolder", openMods.Text);
                ini.IniWriteValue("FMMLang", "Button_EnableFileRestoration", lang_EnableFileRestoration);
                ini.IniWriteValue("FMMLang", "Button_DisableFileRestoration", lang_DisableFileRestoration);
                ini.IniWriteValue("FMMLang", "Button_EnableCMDWindows", lang_EnableCMDWindows);
                ini.IniWriteValue("FMMLang", "Button_DisableCMDWindows", lang_DisableCMDWindows);
                ini.IniWriteValue("FMMLang", "Button_ApplyCheckedMods", button5.Text);
                ini.IniWriteValue("FMMLang", "Button_LaunchElDewrito", button6.Text);
                ini.IniWriteValue("FMMLang", "Button_DownloadCheckedMods", button16.Text);
                ini.IniWriteValue("FMMLang", "ToolTip_IncreasePriority", "Higher priority installs a mod later.\nThis means it can overwrite changes from other mods.");
                ini.IniWriteValue("FMMLang", "ToolTip_DecreasePriority", "Lower priority installs a mod earlier.\nThis means other mods can overwrite its changes.");
                ini.IniWriteValue("FMMLang", "ToolTip_DeleteSelectedMod", "Deletes a selected mod's installer files.\nIf installed, the mod will be removed from your game next time you apply.");
                ini.IniWriteValue("FMMLang", "ToolTip_OpenGameFolder", "Opens your Halo Online root directory.");
                ini.IniWriteValue("FMMLang", "ToolTip_OpenModsFolder", "Opens your FMM mods directory.");
                ini.IniWriteValue("FMMLang", "ToolTip_ApplyCheckedMods", "Installs checked mods to your Halo Online installation.");
                ini.IniWriteValue("FMMLang", "ToolTip_LaunchElDewrito", "Opens 'eldorado.exe' from FMM's current directory.");
                ini.IniWriteValue("FMMLang", "ToolTip_DownloadCheckedMods", "Downloads checked mods to your 'My Mods' list.");
                ini.IniWriteValue("FMMLang", "ToolTip_Refresh", "Reloads the current tab's mod list.");
                ini.IniWriteValue("FMMLang", "Header_Name", header_Name.Text);
                ini.IniWriteValue("FMMLang", "Header_Author", header_Author.Text);
                ini.IniWriteValue("FMMLang", "Header_Version", header_Version.Text);
                ini.IniWriteValue("FMMLang", "Header_Description", header_Description.Text);
                ini.IniWriteValue("FMMLang", "Header_Warnings", header_Warnings.Text);
                ini.IniWriteValue("FMMLang", "Header_Location", header_Location.Text);
                ini.IniWriteValue("FMMLang", "String_ModAvailable", lang_ModAvailable);
                ini.IniWriteValue("FMMLang", "String_ModsAvailable", lang_ModsAvailable);
            }
            else
            {
                IniFile ini = new IniFile(langIdentifier);
                tabPage1.Text = ini.IniReadValue("FMMLang", "Tab_MyMods");
                tabPage2.Text = ini.IniReadValue("FMMLang", "Tab_DownloadableMods");
                groupBox1.Text = ini.IniReadValue("FMMLang", "GroupBox_Mods");
                groupBox7.Text = ini.IniReadValue("FMMLang", "GroupBox_Mods");
                groupBox2.Text = ini.IniReadValue("FMMLang", "GroupBox_Directories");
                devModeGroupBox.Text = ini.IniReadValue("FMMLang", "GroupBox_DeveloperMode");
                groupBox3.Text = ini.IniReadValue("FMMLang", "GroupBox_Game");
                button1.Text = ini.IniReadValue("FMMLang", "Button_IncreasePriority");
                button2.Text = ini.IniReadValue("FMMLang", "Button_DecreasePriority");
                button7.Text = ini.IniReadValue("FMMLang", "Button_DeleteSelectedMod");
                openGameRoot.Text = ini.IniReadValue("FMMLang", "Button_OpenGameFolder");
                openMods.Text = ini.IniReadValue("FMMLang", "Button_OpenModsFolder");
                lang_EnableFileRestoration = ini.IniReadValue("FMMLang", "Button_EnableFileRestoration");
                lang_DisableFileRestoration = ini.IniReadValue("FMMLang", "Button_DisableFileRestoration");
                toggleFileRestoration.Text = ini.IniReadValue("FMMLang", "Button_DisableFileRestoration");
                lang_EnableCMDWindows = ini.IniReadValue("FMMLang", "Button_EnableCMDWindows");
                toggleCmdWindows.Text = ini.IniReadValue("FMMLang", "Button_EnableCMDWindows");
                lang_DisableCMDWindows = ini.IniReadValue("FMMLang", "Button_DisableCMDWindows");
                button5.Text = ini.IniReadValue("FMMLang", "Button_ApplyCheckedMods");
                button6.Text = ini.IniReadValue("FMMLang", "Button_LaunchElDewrito");
                button16.Text = ini.IniReadValue("FMMLang", "Button_DownloadCheckedMods");
                incPriToolTip.SetToolTip(this.button1, ini.IniReadValue("FMMLang", "ToolTip_IncreasePriority"));
                topPriToolTip.SetToolTip(this.button3, ini.IniReadValue("FMMLang", "ToolTip_IncreasePriority"));
                decPriToolTip.SetToolTip(this.button2, ini.IniReadValue("FMMLang", "ToolTip_DecreasePriority"));
                botPriToolTip.SetToolTip(this.button4, ini.IniReadValue("FMMLang", "ToolTip_DecreasePriority"));
                deleteToolTip.SetToolTip(this.button7, ini.IniReadValue("FMMLang", "ToolTip_DeleteSelectedMod"));
                rootDirToolTip.SetToolTip(this.openGameRoot, ini.IniReadValue("FMMLang", "ToolTip_OpenGameFolder"));
                modsDirToolTip.SetToolTip(this.openMods, ini.IniReadValue("FMMLang", "ToolTip_OpenModsFolder"));
                applyToolTip.SetToolTip(this.button5, ini.IniReadValue("FMMLang", "ToolTip_ApplyCheckedMods"));
                launchToolTip.SetToolTip(this.button6, ini.IniReadValue("FMMLang", "ToolTip_LaunchElDewrito"));
                dlToolTip.SetToolTip(this.button16, ini.IniReadValue("FMMLang", "ToolTip_DownloadCheckedMods"));
                refreshMods.ToolTipText = ini.IniReadValue("FMMLang", "ToolTip_Refresh");
                header_Name.Text = ini.IniReadValue("FMMLang", "Header_Name");
                header_Author.Text = ini.IniReadValue("FMMLang", "Header_Author");
                header_Version.Text = ini.IniReadValue("FMMLang", "Header_Version");
                header_Description.Text = ini.IniReadValue("FMMLang", "Header_Description");
                header_Warnings.Text = ini.IniReadValue("FMMLang", "Header_Warnings");
                header_Location.Text = ini.IniReadValue("FMMLang", "Header_Location");
                columnHeader1.Text = ini.IniReadValue("FMMLang", "Header_Name");
                columnHeader2.Text = ini.IniReadValue("FMMLang", "Header_Author");
                columnHeader3.Text = ini.IniReadValue("FMMLang", "Header_Version");
                columnHeader4.Text = ini.IniReadValue("FMMLang", "Header_Description");
                columnHeader5.Text = ini.IniReadValue("FMMLang", "Header_Warnings");
                columnHeader6.Text = ini.IniReadValue("FMMLang", "Header_Location");
                lang_ModAvailable = ini.IniReadValue("FMMLang", "String_ModAvailable");
                lang_ModsAvailable = ini.IniReadValue("FMMLang", "String_ModsAvailable");
            }

#endif
            IniFile ini2 = new IniFile(identifier);

            Log("Looking for installers...");
            lookForFMMInstallers();
            Log("Adding installers to list...");
            addFMMInstallersToList();
            Log("Ordering installers as saved...");
            checkFMMInstallerOrder();
            
            if (ini2.IniReadValue("FMMPrefs", "OfflineMode").ToLower() != "true")
            {
                Log("Downloading mod list...");
                refreshinprog = true;
                dlFilesWorker.RunWorkerAsync(new string[] { Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mods", "tagmods") });
            }

            if (ini2.IniReadValue("FMMPrefs", "OfflineMode").ToLower() == "true")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.Appearance = TabAppearance.Buttons;
                tabControl1.ItemSize = new Size(0, 1);
                tabControl1.SizeMode = TabSizeMode.Fixed;
                tabControl1.Margin = new Padding(0, 0, 0, 0);
            }

            Log("Counting available mods...");

            int modCount = listView1.Items.Count;
            if (modCount == 1)
            {
                modNumberLabel.Text = "1 " + lang_ModAvailable;
            }
            else
            {
                modNumberLabel.Text = modCount + " " + lang_ModsAvailable;
            }

            infobar.Visible = false;
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
                modNumberLabel.Text = "1 " + lang_ModAvailable;
            }
            else
            {
                modNumberLabel.Text = modCount + " " + lang_ModsAvailable;
            }

            infobar.Visible = false;
            infobar2.Visible = false;
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
