using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;

namespace DomainCommander
{
    public partial class ITAppPCNamesForm : Form
    {
        string profileName;
        public string ProfileName
        {
            get { return profileName; }
        }

        public ITAppPCNamesForm()
        {
            InitializeComponent();
        }

        public ITAppPCNamesForm(DCMainForm iTAppMainForm)
        {
            // TODO: Complete member initialization
        }

        private void ITAppPCNamesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iDSpcNamesDataSet.pcnames' table. You can move, or remove it, as needed.
            this.pcnamesTableAdapter.Fill(this.iDSpcNamesDataSet.pcnames);
            // TODO: This line of code loads data into the 'iDSpcNamesDataSet.pcnames' table. You can move, or remove it, as needed.
            this.pcnamesTableAdapter.Fill(this.iDSpcNamesDataSet.pcnames);
            // TODO: This line of code loads data into the 'idsDBDataSet.pcnames' table. You can move, or remove it, as needed.
        }

        private void pcnamesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pcnamesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.iDSpcNamesDataSet);

        }

        private void pcnamesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.pcnamesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.iDSpcNamesDataSet);

        }

        private void ExportToExcel(System.Data.DataTable dt, string fileName, string worksheetName)
        {

        }

        public void pcnamesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //  pcnamesCellDoubleClickEventArgs e)
        {
            profileName = pcnamesDataGridView.CurrentCell.Value.ToString();
        }

    }

}
