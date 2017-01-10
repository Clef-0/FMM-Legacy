using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ini;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace FoundationMM
{
    public partial class Window : Form
    {
        bool selecting = false;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool infobarsEnabled = true;
            IniFile ini2 = new IniFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.ini"));

            if (ini2.IniReadValue("FMMPrefs", "NoInfoMode").ToLower() == "true")
            {
                infobarsEnabled = false;
            }

            if ((listView1.SelectedItems.Count > 0) && (selecting == false) && (infobarsEnabled == true))
            {
                selecting = true;
                IniFile ini = new IniFile(Path.Combine(Directory.GetCurrentDirectory(), "mods", listView1.SelectedItems[0].SubItems[5].Text.Replace(".fm", ".ini")));
                

                infobar.Visible = true;

                infobarName.Text = ini.IniReadValue("FMMInfo", "Name") + " " + ini.IniReadValue("FMMInfo", "Version");
                infobarAuthor.Text = ini.IniReadValue("FMMInfo", "Author");

                if (ini.IniReadValue("FMMInfo", "Credits") != "")
                {
                    infobarCredits.Text = "Credits: " + ini.IniReadValue("FMMInfo", "Credits");
                }
                else
                {
                    infobarCredits.Text = "";
                }




                string descBox = "";

                if (ini.IniReadValue("FMMInfo", "RevisionDate") != "")
                {
                    descBox += "Last revision: " + ini.IniReadValue("FMMInfo", "RevisionDate") + Environment.NewLine;
                }

                if (ini.IniReadValue("FMMInfo", "EDVersion") != "")
                {
                    descBox += "ElDewrito version: " + ini.IniReadValue("FMMInfo", "EDVersion") + Environment.NewLine;
                }
                
                if (descBox != "")
                {
                    descBox += Environment.NewLine;
                }

                if (ini.IniReadValue("FMMInfo", "LongDesc") != "")
                {
                    descBox += ini.IniReadValue("FMMInfo", "LongDesc");
                }
                else if(ini.IniReadValue("FMMInfo", "Desc") != "")
                {
                    descBox += ini.IniReadValue("FMMInfo", "Desc");
                }

                if (ini.IniReadValue("FMMInfo", "LongWarnings") != "")
                {
                    descBox += Environment.NewLine + Environment.NewLine + ini.IniReadValue("FMMInfo", "LongWarnings");
                }
                else if (ini.IniReadValue("FMMInfo", "Warnings") != "")
                {
                    descBox += Environment.NewLine + Environment.NewLine + ini.IniReadValue("FMMInfo", "Warnings");
                }

                infobarDesc.Text = descBox;





                if (ini.IniReadValue("FMMInfo", "Icon") == "")
                {
                    infobar.ColumnStyles[0].Width = 0;
                    infobarIcon.BackgroundImage = null;
                    infobarIcon.Cursor = null;
                    infobarIcon.Tag = "";
                }
                else
                {
                    if (ini2.IniReadValue("FMMPrefs", "OfflineMode").ToLower() != "true")
                    {
                        try
                        {
                            infobar.ColumnStyles[0].Width = 72;
                            System.Net.WebRequest request = System.Net.WebRequest.Create(ini.IniReadValue("FMMInfo", "Icon"));
                            System.Net.WebResponse response = request.GetResponse();
                            System.IO.Stream responseStream = response.GetResponseStream();
                            infobarIcon.BackgroundImage = new Bitmap(responseStream);
                            infobarIcon.BackgroundImageLayout = ImageLayout.Center;

                            infobarIcon.Cursor = Cursors.Hand;
                            if (ini.IniReadValue("FMMInfo", "Url") != "")
                            {
                                infobarIcon.Tag = ini.IniReadValue("FMMInfo", "Url");
                            }
                            else
                            {
                                infobarIcon.Tag = ini.IniReadValue("FMMInfo", "Icon");
                            }
                        }
                        catch
                        {
                            infobar.ColumnStyles[0].Width = 0;
                            infobarIcon.BackgroundImage = null;
                            infobarIcon.Cursor = null;
                            infobarIcon.Tag = "";
                        }
                    }
                    else
                    {
                        infobar.ColumnStyles[0].Width = 0;
                        infobarIcon.BackgroundImage = null;
                        infobarIcon.Cursor = null;
                        infobarIcon.Tag = "";
                    }
                }

                if (ini.IniReadValue("FMMInfo", "ImageThumb") == "")
                {
                    infobar.ColumnStyles[3].Width = 0;
                    infobarImage.BackgroundImage = null;
                    infobarImage.Cursor = null;
                    infobarImage.Tag = "";
                }
                else
                {
                    if (ini2.IniReadValue("FMMPrefs", "OfflineMode").ToLower() != "true")
                    {
                        try
                        {
                            infobar.ColumnStyles[3].Width = 128;
                            System.Net.WebRequest request = System.Net.WebRequest.Create(ini.IniReadValue("FMMInfo", "ImageThumb"));
                            System.Net.WebResponse response = request.GetResponse();
                            System.IO.Stream responseStream = response.GetResponseStream();
                            infobarImage.BackgroundImage = new Bitmap(responseStream);
                            infobarImage.BackgroundImageLayout = ImageLayout.Center;

                            infobarImage.Cursor = Cursors.Hand;
                            if (ini.IniReadValue("FMMInfo", "ImageFull") != "")
                            {
                                infobarImage.Tag = ini.IniReadValue("FMMInfo", "ImageFull");
                            }
                            else
                            {
                                infobarImage.Tag = ini.IniReadValue("FMMInfo", "ImageThumb");
                            }
                        }
                        catch
                        {
                            infobar.ColumnStyles[3].Width = 0;
                            infobarImage.BackgroundImage = null;
                            infobarImage.Cursor = null;
                            infobarImage.Tag = "";
                        }
                    }
                    else
                    {
                        infobar.ColumnStyles[3].Width = 0;
                        infobarImage.BackgroundImage = null;
                        infobarImage.Cursor = null;
                        infobarImage.Tag = "";
                    }
                }
                selecting = false;
            }
        }
        
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool infobarsEnabled = true;
            IniFile ini2 = new IniFile(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "fmm.ini"));

            if (ini2.IniReadValue("FMMPrefs", "NoInfoMode").ToLower() == "true")
            {
                infobarsEnabled = false;
            }

            if ((listView2.SelectedItems.Count > 0) && (selecting == false) && (infobarsEnabled == true))
            {
                selecting = true;
                IniFile ini = new IniFile(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn", Path.GetFileName(listView2.SelectedItems[0].SubItems[6].Text.Replace(".fm", ".ini"))));
                
                infobar2.Visible = true;
                
                infobar2Name.Text = ini.IniReadValue("FMMInfo", "Name") + " " + ini.IniReadValue("FMMInfo", "Version");
                infobar2Author.Text = ini.IniReadValue("FMMInfo", "Author");

                if (ini.IniReadValue("FMMInfo", "Credits") != "")
                {
                    infobar2Credits.Text = "Credits: " + ini.IniReadValue("FMMInfo", "Credits");
                }
                else
                {
                    infobar2Credits.Text = "";
                }




                string descBox = "";

                if (ini.IniReadValue("FMMInfo", "RevisionDate") != "")
                {
                    descBox += "Last revision: " + ini.IniReadValue("FMMInfo", "RevisionDate") + Environment.NewLine;
                }

                if (ini.IniReadValue("FMMInfo", "EDVersion") != "")
                {
                    descBox += "ElDewrito version: " + ini.IniReadValue("FMMInfo", "EDVersion") + Environment.NewLine + Environment.NewLine;
                }

                if (ini.IniReadValue("FMMInfo", "LongDesc") != "")
                {
                    descBox += ini.IniReadValue("FMMInfo", "LongDesc");
                }
                else if (ini.IniReadValue("FMMInfo", "Desc") != "")
                {
                    descBox += ini.IniReadValue("FMMInfo", "Desc");
                }

                if (ini.IniReadValue("FMMInfo", "LongWarnings") != "")
                {
                    descBox += Environment.NewLine + Environment.NewLine + ini.IniReadValue("FMMInfo", "LongWarnings");
                }
                else if (ini.IniReadValue("FMMInfo", "Warnings") != "")
                {
                    descBox += Environment.NewLine + Environment.NewLine + ini.IniReadValue("FMMInfo", "Warnings");
                }

                infobar2Desc.Text = descBox;





                if (ini.IniReadValue("FMMInfo", "Icon") == "")
                {
                    infobar2.ColumnStyles[0].Width = 0;
                    infobar2Icon.BackgroundImage = null;
                    infobar2Icon.Cursor = null;
                    infobar2Icon.Tag = "";
                }
                else
                {
                    if (ini2.IniReadValue("FMMPrefs", "OfflineMode").ToLower() != "true")
                    {
                        try
                        {
                            infobar2.ColumnStyles[0].Width = 72;
                            System.Net.WebRequest request = System.Net.WebRequest.Create(ini.IniReadValue("FMMInfo", "Icon"));
                            System.Net.WebResponse response = request.GetResponse();
                            System.IO.Stream responseStream = response.GetResponseStream();
                            infobar2Icon.BackgroundImage = new Bitmap(responseStream);
                            infobar2Icon.BackgroundImageLayout = ImageLayout.Center;

                            infobar2Icon.Cursor = Cursors.Hand;
                            if (ini.IniReadValue("FMMInfo", "Url") != "")
                            {
                                infobar2Icon.Tag = ini.IniReadValue("FMMInfo", "Url");
                            }
                            else
                            {
                                infobar2Icon.Tag = ini.IniReadValue("FMMInfo", "Icon");
                            }
                        }
                        catch
                        {
                            infobar2.ColumnStyles[0].Width = 0;
                            infobar2Icon.BackgroundImage = null;
                            infobar2Icon.Cursor = null;
                            infobar2Icon.Tag = "";
                        }
                    }
                    else
                    {
                        infobar2.ColumnStyles[0].Width = 0;
                        infobar2Icon.BackgroundImage = null;
                        infobar2Icon.Cursor = null;
                        infobar2Icon.Tag = "";
                    }
                }

                if (ini.IniReadValue("FMMInfo", "ImageThumb") == "")
                {
                    infobar2.ColumnStyles[3].Width = 0;
                    infobar2Image.BackgroundImage = null;
                    infobar2Image.Cursor = null;
                    infobar2Image.Tag = "";
                }
                else
                {
                    if (ini2.IniReadValue("FMMPrefs", "OfflineMode").ToLower() != "true")
                    {
                        try
                        {
                            infobar2.ColumnStyles[3].Width = 128;
                            System.Net.WebRequest request = System.Net.WebRequest.Create(ini.IniReadValue("FMMInfo", "ImageThumb"));
                            System.Net.WebResponse response = request.GetResponse();
                            System.IO.Stream responseStream = response.GetResponseStream();
                            infobar2Image.BackgroundImage = new Bitmap(responseStream);
                            infobar2Image.BackgroundImageLayout = ImageLayout.Center;

                            infobar2Image.Cursor = Cursors.Hand;
                            if (ini.IniReadValue("FMMInfo", "ImageFull") != "")
                            {
                                infobar2Image.Tag = ini.IniReadValue("FMMInfo", "ImageFull");
                            }
                            else
                            {
                                infobar2Image.Tag = ini.IniReadValue("FMMInfo", "ImageThumb");
                            }
                        }
                        catch
                        {
                            infobar2.ColumnStyles[3].Width = 0;
                            infobar2Image.BackgroundImage = null;
                            infobar2Image.Cursor = null;
                            infobar2Image.Tag = "";
                        }
                    }
                    else
                    {
                        infobar2.ColumnStyles[3].Width = 0;
                        infobar2Image.BackgroundImage = null;
                        infobar2Image.Cursor = null;
                        infobar2Image.Tag = "";
                    }
                }
                selecting = false;
            }
        }

        private void infobarIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if ((string)infobarIcon.Tag != "")
            {
                Process.Start((string)infobarIcon.Tag);
            }
        }

        private void infobar2Icon_MouseClick(object sender, MouseEventArgs e)
        {
            if ((string)infobar2Icon.Tag != "")
            {
                Process.Start((string)infobar2Icon.Tag);
            }
        }

        private void infobarImage_MouseClick(object sender, MouseEventArgs e)
        {
            if ((string)infobarImage.Tag != "")
            {
                Process.Start((string)infobarImage.Tag);
            }
        }

        private void infobar2Image_MouseClick(object sender, MouseEventArgs e)
        {
            if ((string)infobar2Image.Tag != "")
            {
                Process.Start((string)infobar2Image.Tag);
            }
        }
    }
}
