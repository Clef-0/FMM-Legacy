using SharpSvn;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        SvnClient client = new SvnClient();

        private void dlModWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] args = (string[])e.Argument;
            string remLocation = args[0];
            string locLocation = args[1];
            remLocation = remLocation.Replace(System.IO.Path.GetFileName(new Uri(remLocation).LocalPath), "");

            locLocation = Path.GetDirectoryName(locLocation);

            Debug.WriteLine(remLocation + "  &&  " + locLocation);



            BackgroundWorker worker = sender as BackgroundWorker;

            percentageLabel.Text = "Download in progress...";
            client.CheckOut(new Uri(remLocation), locLocation);
        }

        private void dlModWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Error == null))
            {
                percentageLabel.Text = ("Error: " + e.Error.Message);
            }
            else
            {
                percentageLabel.Text = "";
                tabControl1.Enabled = true;
            }
        }
    }
}
