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
        public delegate void appendNewOutputCallback(string output);
        public delegate void showMessageBoxCallback(string output);

        private void appendNewOutput(string output)
        {
            textBox1.AppendText(output + Environment.NewLine);
        }

        private void showMessageBox(string output)
        {
            FlashWindowEx(this);
            MessageBox.Show(output);
        }


        // following code not in use (yet) :p

        public delegate void appendNewLogCallback(string output);

        private void _appendNewLog(string output)
        {
            //debugTextBox.AppendText(output + Environment.NewLine);
        }
        
        private void Log(string output)
        {
            //debugTextBox.Invoke(new appendNewLogCallback(this._appendNewLog), new object[] { output });
        }
    }
}
