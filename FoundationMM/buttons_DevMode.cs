using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        private void toggleFileRestoration_Click(object sender, EventArgs e)
        {
            if (restoreFiles == true)
            {
                restoreFiles = false;
                toggleFileRestoration.Text = "Enable File Restoration";
            }
            else
            {
                restoreFiles = true;
                toggleFileRestoration.Text = "Disable File Restoration";
            }
        }

        private void toggleCmdWindows_Click(object sender, EventArgs e)
        {
            if (showInstallers == true)
            {
                showInstallers = false;
                toggleCmdWindows.Text = "Enable CMD Windows";
            }
            else
            {
                showInstallers = true;
                toggleCmdWindows.Text = "Disable CMD Windows";
            }
        }
    }
}
