namespace DomainCommander
{
    partial class SkypeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkypeForm));
            this.usersNameLabel = new System.Windows.Forms.Label();
            this.userLoginLabel = new System.Windows.Forms.Label();
            this.phoneNumLabel = new System.Windows.Forms.Label();
            this.userPassLabel = new System.Windows.Forms.Label();
            this.skypeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.skypeLoginTextBox = new System.Windows.Forms.TextBox();
            this.skypePassTextBox = new System.Windows.Forms.TextBox();
            this.generatePassButton = new System.Windows.Forms.Button();
            this.usersNameTextBox = new System.Windows.Forms.TextBox();
            this.usersLoginTextBox = new System.Windows.Forms.TextBox();
            this.usersPhoneNumTextBox = new System.Windows.Forms.TextBox();
            this.usersPasswordTextBox = new System.Windows.Forms.TextBox();
            this.step1checkBox = new System.Windows.Forms.CheckBox();
            this.step2checkBox = new System.Windows.Forms.CheckBox();
            this.step3checkBox = new System.Windows.Forms.CheckBox();
            this.step4checkBox = new System.Windows.Forms.CheckBox();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.step5checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // usersNameLabel
            // 
            this.usersNameLabel.AutoSize = true;
            this.usersNameLabel.Location = new System.Drawing.Point(6, 128);
            this.usersNameLabel.Name = "usersNameLabel";
            this.usersNameLabel.Size = new System.Drawing.Size(67, 13);
            this.usersNameLabel.TabIndex = 0;
            this.usersNameLabel.Text = "User\'s Name";
            // 
            // userLoginLabel
            // 
            this.userLoginLabel.AutoSize = true;
            this.userLoginLabel.Location = new System.Drawing.Point(6, 167);
            this.userLoginLabel.Name = "userLoginLabel";
            this.userLoginLabel.Size = new System.Drawing.Size(65, 13);
            this.userLoginLabel.TabIndex = 1;
            this.userLoginLabel.Text = "User\'s Login";
            // 
            // phoneNumLabel
            // 
            this.phoneNumLabel.AutoSize = true;
            this.phoneNumLabel.Location = new System.Drawing.Point(6, 203);
            this.phoneNumLabel.Name = "phoneNumLabel";
            this.phoneNumLabel.Size = new System.Drawing.Size(78, 13);
            this.phoneNumLabel.TabIndex = 2;
            this.phoneNumLabel.Text = "Phone Number";
            // 
            // userPassLabel
            // 
            this.userPassLabel.AutoSize = true;
            this.userPassLabel.Location = new System.Drawing.Point(6, 242);
            this.userPassLabel.Name = "userPassLabel";
            this.userPassLabel.Size = new System.Drawing.Size(85, 13);
            this.userPassLabel.TabIndex = 3;
            this.userPassLabel.Text = "User\'s Password";
            // 
            // skypeLinkLabel
            // 
            this.skypeLinkLabel.AutoSize = true;
            this.skypeLinkLabel.Location = new System.Drawing.Point(167, 19);
            this.skypeLinkLabel.Name = "skypeLinkLabel";
            this.skypeLinkLabel.Size = new System.Drawing.Size(127, 13);
            this.skypeLinkLabel.TabIndex = 5;
            this.skypeLinkLabel.TabStop = true;
            this.skypeLinkLabel.Text = "Skype Business Manager";
            this.skypeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.skypeLinkLabel_LinkClicked);
            // 
            // skypeLoginTextBox
            // 
            this.skypeLoginTextBox.Location = new System.Drawing.Point(156, 35);
            this.skypeLoginTextBox.Name = "skypeLoginTextBox";
            this.skypeLoginTextBox.Size = new System.Drawing.Size(151, 20);
            this.skypeLoginTextBox.TabIndex = 6;
            this.skypeLoginTextBox.Text = "helpdesk.idsolutions-inc.com";
            this.skypeLoginTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.skypeLoginTextBox.WordWrap = false;
            // 
            // skypePassTextBox
            // 
            this.skypePassTextBox.Location = new System.Drawing.Point(156, 61);
            this.skypePassTextBox.Name = "skypePassTextBox";
            this.skypePassTextBox.Size = new System.Drawing.Size(151, 20);
            this.skypePassTextBox.TabIndex = 7;
            this.skypePassTextBox.Text = "IDShelpdesk2012";
            this.skypePassTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.skypePassTextBox.WordWrap = false;
            // 
            // generatePassButton
            // 
            this.generatePassButton.Location = new System.Drawing.Point(156, 266);
            this.generatePassButton.Name = "generatePassButton";
            this.generatePassButton.Size = new System.Drawing.Size(206, 23);
            this.generatePassButton.TabIndex = 8;
            this.generatePassButton.Text = "Generate Password";
            this.generatePassButton.UseVisualStyleBackColor = true;
            this.generatePassButton.Click += new System.EventHandler(this.generatePassButton_Click);
            // 
            // usersNameTextBox
            // 
            this.usersNameTextBox.Location = new System.Drawing.Point(156, 126);
            this.usersNameTextBox.Name = "usersNameTextBox";
            this.usersNameTextBox.Size = new System.Drawing.Size(253, 20);
            this.usersNameTextBox.TabIndex = 9;
            // 
            // usersLoginTextBox
            // 
            this.usersLoginTextBox.Location = new System.Drawing.Point(156, 165);
            this.usersLoginTextBox.Name = "usersLoginTextBox";
            this.usersLoginTextBox.Size = new System.Drawing.Size(253, 20);
            this.usersLoginTextBox.TabIndex = 10;
            // 
            // usersPhoneNumTextBox
            // 
            this.usersPhoneNumTextBox.Location = new System.Drawing.Point(156, 201);
            this.usersPhoneNumTextBox.Name = "usersPhoneNumTextBox";
            this.usersPhoneNumTextBox.Size = new System.Drawing.Size(253, 20);
            this.usersPhoneNumTextBox.TabIndex = 11;
            // 
            // usersPasswordTextBox
            // 
            this.usersPasswordTextBox.Location = new System.Drawing.Point(156, 240);
            this.usersPasswordTextBox.Name = "usersPasswordTextBox";
            this.usersPasswordTextBox.Size = new System.Drawing.Size(253, 20);
            this.usersPasswordTextBox.TabIndex = 12;
            // 
            // step1checkBox
            // 
            this.step1checkBox.AutoSize = true;
            this.step1checkBox.Location = new System.Drawing.Point(9, 298);
            this.step1checkBox.Name = "step1checkBox";
            this.step1checkBox.Size = new System.Drawing.Size(120, 17);
            this.step1checkBox.TabIndex = 13;
            this.step1checkBox.Text = "1. Account Creation";
            this.step1checkBox.UseVisualStyleBackColor = true;
            this.step1checkBox.CheckedChanged += new System.EventHandler(this.step1checkBox_CheckedChanged);
            // 
            // step2checkBox
            // 
            this.step2checkBox.AutoSize = true;
            this.step2checkBox.Location = new System.Drawing.Point(9, 321);
            this.step2checkBox.Name = "step2checkBox";
            this.step2checkBox.Size = new System.Drawing.Size(130, 17);
            this.step2checkBox.TabIndex = 14;
            this.step2checkBox.Text = "2. Assign Subscription";
            this.step2checkBox.UseVisualStyleBackColor = true;
            this.step2checkBox.CheckedChanged += new System.EventHandler(this.step2checkBox_CheckedChanged);
            // 
            // step3checkBox
            // 
            this.step3checkBox.AutoSize = true;
            this.step3checkBox.Location = new System.Drawing.Point(9, 344);
            this.step3checkBox.Name = "step3checkBox";
            this.step3checkBox.Size = new System.Drawing.Size(142, 17);
            this.step3checkBox.TabIndex = 15;
            this.step3checkBox.Text = "3. Assign Skype Number";
            this.step3checkBox.UseVisualStyleBackColor = true;
            this.step3checkBox.CheckedChanged += new System.EventHandler(this.step3checkBox_CheckedChanged);
            // 
            // step4checkBox
            // 
            this.step4checkBox.AutoSize = true;
            this.step4checkBox.Location = new System.Drawing.Point(9, 367);
            this.step4checkBox.Name = "step4checkBox";
            this.step4checkBox.Size = new System.Drawing.Size(129, 17);
            this.step4checkBox.TabIndex = 16;
            this.step4checkBox.Text = "4. Shoreware Director";
            this.step4checkBox.UseVisualStyleBackColor = true;
            this.step4checkBox.CheckedChanged += new System.EventHandler(this.step4checkBox_CheckedChanged);
            // 
            // infoTextBox
            // 
            this.infoTextBox.AcceptsReturn = true;
            this.infoTextBox.Location = new System.Drawing.Point(156, 296);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoTextBox.Size = new System.Drawing.Size(253, 238);
            this.infoTextBox.TabIndex = 18;
            this.infoTextBox.Text = resources.GetString("infoTextBox.Text");
            // 
            // step5checkBox
            // 
            this.step5checkBox.AutoSize = true;
            this.step5checkBox.Location = new System.Drawing.Point(9, 390);
            this.step5checkBox.Name = "step5checkBox";
            this.step5checkBox.Size = new System.Drawing.Size(129, 17);
            this.step5checkBox.TabIndex = 19;
            this.step5checkBox.Text = "5. Shoreware Director";
            this.step5checkBox.UseVisualStyleBackColor = true;
            this.step5checkBox.CheckedChanged += new System.EventHandler(this.step5checkBox_CheckedChanged);
            // 
            // SkypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 548);
            this.Controls.Add(this.step5checkBox);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.step4checkBox);
            this.Controls.Add(this.step3checkBox);
            this.Controls.Add(this.step2checkBox);
            this.Controls.Add(this.step1checkBox);
            this.Controls.Add(this.usersPasswordTextBox);
            this.Controls.Add(this.usersPhoneNumTextBox);
            this.Controls.Add(this.usersLoginTextBox);
            this.Controls.Add(this.usersNameTextBox);
            this.Controls.Add(this.generatePassButton);
            this.Controls.Add(this.skypePassTextBox);
            this.Controls.Add(this.skypeLoginTextBox);
            this.Controls.Add(this.skypeLinkLabel);
            this.Controls.Add(this.userPassLabel);
            this.Controls.Add(this.phoneNumLabel);
            this.Controls.Add(this.userLoginLabel);
            this.Controls.Add(this.usersNameLabel);
            this.Name = "SkypeForm";
            this.Text = "Add Skype User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usersNameLabel;
        private System.Windows.Forms.Label userLoginLabel;
        private System.Windows.Forms.Label phoneNumLabel;
        private System.Windows.Forms.Label userPassLabel;
        private System.Windows.Forms.LinkLabel skypeLinkLabel;
        private System.Windows.Forms.TextBox skypeLoginTextBox;
        private System.Windows.Forms.TextBox skypePassTextBox;
        private System.Windows.Forms.Button generatePassButton;
        private System.Windows.Forms.TextBox usersNameTextBox;
        private System.Windows.Forms.TextBox usersLoginTextBox;
        private System.Windows.Forms.TextBox usersPhoneNumTextBox;
        private System.Windows.Forms.TextBox usersPasswordTextBox;
        private System.Windows.Forms.CheckBox step1checkBox;
        private System.Windows.Forms.CheckBox step2checkBox;
        private System.Windows.Forms.CheckBox step3checkBox;
        private System.Windows.Forms.CheckBox step4checkBox;
        private System.Windows.Forms.TextBox infoTextBox;
        private System.Windows.Forms.CheckBox step5checkBox;
    }
}