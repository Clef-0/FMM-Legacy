using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        private void openModsButton(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(System.IO.Directory.GetCurrentDirectory(), "mods", "tagmods"));
        }

        private void openGameRootButton(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", System.IO.Directory.GetCurrentDirectory());
        }
    }
}
