namespace DomainCommander
{
    partial class ChatForm
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
            this.textEntryBox = new System.Windows.Forms.TextBox();
            this.participantListBox = new System.Windows.Forms.ListBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.textWindowBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textEntryBox
            // 
            this.textEntryBox.Location = new System.Drawing.Point(12, 412);
            this.textEntryBox.Name = "textEntryBox";
            this.textEntryBox.Size = new System.Drawing.Size(382, 20);
            this.textEntryBox.TabIndex = 0;
            // 
            // participantListBox
            // 
            this.participantListBox.FormattingEnabled = true;
            this.participantListBox.Location = new System.Drawing.Point(482, 12);
            this.participantListBox.Name = "participantListBox";
            this.participantListBox.Size = new System.Drawing.Size(120, 420);
            this.participantListBox.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(401, 412);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // textWindowBox
            // 
            this.textWindowBox.Location = new System.Drawing.Point(12, 12);
            this.textWindowBox.Multiline = true;
            this.textWindowBox.Name = "textWindowBox";
            this.textWindowBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textWindowBox.Size = new System.Drawing.Size(464, 394);
            this.textWindowBox.TabIndex = 3;
            this.textWindowBox.Text = "Not yet functional.";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 453);
            this.Controls.Add(this.textWindowBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.participantListBox);
            this.Controls.Add(this.textEntryBox);
            this.Name = "ChatForm";
            this.Text = "Help Desk Chat";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textEntryBox;
        private System.Windows.Forms.ListBox participantListBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox textWindowBox;
    }
}