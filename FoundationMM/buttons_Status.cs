using System;
using System.IO;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        string lang_ModAvailable = "mod available";
        string lang_ModsAvailable = "mods available";

        private void refreshModsClick(object sender, EventArgs e)
        {
            if (enabledTab == 0)
            {
                listView1.Items.Clear();
                locatedFMMInstallers.Clear();
                lookForFMMInstallers();
                addFMMInstallersToList();
                checkFMMInstallerOrder();

                int modCount = listView1.Items.Count;
                if (modCount == 1)
                {
                    modNumberLabel.Text = "1 " + lang_ModAvailable;
                }
                else
                {
                    modNumberLabel.Text = modCount + " " + lang_ModsAvailable;
                }
            }
            else
            {
                if (refreshinprog == false)
                {
                    refreshinprog = true;
                    listView2.Items.Clear();
                    dlFilesWorker.RunWorkerAsync(new string[] { Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mods", "tagmods") });
                }
            }
        }
    }
}
