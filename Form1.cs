using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using Microsoft.Win32;

namespace MakeMyMapFolder
{
    public partial class Form1 : Form
    {

        public static string path { get; set; }
        
        private ListViewColumnSorter lvwColumnSorter;

        


        

        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DirectoryInfo di = new DirectoryInfo(txtPath.Text);

                FileInfo[] fi = di.GetFiles("*.bsp");

                foreach (FileInfo f in fi)
                {


                    string[] temp = { f.Name, (f.Length/1024).ToString() + " KB" };
                    ListViewItem item1 = new ListViewItem(temp);
                    listView1.Items.Add(item1);
                

                    

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocateMaps_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = new DialogResult();
            fbd.Description = "Locate the Folder where your Maps are stored in";
            fbd.ShowNewFolderButton = false;
            dr = fbd.ShowDialog();
            if (dr == DialogResult.OK )
            {
                txtPath.Text = fbd.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //DataTable dt_config = new DataTable("Config");

            //if (File.Exists("config.xml"))
            //{
            //    // uerst die XML-Datei in eine DataTable einlesen
            //    dt_config.ReadXml("config.xml");
            //    // Dann die Erste DataRow verwenden
            //    DataRow dr_config = dt_config.Rows[0];
            //    txtPath.Text = dr_config["path"].ToString();
            //}

            if (File.Exists("local.conf"))
            {
                Configuration loadconf = new Configuration();
                loadconf = loadconf.load();
                txtPath.Text = loadconf.path;
            }

            else
            {
                EnterSteamUsername username = new EnterSteamUsername();
                
                username.ShowDialog();
                txtPath.Text = path;
            }
            
            
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            listView1.Sort();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DataTable dt_config = new DataTable("Config");

            //dt_config.Columns.Add("path");

            //DataRow dr_config = dt_config.NewRow();
            //dr_config["path"] = Form1.path.ToString();
            //dt_config.Rows.Add(dr_config);
            //dt_config.WriteXml("config.xml", XmlWriteMode.WriteSchema);

            Configuration config = new Configuration();

            config.path = txtPath.Text;
            config.save();

        }

       

        

        
    }
}
