using System;
using System.IO;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
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
                    modNumberLabel.Text = "1 mod available";
                }
                else
                {
                    modNumberLabel.Text = modCount + " mods available";
                }
            }
            else
            {
                listView2.Items.Clear();
                dlFilesWorker.RunWorkerAsync(new string[] { Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mods", "tagmods") });
            }
        }
    }
}
