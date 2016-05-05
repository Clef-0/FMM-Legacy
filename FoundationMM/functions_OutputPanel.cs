﻿using System;
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
            textBox1.AppendText(Environment.NewLine + output);
        }

        private void showMessageBox(string output)
        {
            FlashWindowEx(this);
            MessageBox.Show(output);
        }
    }
}