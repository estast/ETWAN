using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace MakeMyMapFolder
{
    public partial class EnterSteamUsername : Form
    {
        public EnterSteamUsername()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                string steampath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "ServiceInstallPath", null).ToString();
                
                 string temppath = steampath + @"steamapps\" + textBox1.Text + "\\" + @"counter-strike source\cstrike\maps";

                    if (Directory.Exists(temppath))
                    {
                        Form1.path = temppath;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Steam account does not exist or has no Counterstrike: Source installed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                

                
                
            }
            else
            {
                MessageBox.Show("Please enter your Steam Accountname or click Cancel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void EnterSteamUsername_Load(object sender, EventArgs e)
        {
            if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "ServiceInstallPath", null) != null)
            {
            }
            else
                this.Close();

        }
    }
}
