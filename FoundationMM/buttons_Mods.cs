using System;
using System.Collections.Generic;
using System.IO;
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
                    listView1.Sorting = SortOrder.None;
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
                    listView1.Sorting = SortOrder.None;
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

        private void maxPriority(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    listView1.Sorting = SortOrder.None;
                    ListViewItem selected = listView1.SelectedItems[0];
                    int indx = selected.Index;
                    int totl = listView1.Items.Count;
                    
                    listView1.Items.Remove(selected);
                    listView1.Items.Insert(0, selected);
                    listView1.Items[0].Selected = true;
                    listView1.Select();
                }
            }
            catch { }
        }

        private void minPriority(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    listView1.Sorting = SortOrder.None;
                    ListViewItem selected = listView1.SelectedItems[0];
                    int indx = selected.Index;
                    int totl = listView1.Items.Count;

                    listView1.Items.Remove(selected);
                    listView1.Items.Insert(totl - 1, selected);
                    listView1.Items[totl - 1].Selected = true;
                    listView1.Select();
                }
            }
            catch { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete \"" + listView1.SelectedItems[0].SubItems[0].Text + "\"? This cannot be undone.\nThis will not uninstall the mod until a new mod configuration is applied.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), "mods", Path.GetDirectoryName(listView1.SelectedItems[0].SubItems[5].Text)), true);
                    refreshModsClick(null, null);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
            ListView.CheckedListViewItemCollection oitems = listView2.CheckedItems;
            List<ListViewItem> items = new List<ListViewItem>();

            foreach (ListViewItem item in oitems)
            {
                items.Add(item);
            }

            if (items.Count != 0)
            {
                dlModWorkerStarter.RunWorkerAsync(items);
            }
        }
    }
}
