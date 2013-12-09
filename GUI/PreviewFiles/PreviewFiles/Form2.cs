using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PreviewFiles
{
    public partial class Form2 : Form
    {
        //number of lines displayed
        private const int PreviewLength = 20;

        private string selectedFile = null;

        public string SelectedFile {
            get
            {
                return selectedFile;
            }
        }

        public Form2(string currentFile, HashSet<string> stringPaths)
        {
            InitializeComponent();

            selectedFile = String.Copy(currentFile);

            foreach (var currentPath in stringPaths)
            {
                comboBox1.Items.Add(currentPath);
            }

            //Initialize list view
            initListView(currentFile);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            initListView(comboBox1.SelectedItem.ToString());
        }

        private void initListView(string currentFile)
        {
            MessageBox.Show("preview: " + currentFile);
            selectedFile = currentFile;

            
            listView1.Items.Clear();
            //preview file: open it, read PreviewLength lines and close it
            GetFilePreview();
        }

        /// <summary>
        /// Opens a file, reads PreviewLength lines and closes it
        /// </summary>
        /// <returns></returns>
        private void GetFilePreview()
        {
            try
            {
                string result = String.Empty;
                Console.WriteLine("try to open file: " + selectedFile);
                using (StreamReader sr = new StreamReader(selectedFile))
                {
                    for (int index = 0; index < PreviewLength; ++index)
                    {
                        String line = sr.ReadLine();
                        listView1.Items.Add(line);
                        Console.WriteLine("Read: " + line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

                throw e;
            }
        }
    }
}
