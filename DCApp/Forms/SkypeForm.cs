using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DomainCommander
{
    public partial class SkypeForm : Form
    {
        public SkypeForm()
        {
            InitializeComponent();
        }
        public string step1string, step2string, step3string, step4string, step5string;

        private void skypeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LocalApplications lt = new LocalApplications();
            lt.skypeWebsite();
        }

        private void generatePassButton_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            usersPasswordTextBox.Text = ut.RandomPassword(7).ToUpperInvariant();
        }

        private void step1checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!step2checkBox.Checked && !step3checkBox.Checked && !step4checkBox.Checked)
            {
                step2string = @"Step 2. Assign Skype Subscription:

2.1	Click Features

2.2	Click Subscriptions

2.3	Scroll to the new user

2.4	Click Allocate a subscription to this member to the right of the users name

2.5	Click the Annually (12 Months) Save 15% button (very important step) then click Buy now";
                infoTextBox.Text = step2string;
            }
            if (!step1checkBox.Checked && !step2checkBox.Checked && !step3checkBox.Checked && !step4checkBox.Checked)
            {
                step1string = @"Step 1. Account Creation:

1.1 Login to Skype Manager

1.2 Click Members

1.3 Click Create accounts

1.4 Enter Email Address click next

1.5 Click Edit to the right of the Skype Name  

1.6 Use the users email address but replace the " + @"'@'" + " sign with a " + @"'.'" + @"

1.7 Fill in the users full name, exclude middle names and initials

1.8 Use the password generator for the password

1.9 Click the drop down menu and select the Romania group then click Create accounts";
                infoTextBox.Text = step1string;
            }
        }

        private void step2checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!step3checkBox.Checked && !step4checkBox.Checked)
            {
                step3string = @"Step 3. Assign Skype Number:

3.1	Click Skype Numbers

3.2	Scroll to the new user

3.3	Click Allocate this member a Skype Number to the right of the users name

3.4	If available, use a pre-existing number from the drop down menu

3.5	If no number is available click Buy a new number and ensure it is Annual

3.6	Go to the users account by clicking their name

3.7	Click Set up Caller ID

3.8	Click Save Settings (the Skype Online Number that you just assigned will be selected by default)";
                infoTextBox.Text = step3string;
            }
        }

        private void step3checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!step4checkBox.Checked)
            {
                step4string = @"Step 4: ShoreWare System Directory

4.1	Click System Directory

4.2	Click the New… button

4.3	Enter First Name

4.4	Enter Last Name and put RO behind the name (e.g. Brant RO)

4.5	Enter Work Phone as the users new Skype Number and click Save";
                infoTextBox.Text = step4string;
            }
        }

        private void step5checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void step4checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!step5checkBox.Checked)
            {
                step5string = @"Step 5. Inform Oana Greceanu
OGreceanu@mccarthy-holthus.com

5.1	Reply to her email with the new users:

5.2	Skype Login

5.3	Skype Password

5.4	Skype Number";
                infoTextBox.Text = step5string;
            }
        }
    }
}
