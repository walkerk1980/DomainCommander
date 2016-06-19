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

namespace DomainCommander
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            listPathOptionsBox.Text = Properties.Settings.Default.pcListPath;
            connectionStringOptionsBox.Text = Properties.Settings.Default.pcNamesConnectionString;
            ouOptionsBox.Text = Properties.Settings.Default.OU;
        }

        private void listPathOptionsBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(listPathOptionsBox.Text))
            {
                if (!listPathOptionsBox.Text.Equals(Properties.Settings.Default.pcListPath))
                {
                    applyButton.Enabled = true;
                }
            }
        }

        private void pcListPathBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pcListPathFolderBrowserDialog = new FolderBrowserDialog();
            //pcListPathFolderBrowserDialog.RootFolder = Environment.SpecialFolder.NetworkShortcuts;
            pcListPathFolderBrowserDialog.ShowNewFolderButton = true;
            pcListPathFolderBrowserDialog.Description = "PC Name List Save Path";
            if (pcListPathFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if ((listPathOptionsBox.Text = pcListPathFolderBrowserDialog.SelectedPath) != null)
                {
                    if (!listPathOptionsBox.Text.Equals(Properties.Settings.Default.pcListPath))
                    {
                        applyButton.Enabled = true;
                    }
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplyPCListPath();
            ApplyOU();
            //ApplyConnectionString();

            MessageBox.Show("You must restart the program for these changes to take effect.");
        }

        private void ApplyConnectionString()
        {
            if (!connectionStringOptionsBox.Text.Equals(Properties.Settings.Default.pcNamesConnectionString))
            {
                //Properties.Settings.Default.IDSpcNamesConnectionString = connectionStringOptionsBox.Text;
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringsSection conStrSection = config.ConnectionStrings as ConnectionStringsSection;

                try
                {
                    //if (conStrSection.ConnectionStrings.Count != 0)
                    //{

                    ////     Get the collection elements. 
                    //    foreach (ConnectionStringSettings connection in conStrSection.ConnectionStrings)
                    //    {
                    //        string name = connection.Name;
                    //        string connectionString = connection.ConnectionString;

                    //        MessageBox.Show(name);
                    //        MessageBox.Show(connectionString);
                    //    }
                    //}
                }
                catch (ConfigurationErrorsException exc)
                {
                    MessageBox.Show("Using ConnectionStrings property: " + exc.ToString());
                }
                //conStrSection.ConnectionStrings["IDS_ITAPP.Properties.Settings.Default.IDSpcNamesConnectionString"].ConnectionString = @"Data Source=mh-7xv7gj1\idsdb;Initial Catalog=IDSpcNames;integrated security=false;";
                //config.Save(); 
                //Properties.Settings.Default.Save();
                applyButton.Enabled = false;
            }
        }

        private void ApplyOU()
        {
            if (!ouOptionsBox.Text.Equals(Properties.Settings.Default.OU))
            {
                Properties.Settings.Default.OU = ouOptionsBox.Text;
                Properties.Settings.Default.Save();
                applyButton.Enabled = false;
            }
        }

        private void ApplyPCListPath()
        {
            if (!listPathOptionsBox.Text.Equals(Properties.Settings.Default.pcListPath))
            {
                if (Directory.Exists(listPathOptionsBox.Text))
                {
                    if (!listPathOptionsBox.Text.EndsWith(@"\"))
                    {
                        listPathOptionsBox.Text += @"\";
                    }
                    Properties.Settings.Default.pcListPath = listPathOptionsBox.Text;
                    Properties.Settings.Default.Save();
                    applyButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Directory does not exist!");
                }
            }
        }

        private void connectionStringOptionsBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(connectionStringOptionsBox.Text))
            {
                if (!connectionStringOptionsBox.Text.Equals(Properties.Settings.Default.pcNamesConnectionString))
                {
                    applyButton.Enabled = true;
                }
            }
        }

        private void ouOptionsBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ouOptionsBox.Text))
            {
                if (!ouOptionsBox.Text.Equals(Properties.Settings.Default.OU))
                {
                    applyButton.Enabled = true;
                }
            }
        }

        private void editExeConfig_Click(object sender, EventArgs e)
        {
            LocalApplications lt = new LocalApplications();
            string exeConfigPath;
            exeConfigPath = System.Windows.Forms.Application.ExecutablePath.ToString() + ".config";
            lt.RunNotepad(exeConfigPath);
            MessageBox.Show("Application must be restarted for settings to take effect.");
        }
    }
}
