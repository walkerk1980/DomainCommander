using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;
using System.IO;

namespace DomainCommander
{
    class EmailTools : CommonTools
    {
        public void ExchangeTest()
        {
            RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
            PSSnapInException snapInException = null;
            PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
            Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
            myRunSpace.Open();
            Pipeline ps = myRunSpace.CreatePipeline();

            Command myCommand = new Command("Get-Mailbox");
            CommandParameter verbParam = new CommandParameter("Identity", "kwalker");
            myCommand.Parameters.Add(verbParam);
            ps.Commands.Add(myCommand);

            // Call the PowerShell.Invoke() method to run the 
            // commands of the pipeline.
            StringBuilder output = new StringBuilder();
            foreach (PSObject result in ps.Invoke())
            {
                output.AppendLine(result.ToString());
                

            } // End foreach.
            MessageBox.Show(output.ToString());

            myRunSpace.Dispose();
        }

        public void SendTerminationEmail(string terminatedUser, string fQDomainName, string ou)
        {
            UserTools ut = new UserTools();
            String terminatedUserFullName = ut.GetFullName(terminatedUser, fullyQualifiedDomainName, organizationalUnit);
            String terminatedUserManager = ut.GetManager(terminatedUser, fullyQualifiedDomainName, organizationalUnit);
            bool qcmcUser = false;
            String terminatedUserCompany = ut.GetCompany(terminatedUser, fullyQualifiedDomainName, organizationalUnit);
            if (terminatedUserCompany.Contains("qcmc") || terminatedUserCompany.Contains("QCMC") || terminatedUserCompany.Contains("Claims") || terminatedUserCompany.Contains("claims"))
            {
                qcmcUser = true;
            }

            DialogResult yesNoDialog;
            yesNoDialog = MessageBox.Show("Send termination email for user: " + terminatedUserFullName + "\nManager Name: " + terminatedUserManager + "\nCompany: " + terminatedUserCompany, "Confirm correct User and Manager", MessageBoxButtons.YesNo);

            if (yesNoDialog == DialogResult.Yes)
            {
                String currentUserEmailAddress = ut.GetEmailAddress(System.Security.Principal.WindowsIdentity.GetCurrent().Name, fullyQualifiedDomainName, organizationalUnit);

                String terminatedUserManagerEmailAddress = ut.GetEmailAddress(terminatedUserManager, fullyQualifiedDomainName, organizationalUnit);
                String termBody = GetTerminationEmailBodyFromFile(qcmcUser);
                termBody = termBody.Replace("INSERT USER NAME", terminatedUserFullName);
                System.Net.Mail.MailMessage termEmail = new System.Net.Mail.MailMessage();
                termEmail.IsBodyHtml = true;
                termEmail.To.Add(terminatedUserManagerEmailAddress);
                termEmail.Subject = "Disabled Employee: " + terminatedUserFullName;
                termEmail.From = new System.Net.Mail.MailAddress(currentUserEmailAddress);
                foreach (string email in Properties.Settings.Default.terminateEmailList)
                {
                    termEmail.Bcc.Add(email);
                }
                
                if (qcmcUser)
                {
                    termEmail.CC.Add("Systems@QualityClaims.com");
                }
                termEmail.Body = termBody;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Properties.Settings.Default.mailServer);
                smtp.Send(termEmail);
            }
            else
            {
                MessageBox.Show("If incorrect Company or Manager is not listed please correct in Active Directory and try again");
            }

        }

