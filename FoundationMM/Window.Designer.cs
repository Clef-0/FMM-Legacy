namespace FoundationMM
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.listView1 = new System.Windows.Forms.ListView();
            this.header_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header_Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header_Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header_Warnings = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header_Location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.devModeGroupBox = new System.Windows.Forms.GroupBox();
            this.toggleCmdWindows = new System.Windows.Forms.Button();
            this.toggleFileRestoration = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openGameRoot = new System.Windows.Forms.Button();
            this.openMods = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.refreshMods = new System.Windows.Forms.ToolStripSplitButton();
            this.modNumberLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.percentageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.infobar = new System.Windows.Forms.TableLayoutPanel();
            this.infobarIcon = new System.Windows.Forms.Panel();
            this.infobarLPane = new System.Windows.Forms.Panel();
            this.infobarCredits = new System.Windows.Forms.Label();
            this.infobarAuthor = new System.Windows.Forms.Label();
            this.infobarName = new System.Windows.Forms.Label();
            this.infobarRPane = new System.Windows.Forms.Panel();
            this.infobarDesc = new System.Windows.Forms.TextBox();
            this.infobarImage = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infobar2 = new System.Windows.Forms.TableLayoutPanel();
            this.infobar2Icon = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.infobar2Credits = new System.Windows.Forms.Label();
            this.infobar2Author = new System.Windows.Forms.Label();
            this.infobar2Name = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.infobar2Desc = new System.Windows.Forms.TextBox();
            this.infobar2Image = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.columnDL_downloads = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.devModeGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.outputPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.infobar.SuspendLayout();
            this.infobarLPane.SuspendLayout();
            this.infobarRPane.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.infobar2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.header_Name,
            this.header_Author,
            this.header_Version,
            this.header_Description,
            this.header_Warnings,
            this.header_Location});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(623, 391);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.Click += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // header_Name
            // 
            this.header_Name.Text = "Name";
            this.header_Name.Width = 150;
            // 
            // header_Author
            // 
            this.header_Author.Text = "Author";
            this.header_Author.Width = 90;
            // 
            // header_Version
            // 
            this.header_Version.Text = "Version";
            // 
            // header_Description
            // 
            this.header_Description.Text = "Description";
            this.header_Description.Width = 200;
            // 
            // header_Warnings
            // 
            this.header_Warnings.Text = "Warnings";
            this.header_Warnings.Width = 120;
            // 
            // header_Location
            // 
            this.header_Location.Text = "Location";
            this.header_Location.Width = 150;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.devModeGroupBox);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(623, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 463);
            this.panel1.TabIndex = 1;
            // 
            // devModeGroupBox
            // 
            this.devModeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.devModeGroupBox.Controls.Add(this.toggleCmdWindows);
            this.devModeGroupBox.Controls.Add(this.toggleFileRestoration);
            this.devModeGroupBox.Location = new System.Drawing.Point(3, 300);
            this.devModeGroupBox.Name = "devModeGroupBox";
            this.devModeGroupBox.Size = new System.Drawing.Size(152, 77);
            this.devModeGroupBox.TabIndex = 2;
            this.devModeGroupBox.TabStop = false;
            this.devModeGroupBox.Text = "Developer Mode";
            this.devModeGroupBox.Visible = false;
            // 
            // toggleCmdWindows
            // 
            this.toggleCmdWindows.Location = new System.Drawing.Point(6, 48);
            this.toggleCmdWindows.Name = "toggleCmdWindows";
            this.toggleCmdWindows.Size = new System.Drawing.Size(140, 23);
            this.toggleCmdWindows.TabIndex = 9;
            this.toggleCmdWindows.Text = "Enable CMD Windows";
            this.toggleCmdWindows.UseVisualStyleBackColor = true;
            this.toggleCmdWindows.Click += new System.EventHandler(this.toggleCmdWindows_Click);
            // 
            // toggleFileRestoration
            // 
            this.toggleFileRestoration.Location = new System.Drawing.Point(6, 19);
            this.toggleFileRestoration.Name = "toggleFileRestoration";
            this.toggleFileRestoration.Size = new System.Drawing.Size(140, 23);
            this.toggleFileRestoration.TabIndex = 8;
            this.toggleFileRestoration.Text = "Disable File Restoration";
            this.toggleFileRestoration.UseVisualStyleBackColor = true;
            this.toggleFileRestoration.Click += new System.EventHandler(this.toggleFileRestoration_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Location = new System.Drawing.Point(3, 383);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(152, 77);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Game";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Apply Checked Mods";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.applyClick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Launch ElDewrito";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.launchDewritoClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.openGameRoot);
            this.groupBox2.Controls.Add(this.openMods);
            this.groupBox2.Location = new System.Drawing.Point(3, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 77);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Directories";
            // 
            // openGameRoot
            // 
            this.openGameRoot.Location = new System.Drawing.Point(6, 19);
            this.openGameRoot.Name = "openGameRoot";
            this.openGameRoot.Size = new System.Drawing.Size(140, 23);
            this.openGameRoot.TabIndex = 6;
            this.openGameRoot.Text = "Open Game Folder";
            this.openGameRoot.UseVisualStyleBackColor = true;
            this.openGameRoot.Click += new System.EventHandler(this.openGameRootButton);
            // 
            // openMods
            // 
            this.openMods.Location = new System.Drawing.Point(6, 48);
            this.openMods.Name = "openMods";
            this.openMods.Size = new System.Drawing.Size(140, 23);
            this.openMods.TabIndex = 7;
            this.openMods.Text = "Open Mods Folder";
            this.openMods.UseVisualStyleBackColor = true;
            this.openMods.Click += new System.EventHandler(this.openModsButton);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mods";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 77);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Delete Selected Mod";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Image = global::FoundationMM.Properties.Resources.ico_down;
            this.button4.Location = new System.Drawing.Point(123, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 23);
            this.button4.TabIndex = 5;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.minPriority);
            // 
            // button3
            // 
            this.button3.Image = global::FoundationMM.Properties.Resources.ico_up;
            this.button3.Location = new System.Drawing.Point(123, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.maxPriority);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Decrease Priority";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.downClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Increase Priority";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.upClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshMods,
            this.modNumberLabel,
            this.toolStripStatusLabel1,
            this.percentageLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(789, 22);
            this.statusStrip1.TabIndex = 2;
            // 
            // refreshMods
            // 
            this.refreshMods.AutoToolTip = false;
            this.refreshMods.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshMods.DropDownButtonWidth = 0;
            this.refreshMods.Image = global::FoundationMM.Properties.Resources.ico_refresh;
            this.refreshMods.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshMods.Name = "refreshMods";
            this.refreshMods.Size = new System.Drawing.Size(21, 20);
            this.refreshMods.Click += new System.EventHandler(this.refreshModsClick);
            // 
            // modNumberLabel
            // 
            this.modNumberLabel.Name = "modNumberLabel";
            this.modNumberLabel.Size = new System.Drawing.Size(95, 17);
            this.modNumberLabel.Text = "0 mods available";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(658, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // percentageLabel
            // 
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(623, 226);
            this.textBox1.TabIndex = 0;
            // 
            // outputPanel
            // 
            this.outputPanel.Controls.Add(this.textBox1);
            this.outputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outputPanel.Location = new System.Drawing.Point(0, 165);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(623, 226);
            this.outputPanel.TabIndex = 4;
            this.outputPanel.Visible = false;
            this.outputPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.outputPanel_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(789, 489);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.outputPanel);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.infobar);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(781, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "My Mods";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // infobar
            // 
            this.infobar.BackColor = System.Drawing.SystemColors.Control;
            this.infobar.ColumnCount = 4;
            this.infobar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.infobar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.infobar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.infobar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.infobar.Controls.Add(this.infobarIcon, 0, 0);
            this.infobar.Controls.Add(this.infobarLPane, 1, 0);
            this.infobar.Controls.Add(this.infobarRPane, 2, 0);
            this.infobar.Controls.Add(this.infobarImage, 3, 0);
            this.infobar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infobar.Location = new System.Drawing.Point(0, 391);
            this.infobar.Name = "infobar";
            this.infobar.RowCount = 1;
            this.infobar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infobar.Size = new System.Drawing.Size(623, 72);
            this.infobar.TabIndex = 5;
            // 
            // infobarIcon
            // 
            this.infobarIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infobarIcon.Location = new System.Drawing.Point(0, 0);
            this.infobarIcon.Margin = new System.Windows.Forms.Padding(0);
            this.infobarIcon.Name = "infobarIcon";
            this.infobarIcon.Size = new System.Drawing.Size(72, 72);
            this.infobarIcon.TabIndex = 0;
            this.infobarIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.infobarIcon_MouseClick);
            // 
            // infobarLPane
            // 
            this.infobarLPane.Controls.Add(this.infobarCredits);
            this.infobarLPane.Controls.Add(this.infobarAuthor);
            this.infobarLPane.Controls.Add(this.infobarName);
            this.infobarLPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infobarLPane.Location = new System.Drawing.Point(75, 3);
            this.infobarLPane.Name = "infobarLPane";
            this.infobarLPane.Size = new System.Drawing.Size(183, 66);
            this.infobarLPane.TabIndex = 1;
            // 
            // infobarCredits
            // 
            this.infobarCredits.AutoSize = true;
            this.infobarCredits.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infobarCredits.Location = new System.Drawing.Point(3, 28);
            this.infobarCredits.MaximumSize = new System.Drawing.Size(130, 0);
            this.infobarCredits.Name = "infobarCredits";
            this.infobarCredits.Size = new System.Drawing.Size(81, 13);
            this.infobarCredits.TabIndex = 2;
            this.infobarCredits.Text = "infobarCredits";
            // 
            // infobarAuthor
            // 
            this.infobarAuthor.AutoSize = true;
            this.infobarAuthor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infobarAuthor.Location = new System.Drawing.Point(3, 15);
            this.infobarAuthor.Name = "infobarAuthor";
            this.infobarAuthor.Size = new System.Drawing.Size(81, 13);
            this.infobarAuthor.TabIndex = 1;
            this.infobarAuthor.Text = "infobarAuthor";
            // 
            // infobarName
            // 
            this.infobarName.AutoSize = true;
            this.infobarName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infobarName.Location = new System.Drawing.Point(3, 0);
            this.infobarName.Name = "infobarName";
            this.infobarName.Size = new System.Drawing.Size(80, 15);
            this.infobarName.TabIndex = 0;
            this.infobarName.Text = "infobarName";
            // 
            // infobarRPane
            // 
            this.infobarRPane.Controls.Add(this.infobarDesc);
            this.infobarRPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infobarRPane.Location = new System.Drawing.Point(264, 3);
            this.infobarRPane.Name = "infobarRPane";
            this.infobarRPane.Size = new System.Drawing.Size(225, 66);
            this.infobarRPane.TabIndex = 2;
            // 
            // infobarDesc
            // 
            this.infobarDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infobarDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infobarDesc.Location = new System.Drawing.Point(0, 0);
            this.infobarDesc.Multiline = true;
            this.infobarDesc.Name = "infobarDesc";
            this.infobarDesc.ReadOnly = true;
            this.infobarDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infobarDesc.Size = new System.Drawing.Size(225, 66);
            this.infobarDesc.TabIndex = 1;
            this.infobarDesc.Text = "infobarDesc";
            // 
            // infobarImage
            // 
            this.infobarImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infobarImage.Location = new System.Drawing.Point(492, 0);
            this.infobarImage.Margin = new System.Windows.Forms.Padding(0);
            this.infobarImage.Name = "infobarImage";
            this.infobarImage.Size = new System.Drawing.Size(131, 72);
            this.infobarImage.TabIndex = 3;
            this.infobarImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.infobarImage_MouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Controls.Add(this.infobar2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(781, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Downloadable Mods";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.AllowDrop = true;
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView2.CheckBoxes = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnDL_downloads,
            this.columnHeader6});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.ShowItemToolTips = true;
            this.listView2.Size = new System.Drawing.Size(623, 391);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView2_ColumnClick);
            this.listView2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView2_ItemCheck);
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.Click += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Version";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Warnings";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Location";
            this.columnHeader6.Width = 150;
            // 
            // infobar2
            // 
            this.infobar2.BackColor = System.Drawing.SystemColors.Control;
            this.infobar2.ColumnCount = 4;
            this.infobar2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.infobar2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.infobar2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.infobar2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.infobar2.Controls.Add(this.infobar2Icon, 0, 0);
            this.infobar2.Controls.Add(this.panel4, 1, 0);
            this.infobar2.Controls.Add(this.panel5, 2, 0);
            this.infobar2.Controls.Add(this.infobar2Image, 3, 0);
            this.infobar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infobar2.Location = new System.Drawing.Point(0, 391);
            this.infobar2.Name = "infobar2";
            this.infobar2.RowCount = 1;
            this.infobar2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infobar2.Size = new System.Drawing.Size(623, 72);
            this.infobar2.TabIndex = 6;
            this.infobar2.Visible = false;
            // 
            // infobar2Icon
            // 
            this.infobar2Icon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infobar2Icon.Location = new System.Drawing.Point(0, 0);
            this.infobar2Icon.Margin = new System.Windows.Forms.Padding(0);
            this.infobar2Icon.Name = "infobar2Icon";
            this.infobar2Icon.Size = new System.Drawing.Size(72, 72);
            this.infobar2Icon.TabIndex = 0;
            this.infobar2Icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.infobar2Icon_MouseClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.infobar2Credits);
            this.panel4.Controls.Add(this.infobar2Author);
            this.panel4.Controls.Add(this.infobar2Name);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(75, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(183, 66);
            this.panel4.TabIndex = 1;
            // 
            // infobar2Credits
            // 
            this.infobar2Credits.AutoSize = true;
            this.infobar2Credits.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infobar2Credits.Location = new System.Drawing.Point(3, 28);
            this.infobar2Credits.MaximumSize = new System.Drawing.Size(130, 0);
            this.infobar2Credits.Name = "infobar2Credits";
            this.infobar2Credits.Size = new System.Drawing.Size(87, 13);
            this.infobar2Credits.TabIndex = 2;
            this.infobar2Credits.Text = "infobar2Credits";
            // 
            // infobar2Author
            // 
            this.infobar2Author.AutoSize = true;
            this.infobar2Author.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infobar2Author.Location = new System.Drawing.Point(3, 15);
            this.infobar2Author.Name = "infobar2Author";
            this.infobar2Author.Size = new System.Drawing.Size(87, 13);
            this.infobar2Author.TabIndex = 1;
            this.infobar2Author.Text = "infobar2Author";
            // 
            // infobar2Name
            // 
            this.infobar2Name.AutoSize = true;
            this.infobar2Name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infobar2Name.Location = new System.Drawing.Point(3, 0);
            this.infobar2Name.Name = "infobar2Name";
            this.infobar2Name.Size = new System.Drawing.Size(87, 15);
            this.infobar2Name.TabIndex = 0;
            this.infobar2Name.Text = "infobar2Name";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.infobar2Desc);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(264, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(225, 66);
            this.panel5.TabIndex = 2;
            // 
            // infobar2Desc
            // 
            this.infobar2Desc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infobar2Desc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infobar2Desc.Location = new System.Drawing.Point(0, 0);
            this.infobar2Desc.Multiline = true;
            this.infobar2Desc.Name = "infobar2Desc";
            this.infobar2Desc.ReadOnly = true;
            this.infobar2Desc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infobar2Desc.Size = new System.Drawing.Size(225, 66);
            this.infobar2Desc.TabIndex = 1;
            this.infobar2Desc.Text = "infobar2Desc";
            // 
            // infobar2Image
            // 
            this.infobar2Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infobar2Image.Location = new System.Drawing.Point(492, 0);
            this.infobar2Image.Margin = new System.Windows.Forms.Padding(0);
            this.infobar2Image.Name = "infobar2Image";
            this.infobar2Image.Size = new System.Drawing.Size(131, 72);
            this.infobar2Image.TabIndex = 3;
            this.infobar2Image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.infobar2Image_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(623, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 463);
            this.panel2.TabIndex = 2;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button16);
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(152, 48);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Mods";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(6, 19);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(140, 23);
            this.button16.TabIndex = 2;
            this.button16.Text = "Download Checked Mods";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // columnDL_downloads
            // 
            this.columnDL_downloads.Text = "Users";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 511);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.Text = "Foundation Mod Manager v1.20 Infinity (for Halo Online)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.Load += new System.EventHandler(this.Window_Load);
            this.panel1.ResumeLayout(false);
            this.devModeGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.outputPanel.ResumeLayout(false);
            this.outputPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.infobar.ResumeLayout(false);
            this.infobarLPane.ResumeLayout(false);
            this.infobarLPane.PerformLayout();
            this.infobarRPane.ResumeLayout(false);
            this.infobarRPane.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.infobar2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader header_Name;
        private System.Windows.Forms.ColumnHeader header_Author;
        private System.Windows.Forms.ColumnHeader header_Description;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button openMods;
        private System.Windows.Forms.ToolStripStatusLabel modNumberLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ColumnHeader header_Location;
        private System.Windows.Forms.ToolStripStatusLabel percentageLabel;
        private System.Windows.Forms.Button openGameRoot;
        private System.Windows.Forms.ColumnHeader header_Warnings;
        private System.Windows.Forms.ColumnHeader header_Version;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox devModeGroupBox;
        private System.Windows.Forms.Button toggleFileRestoration;
        private System.Windows.Forms.Button toggleCmdWindows;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.ToolStripSplitButton refreshMods;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TableLayoutPanel infobar;
        private System.Windows.Forms.Panel infobarLPane;
        private System.Windows.Forms.Label infobarAuthor;
        private System.Windows.Forms.Label infobarName;
        private System.Windows.Forms.Panel infobarRPane;
        private System.Windows.Forms.TextBox infobarDesc;
        private System.Windows.Forms.Label infobarCredits;
        private System.Windows.Forms.Panel infobarIcon;
        private System.Windows.Forms.Panel infobarImage;
        private System.Windows.Forms.TableLayoutPanel infobar2;
        private System.Windows.Forms.Panel infobar2Icon;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label infobar2Credits;
        private System.Windows.Forms.Label infobar2Author;
        private System.Windows.Forms.Label infobar2Name;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox infobar2Desc;
        private System.Windows.Forms.Panel infobar2Image;
        private System.Windows.Forms.ColumnHeader columnDL_downloads;
    }
}

