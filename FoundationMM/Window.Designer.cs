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
            this.header_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.header_Location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openGameRoot = new System.Windows.Forms.Button();
            this.openMods = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.modNumberLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.percentageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.header_Name,
            this.header_Author,
            this.header_Description,
            this.header_Location});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(519, 419);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // header_Description
            // 
            this.header_Description.Text = "Description";
            this.header_Description.Width = 200;
            // 
            // header_Location
            // 
            this.header_Location.Text = "Location";
            this.header_Location.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(519, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 419);
            this.panel1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Location = new System.Drawing.Point(3, 310);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(152, 106);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Game";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "Restore Unmodded Files";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.cleanClick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Apply Selected Mods";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.applyClick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 77);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "Launch ElDewrito";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.launchDewritoClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.openGameRoot);
            this.groupBox2.Controls.Add(this.openMods);
            this.groupBox2.Location = new System.Drawing.Point(3, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 77);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Directories";
            // 
            // openGameRoot
            // 
            this.openGameRoot.Location = new System.Drawing.Point(6, 19);
            this.openGameRoot.Name = "openGameRoot";
            this.openGameRoot.Size = new System.Drawing.Size(140, 23);
            this.openGameRoot.TabIndex = 1;
            this.openGameRoot.Text = "Open Game Folder";
            this.openGameRoot.UseVisualStyleBackColor = true;
            this.openGameRoot.Click += new System.EventHandler(this.openGameRootButton);
            // 
            // openMods
            // 
            this.openMods.Location = new System.Drawing.Point(6, 48);
            this.openMods.Name = "openMods";
            this.openMods.Size = new System.Drawing.Size(140, 23);
            this.openMods.TabIndex = 0;
            this.openMods.Text = "Open Mods Folder";
            this.openMods.UseVisualStyleBackColor = true;
            this.openMods.Click += new System.EventHandler(this.openModsButton);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mod Priority";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Decrease Priority";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.downClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Increase Priority";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.upClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modNumberLabel,
            this.toolStripStatusLabel1,
            this.percentageLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(677, 22);
            this.statusStrip1.TabIndex = 2;
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(567, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // percentageLabel
            // 
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 441);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.Text = "Foundation Mod Manager 1.00";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.Load += new System.EventHandler(this.Window_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ToolStripStatusLabel percentageLabel;
        private System.Windows.Forms.Button openGameRoot;
    }
}

