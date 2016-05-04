using System;
using System.Windows.Forms;

namespace FoundationMM
{
    public partial class Window : Form
    {
        private void upClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selected = listView1.SelectedItems[0];
                    int indx = selected.Index;

                    if (indx != 0)
                    {
                        listView1.Items.Remove(selected);
                        listView1.Items.Insert(indx - 1, selected);
                        listView1.Items[indx - 1].Selected = true;
                        listView1.Select();
                    }
                }
            }
            catch { }
        }

        private void downClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selected = listView1.SelectedItems[0];
                    int indx = selected.Index;
                    int totl = listView1.Items.Count;

                    if (indx != totl - 1)
                    {
                        listView1.Items.Remove(selected);
                        listView1.Items.Insert(indx + 1, selected);
                        listView1.Items[indx + 1].Selected = true;
                        listView1.Select();
                    }
                }
            }
            catch { }
        }
    }
}
