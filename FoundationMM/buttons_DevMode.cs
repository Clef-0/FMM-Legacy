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
        string lang_EnableFileRestoration = "Enable File Restoration";
        string lang_DisableFileRestoration = "Disable File Restoration";
        string lang_EnableCMDWindows = "Enable CMD Windows";
        string lang_DisableCMDWindows = "Disable CMD Windows";

        private void toggleFileRestoration_Click(object sender, EventArgs e)
        {
            if (restoreFiles == true)
            {
                restoreFiles = false;
                toggleFileRestoration.Text = lang_EnableFileRestoration;
            }
            else
            {
                restoreFiles = true;
                toggleFileRestoration.Text = lang_DisableFileRestoration;
            }
        }

        private void toggleCmdWindows_Click(object sender, EventArgs e)
        {
            if (showInstallers == true)
            {
                showInstallers = false;
                toggleCmdWindows.Text = lang_EnableCMDWindows;
            }
            else
            {
                showInstallers = true;
                toggleCmdWindows.Text = lang_DisableCMDWindows;
            }
        }
    }
}
