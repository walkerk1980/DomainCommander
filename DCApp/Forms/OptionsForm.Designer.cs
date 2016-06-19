namespace DomainCommander
{
    partial class OptionsForm
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
            this.listPathOptionsBox = new System.Windows.Forms.TextBox();
            this.listPathLabel = new System.Windows.Forms.Label();
            this.pcListPathBrowseButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.connectionStringOptionsBox = new System.Windows.Forms.TextBox();
            this.connectionStringLabel = new System.Windows.Forms.Label();
            this.ouOptionsBox = new System.Windows.Forms.TextBox();
            this.ouLabel = new System.Windows.Forms.Label();
            this.editExeConfigButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listPathOptionsBox
            // 
            this.listPathOptionsBox.Location = new System.Drawing.Point(42, 62);
            this.listPathOptionsBox.Name = "listPathOptionsBox";
            this.listPathOptionsBox.Size = new System.Drawing.Size(229, 20);
            this.listPathOptionsBox.TabIndex = 0;
            this.listPathOptionsBox.TextChanged += new System.EventHandler(this.listPathOptionsBox_TextChanged);
            // 
            // listPathLabel
            // 
            this.listPathLabel.AutoSize = true;
            this.listPathLabel.Location = new System.Drawing.Point(59, 46);
            this.listPathLabel.Name = "listPathLabel";
            this.listPathLabel.Size = new System.Drawing.Size(200, 13);
            this.listPathLabel.TabIndex = 1;
            this.listPathLabel.Text = "Path to save PC Name text files [Legacy]";
            // 
            // pcListPathBrowseButton
            // 
            this.pcListPathBrowseButton.Location = new System.Drawing.Point(277, 60);
            this.pcListPathBrowseButton.Name = "pcListPathBrowseButton";
            this.pcListPathBrowseButton.Size = new System.Drawing.Size(25, 23);
            this.pcListPathBrowseButton.TabIndex = 2;
            this.pcListPathBrowseButton.Text = "...";
            this.pcListPathBrowseButton.UseVisualStyleBackColor = true;
            this.pcListPathBrowseButton.Click += new System.EventHandler(this.pcListPathBrowseButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(12, 314);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(105, 23);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply Changes";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // connectionStringOptionsBox
            // 
            this.connectionStringOptionsBox.Location = new System.Drawing.Point(42, 113);
            this.connectionStringOptionsBox.Name = "connectionStringOptionsBox";
            this.connectionStringOptionsBox.Size = new System.Drawing.Size(229, 20);
            this.connectionStringOptionsBox.TabIndex = 4;
            this.connectionStringOptionsBox.TextChanged += new System.EventHandler(this.connectionStringOptionsBox_TextChanged);
            // 
            // connectionStringLabel
            // 
            this.connectionStringLabel.AutoSize = true;
            this.connectionStringLabel.Location = new System.Drawing.Point(59, 97);
            this.connectionStringLabel.Name = "connectionStringLabel";
            this.connectionStringLabel.Size = new System.Drawing.Size(160, 13);
            this.connectionStringLabel.TabIndex = 5;
            this.connectionStringLabel.Text = "PC Name SQL connection string";
            // 
            // ouOptionsBox
            // 
            this.ouOptionsBox.Location = new System.Drawing.Point(42, 165);
            this.ouOptionsBox.Name = "ouOptionsBox";
            this.ouOptionsBox.Size = new System.Drawing.Size(229, 20);
            this.ouOptionsBox.TabIndex = 6;
            this.ouOptionsBox.TextChanged += new System.EventHandler(this.ouOptionsBox_TextChanged);
            // 
            // ouLabel
            // 
            this.ouLabel.AutoSize = true;
            this.ouLabel.Location = new System.Drawing.Point(59, 149);
            this.ouLabel.Name = "ouLabel";
            this.ouLabel.Size = new System.Drawing.Size(176, 13);
            this.ouLabel.TabIndex = 7;
            this.ouLabel.Text = "Organizational Unit containing users";
            // 
            // editExeConfigButton
            // 
            this.editExeConfigButton.Location = new System.Drawing.Point(12, 285);
            this.editExeConfigButton.Name = "editExeConfigButton";
            this.editExeConfigButton.Size = new System.Drawing.Size(105, 23);
            this.editExeConfigButton.TabIndex = 8;
            this.editExeConfigButton.Text = "Edit exe.config";
            this.editExeConfigButton.UseVisualStyleBackColor = true;
            this.editExeConfigButton.Click += new System.EventHandler(this.editExeConfig_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 349);
            this.Controls.Add(this.editExeConfigButton);
            this.Controls.Add(this.ouLabel);
            this.Controls.Add(this.ouOptionsBox);
            this.Controls.Add(this.connectionStringLabel);
            this.Controls.Add(this.connectionStringOptionsBox);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.pcListPathBrowseButton);
            this.Controls.Add(this.listPathLabel);
            this.Controls.Add(this.listPathOptionsBox);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox listPathOptionsBox;
        private System.Windows.Forms.Label listPathLabel;
        private System.Windows.Forms.Button pcListPathBrowseButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TextBox connectionStringOptionsBox;
        private System.Windows.Forms.Label connectionStringLabel;
        private System.Windows.Forms.TextBox ouOptionsBox;
        private System.Windows.Forms.Label ouLabel;
        private System.Windows.Forms.Button editExeConfigButton;
    }
}