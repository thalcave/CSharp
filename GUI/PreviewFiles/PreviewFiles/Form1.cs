using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreviewFiles
{
    public partial class Form1 : Form
    {
        private const int FileLimit = 5;
        private HashSet<string> stringPaths = new HashSet<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void click_About(object sender, EventArgs e)
        {
            MessageBox.Show("Preview Files, version 0.9");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectFiles(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (stringPaths.Contains(openFileDialog1.FileName))
                {
                    MessageBox.Show("File already in list: " + openFileDialog1.FileName);
                    return;
                }
                if (stringPaths.Count >= FileLimit)
                {
                    MessageBox.Show("Exceeded limit of files : " + FileLimit.ToString(), "Warning");
                    return;
                }

                //MessageBox.Show(openFileDialog1.FileName);
                stringPaths.Add(openFileDialog1.FileName);

                listView1.Items.Add(openFileDialog1.FileName);
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            // user clicked an item of listview control
            if (listView1.SelectedItems.Count == 1)
            {
                //do what you need to do here
                ListView.SelectedListViewItemCollection checkedItems = listView1.SelectedItems;

                ListViewItem currentItem = checkedItems[0];
                //MessageBox.Show("Selected: " + currentItem.Text);

                Form2 previewForm = new Form2(currentItem.Text, stringPaths);
                previewForm.ShowDialog();

                MessageBox.Show("Last previewed file: " + previewForm.SelectedFile);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            stringPaths.Clear();
            listView1.Items.Clear();
        }
    }
}
