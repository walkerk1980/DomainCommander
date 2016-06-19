namespace DomainCommander
{
    partial class ITAppPCNamesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ITAppPCNamesForm));
            this.iDSpcNamesDataSet = new DomainCommander.IDSpcNamesDataSet();
            this.pcnamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pcnamesTableAdapter = new DomainCommander.IDSpcNamesDataSetTableAdapters.pcnamesTableAdapter();
            this.tableAdapterManager = new DomainCommander.IDSpcNamesDataSetTableAdapters.TableAdapterManager();
            this.pcnamesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pcnamesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.pcnamesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.iDSpcNamesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcnamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcnamesBindingNavigator)).BeginInit();
            this.pcnamesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcnamesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // iDSpcNamesDataSet
            // 
            this.iDSpcNamesDataSet.DataSetName = "IDSpcNamesDataSet";
            this.iDSpcNamesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pcnamesBindingSource
            // 
            this.pcnamesBindingSource.DataMember = "pcnames";
            this.pcnamesBindingSource.DataSource = this.iDSpcNamesDataSet;
            // 
            // pcnamesTableAdapter
            // 
            this.pcnamesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.pcnamesTableAdapter = this.pcnamesTableAdapter;
            this.tableAdapterManager.UpdateOrder = DomainCommander.IDSpcNamesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pcnamesBindingNavigator
            // 
            this.pcnamesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.pcnamesBindingNavigator.BindingSource = this.pcnamesBindingSource;
            this.pcnamesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.pcnamesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.pcnamesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.pcnamesBindingNavigatorSaveItem});
            this.pcnamesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.pcnamesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.pcnamesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.pcnamesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.pcnamesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.pcnamesBindingNavigator.Name = "pcnamesBindingNavigator";
            this.pcnamesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.pcnamesBindingNavigator.Size = new System.Drawing.Size(281, 25);
            this.pcnamesBindingNavigator.TabIndex = 0;
            this.pcnamesBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // pcnamesBindingNavigatorSaveItem
            // 
            this.pcnamesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pcnamesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("pcnamesBindingNavigatorSaveItem.Image")));
            this.pcnamesBindingNavigatorSaveItem.Name = "pcnamesBindingNavigatorSaveItem";
            this.pcnamesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.pcnamesBindingNavigatorSaveItem.Text = "Save Data";
            this.pcnamesBindingNavigatorSaveItem.Click += new System.EventHandler(this.pcnamesBindingNavigatorSaveItem_Click_1);
            // 
            // pcnamesDataGridView
            // 
            this.pcnamesDataGridView.AllowUserToOrderColumns = true;
            this.pcnamesDataGridView.AutoGenerateColumns = false;
            this.pcnamesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pcnamesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.pcnamesDataGridView.DataSource = this.pcnamesBindingSource;
            this.pcnamesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcnamesDataGridView.Location = new System.Drawing.Point(0, 25);
            this.pcnamesDataGridView.Name = "pcnamesDataGridView";
            this.pcnamesDataGridView.Size = new System.Drawing.Size(281, 362);
            this.pcnamesDataGridView.TabIndex = 1;
            this.pcnamesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pcnamesDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "username";
            this.dataGridViewTextBoxColumn2.HeaderText = "username";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "pcname";
            this.dataGridViewTextBoxColumn3.HeaderText = "pcname";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // ITAppPCNamesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 387);
            this.Controls.Add(this.pcnamesDataGridView);
            this.Controls.Add(this.pcnamesBindingNavigator);
            this.Name = "ITAppPCNamesForm";
            this.Text = "ITAppPCNamesForm";
            this.Load += new System.EventHandler(this.ITAppPCNamesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iDSpcNamesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcnamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcnamesBindingNavigator)).EndInit();
            this.pcnamesBindingNavigator.ResumeLayout(false);
            this.pcnamesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcnamesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IDSpcNamesDataSet iDSpcNamesDataSet;
        private System.Windows.Forms.BindingSource pcnamesBindingSource;
        private IDSpcNamesDataSetTableAdapters.pcnamesTableAdapter pcnamesTableAdapter;
        private IDSpcNamesDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator pcnamesBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton pcnamesBindingNavigatorSaveItem;
        public System.Windows.Forms.DataGridView pcnamesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;



    }
}