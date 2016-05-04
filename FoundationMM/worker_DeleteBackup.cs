using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
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
    }
}
