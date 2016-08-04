using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {

        private void dlFilesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] args = (string[])e.Argument;
            string mapsPath = args[0];

            BackgroundWorker worker = sender as BackgroundWorker;

            populateInstallerDLList();
        }
        
        private void dlFilesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Error == null))
            {
                percentageLabel.Text = ("Error: " + e.Error.Message);
            }
            refreshinprog = false;
        }
    }
}