        public void SendTestTerminationEmail(string terminatedUser, string fQDomainName, string ou)
        {
            UserTools ut = new UserTools();
            String terminatedUserFullName = ut.GetFullName(terminatedUser, fullyQualifiedDomainName, organizationalUnit);
            String terminatedUserManager = ut.GetManager(terminatedUser, fullyQualifiedDomainName, organizationalUnit);
            bool qcmcUser = false;
            String terminatedUserCompany = ut.GetCompany(terminatedUser, fullyQualifiedDomainName, organizationalUnit);
            if (terminatedUserCompany.Contains("qcmc") || terminatedUserCompany.Contains("QCMC") || terminatedUserCompany.Contains("Claims") || terminatedUserCompany.Contains("claims"))
            {
                qcmcUser = true;
            }

            DialogResult yesNoDialog;
            yesNoDialog = MessageBox.Show("Send termination email for user: " + terminatedUserFullName + "\nManager Name: " + terminatedUserManager + "\nCompany: " + terminatedUserCompany, "Confirm correct User and Manager", MessageBoxButtons.YesNo);

            if (yesNoDialog == DialogResult.Yes)
            {
                String currentUserEmailAddress = ut.GetEmailAddress(System.Security.Principal.WindowsIdentity.GetCurrent().Name, fullyQualifiedDomainName, organizationalUnit);
                String termBody = GetTerminationEmailBodyFromFile(qcmcUser);
                termBody = termBody.Replace("INSERT USER NAME", terminatedUserFullName);
                System.Net.Mail.MailMessage termEmail = new System.Net.Mail.MailMessage();
                termEmail.IsBodyHtml = true;
                termEmail.BodyEncoding = System.Text.Encoding.UTF8;
                termEmail.To.Add(currentUserEmailAddress);
                termEmail.Subject = "Disabled Employee: " + terminatedUserFullName;
                termEmail.From = new System.Net.Mail.MailAddress(currentUserEmailAddress);
                termEmail.Body = termBody;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Properties.Settings.Default.mailServer);
                smtp.Send(termEmail);
            }
            else
            {
                MessageBox.Show("If incorrect Company or Manager is listed please correct in Active Directory and try again");
            }

        }

        private String GetTerminationEmailBodyFromFile(bool qcmcUser)
        {
            String messageBody = null;
            string termEmailFileName;
            if (qcmcUser == true)
            {
                termEmailFileName = System.Windows.Forms.Application.StartupPath.ToString() + "\\Text\\terminationQCMC.htm";
            }
            else
            {
                termEmailFileName = System.Windows.Forms.Application.StartupPath.ToString() + "\\Text\\termination.htm";
            }
            try
            {
                if (File.Exists(termEmailFileName))
                {
                    using (StreamReader reader = new StreamReader(termEmailFileName))
                    {
                        if (!reader.EndOfStream)
                        {
                            List<String> pcNameLines = new List<String>();
                            while (!reader.EndOfStream)
                            {
                                messageBody = reader.ReadToEnd();
                            }
                        }
                        reader.Close();
                        reader.Dispose();
                        return messageBody;
                    }
                }
            }
            catch(Exception messageBodyFromFileException)
            {
                MessageBox.Show(messageBodyFromFileException.Message);
                return messageBody;
            }

            return messageBody;
        }

        public void testPowerShell()
        {
            RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
            PSSnapInException snapInException = null;
            PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
            Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
            myRunSpace.Open();
            Pipeline ps = myRunSpace.CreatePipeline();

            Command myCommand = new Command("Get-Mailbox");
            CommandParameter verbParam = new CommandParameter("Identity", "kwalker");
            myCommand.Parameters.Add(verbParam);
            ps.Commands.Add(myCommand);

            // Call the PowerShell.Invoke() method to run the 
            // commands of the pipeline.
            StringBuilder output = new StringBuilder();
            foreach (PSObject result in ps.Invoke())
            {
                output.AppendLine(result.ToString());
                

            } // End foreach.
            MessageBox.Show(output.ToString());

            myRunSpace.Dispose();
        }

        public List<string> getMailbox(string user)
        {
            if (!string.IsNullOrEmpty(user))
            {
                RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
                PSSnapInException snapInException = null;
                try
                {
                    PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
                }
                catch (Exception ExchangeSnapInException)
                {
                    MessageBox.Show(ExchangeSnapInException.Message);
                }
                try
                {
                    Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
                    myRunSpace.Open();
                    Pipeline ps = myRunSpace.CreatePipeline();

                    Command getMailboxCommand = new Command("Get-Mailbox");
                    CommandParameter getMailboxArgs = new CommandParameter("Identity", user);
                    getMailboxCommand.Parameters.Add(getMailboxArgs);
                    ps.Commands.Add(getMailboxCommand);

                    Command flCommand = new Command("fl");
                    ps.Commands.Add(flCommand);

                    Command outStringCommand = new Command("Out-String");
                    CommandParameter outStringArgs = new CommandParameter("Stream");
                    outStringCommand.Parameters.Add(outStringArgs);
                    ps.Commands.Add(outStringCommand);

                    List<string> output = new List<string>();
                    foreach (PSObject result in ps.Invoke())
                    {
                        output.Add(result.ToString());
                    }

                    myRunSpace.Dispose();
                    return output;
                }
                catch (Exception GetMailboxException)
                {
                    MessageBox.Show(GetMailboxException.Message);
                    List<string> output = new List<string>();
                    output.Add("Nothing to show here, install Exchange Managment tools.");
                    return output;
                }

            }
            else
            {
                List<string> output = new List<string>();
                output.Add("No user specified!");
                return output;
            }
        }

        public List<string> getBlockedSenders()
        {
            RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
            PSSnapInException snapInException = null;
            PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
            Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
            myRunSpace.Open();
            Pipeline ps = myRunSpace.CreatePipeline();

            Command getSenderFilterConfigCommand = new Command("Get-SenderFilterConfig");
            ps.Commands.Add(getSenderFilterConfigCommand);

            Command selectObjectCommand = new Command("Select-Object");
            CommandParameter selectObjectArgs = new CommandParameter("ExpandProperty", "BlockedSenders");
            selectObjectCommand.Parameters.Add(selectObjectArgs);
            ps.Commands.Add(selectObjectCommand);

            Command outStringCommand = new Command("Out-String");
            CommandParameter outStringArgs = new CommandParameter("Stream");
            outStringCommand.Parameters.Add(outStringArgs);
            ps.Commands.Add(outStringCommand);

            List<string> output = new List<string>();
            foreach (PSObject result in ps.Invoke())
            {
                output.Add(result.ToString());
            }

            myRunSpace.Dispose();
            return output;
        }

        public List<string> getWhitelistedSenders()
        {
            RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
            PSSnapInException snapInException = null;
            PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
            Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
            myRunSpace.Open();
            Pipeline ps = myRunSpace.CreatePipeline();

            Command getContentFilterConfigCommand = new Command("Get-ContentFilterConfig");
            ps.Commands.Add(getContentFilterConfigCommand);

            Command selectObjectCommand = new Command("Select-Object");
            CommandParameter selectObjectArgs = new CommandParameter("ExpandProperty", "BypassedSenders");
            selectObjectCommand.Parameters.Add(selectObjectArgs);
            ps.Commands.Add(selectObjectCommand);

            Command outStringCommand = new Command("Out-String");
            CommandParameter outStringArgs = new CommandParameter("Stream");
            outStringCommand.Parameters.Add(outStringArgs);
            ps.Commands.Add(outStringCommand);

            List<string> output = new List<string>();
            foreach (PSObject result in ps.Invoke())
            {
                output.Add(result.ToString());
            }

            myRunSpace.Dispose();
            return output;
        }

        public List<string> getBlacklistedDomains()
        {
            RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
            PSSnapInException snapInException = null;
            PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
            Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
            myRunSpace.Open();
            Pipeline ps = myRunSpace.CreatePipeline();

            Command getSenderFilterConfigCommand = new Command("Get-SenderFilterConfig");
            ps.Commands.Add(getSenderFilterConfigCommand);

            Command selectObjectCommand = new Command("Select-Object");
            CommandParameter selectObjectArgs = new CommandParameter("ExpandProperty", "BlockedDomains");
            selectObjectCommand.Parameters.Add(selectObjectArgs);
            ps.Commands.Add(selectObjectCommand);

            Command outStringCommand = new Command("Out-String");
            CommandParameter outStringArgs = new CommandParameter("Stream");
            outStringCommand.Parameters.Add(outStringArgs);
            ps.Commands.Add(outStringCommand);

            List<string> output = new List<string>();
            foreach (PSObject result in ps.Invoke())
            {
                output.Add(result.ToString());
            }

            myRunSpace.Dispose();
            return output;
        }

        public List<string> getWhitelistedDomains()
        {
            RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
            PSSnapInException snapInException = null;
            PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
            Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
            myRunSpace.Open();
            Pipeline ps = myRunSpace.CreatePipeline();

            Command getContentFilterConfigCommand = new Command("Get-ContentFilterConfig");
            ps.Commands.Add(getContentFilterConfigCommand);

            Command selectObjectCommand = new Command("Select-Object");
            CommandParameter selectObjectArgs = new CommandParameter("ExpandProperty", "BypassedSenderDomains");
            selectObjectCommand.Parameters.Add(selectObjectArgs);
            ps.Commands.Add(selectObjectCommand);

            Command outStringCommand = new Command("Out-String");
            CommandParameter outStringArgs = new CommandParameter("Stream");
            outStringCommand.Parameters.Add(outStringArgs);
            ps.Commands.Add(outStringCommand);

            List<string> output = new List<string>();
            foreach (PSObject result in ps.Invoke())
            {
                output.Add(result.ToString());
            }

            myRunSpace.Dispose();
            return output;
        }

        public List<string> getJunkEmailConfig(string user)
        {
            if (!string.IsNullOrEmpty(user))
            {
                RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
                PSSnapInException snapInException = null;
                PSSnapInInfo info = rsConfig.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out snapInException);
                Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
                myRunSpace.Open();
                Pipeline ps0 = myRunSpace.CreatePipeline();
                Pipeline ps1 = myRunSpace.CreatePipeline();
                Pipeline ps2 = myRunSpace.CreatePipeline();

                Command getMailboxJunkCommand = new Command("Get-MailboxJunkEmailConfiguration");
                CommandParameter getMailboxJunkArgs = new CommandParameter("Identity", user);
                getMailboxJunkCommand.Parameters.Add(getMailboxJunkArgs);
                ps0.Commands.Add(getMailboxJunkCommand);

                Command selectObjectCommand = new Command("Select-Object");
                CommandParameter selectObjectArgs = new CommandParameter("ExpandProperty", "TrustedSendersAndDomains");
                selectObjectCommand.Parameters.Add(selectObjectArgs);
                ps0.Commands.Add(selectObjectCommand);

                Command outStringCommand = new Command("Out-String");
                CommandParameter outStringArgs = new CommandParameter("Stream");
                outStringCommand.Parameters.Add(outStringArgs);
                ps0.Commands.Add(outStringCommand);

                List<string> output = new List<string>();
                foreach (PSObject result in ps0.Invoke())
                {
                    output.Add(result.ToString());
                }

                myRunSpace.Dispose();
                return output;
            }
            else
            {
                List<string> output = new List<string>();
                output.Add("No user specified!");
                return output;
            }
        }



    }
}
