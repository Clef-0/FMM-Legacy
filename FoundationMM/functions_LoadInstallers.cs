using Ini;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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
    }
}
