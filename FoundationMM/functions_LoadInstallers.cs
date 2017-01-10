using Ini;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoundationMM
{
    public partial class Window : Form
    {
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
                    string modVersion;
                    try { modVersion = ini.IniReadValue("FMMInfo", "Version"); }
                    catch { modVersion = ""; }
                    string modWarnings;
                    try { modWarnings = ini.IniReadValue("FMMInfo", "Warnings"); }
                    catch { modWarnings = ""; }
                    string modDesc = ini.IniReadValue("FMMInfo", "Desc");

                    string modLocation = fmfile.Replace(Path.Combine(Directory.GetCurrentDirectory(), "mods\\"), "");
                    listView1.Items.Add(new ListViewItem(new[] { modName, modAuthor, modVersion, modDesc, modWarnings, modLocation }));
                }
            }
        }

        private void checkFMMInstallerOrder()
        {
            string fmmdat = Path.Combine(Directory.GetCurrentDirectory(), "fmm.dat");
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

        private void populateInstallerDLList()
        {
            Dictionary<string, string> downloadsDictionary = new Dictionary<string, string>();

            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn")))
            {
                Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn"), true);
            }
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn"));
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn", "links.txt")))
            {
                File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn", "links.txt"));
            }
            using (var client = new WebClient())
            {
                client.DownloadFile("https://raw.githubusercontent.com/Clef-0/FMM-Mods/master/meta/links.txt", Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn", "links.txt"));
            }
            using (var client = new HttpClient())
            {
                try
                {
                    string response = client.GetAsync("https://dev.fractalcore.net/fmm/api/mod/list").Result.Content.ReadAsStringAsync().Result;
                    if ((response.StartsWith("{") && response.EndsWith("}")) || (response.StartsWith("[") && response.EndsWith("]")))
                    {
                        JArray a = JArray.Parse(response);

                        foreach (JObject o in a.Children<JObject>())
                        {
                            downloadsDictionary.Add((string)o.Property("name").Value, (string)o.Property("downloads").Value);
                        }
                    }
                } catch { }
            }
            
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn", "links.txt")))
                {
                    IEnumerable<string> lines = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn", "links.txt"));
                    foreach (string modini in lines)
                    {
                    if (modini != "")
                    {
                        Uri moduri = new Uri(modini);
                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(moduri, Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn", System.IO.Path.GetFileName(moduri.LocalPath)));
                        }
                        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn", System.IO.Path.GetFileName(moduri.LocalPath))))
                        {
                            IniFile ini = new IniFile(Path.Combine(Directory.GetCurrentDirectory(), "fmm-svn", System.IO.Path.GetFileName(moduri.LocalPath)));
                            string modName = ini.IniReadValue("FMMInfo", "Name");
                            string modAuthor = ini.IniReadValue("FMMInfo", "Author");
                            string modVersion;
                            try { modVersion = ini.IniReadValue("FMMInfo", "Version"); }
                            catch { modVersion = ""; }
                            string modWarnings;
                            try { modWarnings = ini.IniReadValue("FMMInfo", "Warnings"); }
                            catch { modWarnings = ""; }
                            string modDesc = ini.IniReadValue("FMMInfo", "Desc");
                            string modUsers = "";
                            downloadsDictionary.TryGetValue(modName.ToLower(), out modUsers);
                            string modLocation = modini.Replace("https://raw.githubusercontent.com/Clef-0/FMM-Mods/master/", "").Replace(".ini", ".fm");

                            listView2.Invoke((MethodInvoker)delegate { listView2.Items.Add(new ListViewItem(new[] { modName, modAuthor, modVersion, modDesc, modWarnings, modUsers, modLocation })); });

                            if (enabledTab == 1)
                            {
                                int modCount = listView2.Items.Count;
                                if (modCount == 1)
                                {
                                    statusStrip1.Invoke((MethodInvoker)delegate { modNumberLabel.Text = "1 " + lang_ModAvailable; });
                                }
                                else
                                {
                                    statusStrip1.Invoke((MethodInvoker)delegate { modNumberLabel.Text = modCount + " " + lang_ModsAvailable; });
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
