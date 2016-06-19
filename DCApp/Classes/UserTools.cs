using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Management.Automation.Runspaces;
using System.Text;


namespace DomainCommander
{
    public class UserTools : CommonTools
    {

        public List<string> GetADUserInfo(string user, string fQDomainName, string ou)
        {
            List<string> resultList = new List<string>();
            if (!string.IsNullOrEmpty(user))
            {

                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        resultList.Add("NAME:\t\t" + usr.DisplayName);
                        resultList.Add("TITLE:\t\t" + usr.title);
                        resultList.Add("DEPARTMENT:\t" + usr.department);
                        resultList.Add("COMPANY:\t" + usr.company);
                        resultList.Add("OFFICE:\t\t" + usr.office);
                        resultList.Add("EMAIL:\t\t" + usr.EmailAddress);
                        resultList.Add("LOGIN:\t\t" + usr.SamAccountName);
                        resultList.Add("PROFILE:\t" + usr.HomeDirectory);
                        if(!string.IsNullOrEmpty(usr.Description))
                        {
                            resultList.Add("DESCRIPTION:\t" + usr.Description);
                        }
                        usr.Dispose();
                    }
                    else resultList.Add("");
                    ctx.Dispose();
                    return resultList;
                }

                catch (Exception unlockException)
                {
                    MessageBox.Show(unlockException.Message);
                    resultList.Add("");
                    return resultList;
                }
            }
            else resultList.Add("");
            return resultList;
        }

        public string GetSamAccountName(string user, string fQDomainName, string ou)
        {
            string samAccountName;
            if (!string.IsNullOrEmpty(user))
            {

                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        samAccountName = usr.SamAccountName.ToString();
                        usr.Dispose();
                    }
                    else samAccountName = "";
                    ctx.Dispose();
                    return samAccountName;
                }

                catch (Exception getSamAccountNameException)
                {
                    MessageBox.Show(getSamAccountNameException.Message);
                    samAccountName = "";
                    return samAccountName;
                }
            }
            else samAccountName = "";
            return samAccountName;
        }

        public string GetFullName(string user, string fQDomainName, string ou)
        {
            string fullName;
            if (!string.IsNullOrEmpty(user))
            {

                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        fullName = usr.Name.ToString();
                        usr.Dispose();
                    }
                    else fullName = "";
                    ctx.Dispose();
                    return fullName;
                }

                catch (Exception getFullNameException)
                {
                    MessageBox.Show(getFullNameException.Message);
                    fullName = "";
                    return fullName;
                }
            }
            else fullName = "";
            return fullName;
        }

        public string GetEmailAddress(string user, string fQDomainName, string ou)
        {
            string emailAddress;
            if (!string.IsNullOrEmpty(user))
            {

                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        emailAddress = usr.EmailAddress.ToString();
                        usr.Dispose();
                    }
                    else emailAddress = "";
                    ctx.Dispose();
                    return emailAddress;
                }

                catch (Exception getEmailException)
                {
                    MessageBox.Show(getEmailException.Message);
                    emailAddress = "";
                    return emailAddress;
                }
            }
            else emailAddress = "";
            return emailAddress;
        }

        public string GetManager(string user, string fQDomainName, string ou)
        {
            string managerName;
            if (!string.IsNullOrEmpty(user))
            {

                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        managerName = GetFullName(usr.manager, fullyQualifiedDomainName, organizationalUnit);
                        usr.Dispose();
                    }
                    else managerName = "";
                    ctx.Dispose();
                    return managerName;
                }

                catch (Exception getManager)
                {
                    MessageBox.Show(getManager.Message);
                    managerName = "";
                    return managerName;
                }
            }
            else managerName = "";
            return managerName;
        }

        public string GetCompany(string user, string fQDomainName, string ou)
        {
            string company;
            if (!string.IsNullOrEmpty(user))
            {

                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        company = usr.company.ToString();
                        usr.Dispose();
                    }
                    else company = "";
                    ctx.Dispose();
                    return company;
                }

                catch
                {
                    MessageBox.Show("Warning: Company not set!");
                    company = "";
                    return company;
                }
            }
            else company = "";
            return company;
        }

        public void UnlockUser(string user, string fQDomainName, string ou)
        {
            if (!string.IsNullOrEmpty(user))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        if (usr.IsAccountLockedOut())
                        {
                            usr.UnlockAccount();
                            MessageBox.Show(usr.DisplayName + "'s account unlocked");
                        }
                        else
                        {
                            MessageBox.Show(usr.DisplayName + "'s account not locked, " + "last logon at " + usr.LastLogon.ToString() + ", " + "user has " + usr.BadLogonCount.ToString() + " bad password attempts.");
                        }
                        usr.Dispose();
                    }
                    ctx.Dispose();
                }

                catch (Exception unlockException)
                {
                    MessageBox.Show(unlockException.Message);
                }
            }
        }

        public void ResetUsersPassword(string user, string fQDomainName, string ou)
        {
            if (!string.IsNullOrEmpty(user))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);
                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        DialogResult yesNoDialog;
                        string resetPasswordString = "Are you sure you want to reset " + usr.DisplayName + "'s password?";
                        yesNoDialog = MessageBox.Show(resetPasswordString, "Password Reset", MessageBoxButtons.YesNo);
                        if (yesNoDialog == DialogResult.Yes)
                        {
                            usr.SetPassword("Password1");
                            usr.ExpirePasswordNow();
                            MessageBox.Show(usr.DisplayName + "'s password has been reset.");
                        }
                        if (usr.IsAccountLockedOut())
                        {
                            usr.UnlockAccount();
                            MessageBox.Show(usr.DisplayName + "'s account unlocked");
                        }
                        usr.Dispose();
                    }
                    ctx.Dispose();

                }
                catch (Exception unlockException)
                {
                    MessageBox.Show(unlockException.Message);
                }
            }
        }

        public void PsLoggedOn(string psLoggedOnArgs, string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                DialogResult yesNoDialog;
                yesNoDialog = MessageBox.Show("Would you like to run psLoggedIn also?", "psLoggedOn?", MessageBoxButtons.YesNo);

                if (yesNoDialog == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.EnableRaisingEvents = false;
                        proc.StartInfo.FileName = "psLoggedOn";
                        proc.StartInfo.UseShellExecute = false;
                        if (PcNameIsNotNullOrVoid(pcname))
                        {
                            proc.StartInfo.Arguments = " " + backslashes + pcname + " " + psLoggedOnArgs;
                        }
                        proc.StartInfo.RedirectStandardOutput = true;
                        proc.Start();
                        //string tasklist = proc.StandardOutput.ReadToEnd();
                        MessageBox.Show(proc.StandardOutput.ReadToEnd());
                        //proc.WaitForExit();
                    }
                    catch (Exception tasklistException)
                    {
                        MessageBox.Show(tasklistException.Message);
                    }
                }
            }
        }

        public List<string> GetGroups(string user, string fQDomainName, string ou)
        {
            List<string> groupList = new List<string>();
            if (!string.IsNullOrEmpty(user))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        var groups = usr.GetGroups();
                        foreach (Object gr in groups)
                        {
                            groupList.Add(gr.ToString());
                            //MessageBox.Show(gr.ToString());
                        }
                        usr.Dispose();
                    }
                    ctx.Dispose();
                    return groupList;
                }

                catch (Exception unlockException)
                {
                    MessageBox.Show(unlockException.Message);
                    return groupList;
                }
            }
            return groupList;
        }

        public void DisableAccount(string user, string fQDomainName, string ou)
        {
            if (!string.IsNullOrEmpty(user))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        DialogResult yesNoDialog;
                        string disableAccountString = "Are you sure you want to disable " + usr.DisplayName + "'s account?";
                        string userInfoString = "\n\nUSER INFO:\n" + "\nName:\t\t" + usr.DisplayName + "\nTitle:\t\t" + usr.title + "\nDepartment\t" + usr.department + "\nCompany:\t" + usr.company + "\nOffice:\t\t" + usr.office + "\nEmail:\t\t" + usr.EmailAddress + "\nLogin:\t\t" + usr.SamAccountName + "\nDescription:\t" + usr.Description;
                        yesNoDialog = MessageBox.Show(disableAccountString + userInfoString, "Disable Account?", MessageBoxButtons.YesNo);

                        if (yesNoDialog == DialogResult.Yes)
                        {
                            if (usr.Enabled == true)
                            {
                                usr.Enabled = false;
                                usr.SetPassword("sdP32*&^kna0^d$");
                                string toDay = DateTime.Today.Date.ToString();
                                usr.Description = "disabled " + toDay.Substring(0, toDay.IndexOf(" ")) + " " + Environment.UserName;
                                usr.Save();

                                MessageBox.Show(usr.DisplayName + "'s account has been disabled");

                                string removeGroupsString = "Would you like to remove " + usr.DisplayName + " from all AD groups and move to Disabled Users OU?";
                                yesNoDialog = MessageBox.Show(removeGroupsString, "Remove AD Groups?", MessageBoxButtons.YesNo);
                                if (yesNoDialog == DialogResult.Yes)
                                {
                                    RemoveUserFromAllGroups(user, fQDomainName, ou);
                                    MoveToDisabledUsersOU(usr.DistinguishedName, disabledUsersOU);
                                    MessageBox.Show(usr.DisplayName + " has been removed from all AD groups and moved to Disabled Users.");
                                }
                                string deleteTSProfilesString = "Would you like to delete " + usr.DisplayName + "'s profiles from all the Terminal Servers?";
                                yesNoDialog = MessageBox.Show(deleteTSProfilesString, "Delete TS Profiles?", MessageBoxButtons.YesNo);
                                if (yesNoDialog == DialogResult.Yes)
                                {
                                    DiskTools dt = new DiskTools();
                                    dt.DeleteTSProfiles(usr.SamAccountName.ToLower());
                                    MessageBox.Show(usr.DisplayName + "'s profiles are being deleted from all terminal servers.");
                                }
                            }
                            else
                            {
                                MessageBox.Show(usr.DisplayName + "'s account is already disabled");
                            }

                        }

                        usr.Dispose();
                    }
                    ctx.Dispose();
                }

                catch (Exception unlockException)
                {
                    MessageBox.Show(unlockException.Message);
                }
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }

        public void DisableAccountTemp(string user, string fQDomainName, string ou)
        {
            if (!string.IsNullOrEmpty(user))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);


                    if (usr != null)
                    {
                        DialogResult yesNoDialog;
                        string disableAccountString = "Are you sure you want to temporarily disable " + usr.DisplayName + "'s account?";
                        string userInfoString = "\n\nUSER INFO:\n" + "\nName:\t\t" + usr.DisplayName + "\nTitle:\t\t" + usr.title + "\nDepartment\t" + usr.department + "\nCompany:\t" + usr.company + "\nOffice:\t\t" + usr.office + "\nEmail:\t\t" + usr.EmailAddress + "\nLogin:\t\t" + usr.SamAccountName + "\nDescription:\t" + usr.Description;
                        yesNoDialog = MessageBox.Show(disableAccountString + userInfoString, "Temporarily Disable Account?", MessageBoxButtons.YesNo);

                        if (yesNoDialog == DialogResult.Yes)
                        {
                            if (usr.Enabled == true)
                            {
                                usr.Enabled = false;
                                usr.SetPassword("sdP32*&^kna0^d$");
                                string toDay = DateTime.Today.Date.ToString();
                                usr.Description = "disabled " + toDay.Substring(0, toDay.IndexOf(" ")) + " " + Environment.UserName;
                                usr.Save();
                                MessageBox.Show(usr.DisplayName + "'s account has been disabled");
                            }
                            else
                            {
                                MessageBox.Show(usr.DisplayName + "'s account is already disabled");
                            }
                        }

                        usr.Dispose();
                    }
                    ctx.Dispose();
                }

                catch (Exception unlockException)
                {
                    MessageBox.Show(unlockException.Message);
                }
            }
        }

        public void EnableAccount(string user, string fQDomainName, string ou)
        {
            if (!string.IsNullOrEmpty(user))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName, ou);

                    UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);

                    if (usr != null)
                    {
                        DialogResult yesNoDialog;
                        string enableAccountString = "Are you sure you want to enable " + usr.DisplayName + "'s account?";
                        string userInfoString = "\n\nUSER INFO:\n" + "\nName:\t\t" + usr.DisplayName + "\nTitle:\t\t" + usr.title + "\nDepartment\t" + usr.department + "\nCompany:\t" + usr.company + "\nOffice:\t\t" + usr.office + "\nEmail:\t\t" + usr.EmailAddress + "\nLogin:\t\t" + usr.SamAccountName + "\nDescription:\t" + usr.Description;
                        yesNoDialog = MessageBox.Show(enableAccountString + userInfoString, "Enable Account?", MessageBoxButtons.YesNo);

                        if (yesNoDialog == DialogResult.Yes)
                        {
                            if (usr.Enabled == false)
                            {
                                usr.Enabled = true;
                                //usr.SetPassword("Password1");
                                string toDay = DateTime.Today.Date.ToString();
                                usr.Description = "enabled " + toDay.Substring(0, toDay.IndexOf(" ")) + " " + Environment.UserName;
                                usr.Save();
                                MessageBox.Show(usr.DisplayName + "'s account has been enabled");
                            }
                            else
                            {
                                MessageBox.Show(usr.DisplayName + "'s account is already enabled");
                            }
                        }

                        usr.Dispose();
                    }
                    ctx.Dispose();
                }

                catch (Exception unlockException)
                {
                    MessageBox.Show(unlockException.Message);
                }
            }
        }

        public void AddUserToGroup(string user, string fQDomainName, string ou, string groupName)
        {
            if (!string.IsNullOrEmpty(user))
            {
                try
                {
                    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName))
                    {
                        UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);
                        GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, groupName);
                        group.Members.Add(usr);
                        group.Save();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void RemoveUserFromGroup(string user, string fQDomainName, string ou, string groupName)
        {
            if (!string.IsNullOrEmpty(user))
            {
                try
                {
                    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fQDomainName))
                    {
                        UserPrincipalsEx usr = UserPrincipalsEx.FindByIdentity(ctx, user);
                        GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, groupName);
                        group.Members.Remove(usr);
                        group.Save();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void RemoveUserFromAllGroups(string user, string fQDomainName, string ou)
        {
            if (!string.IsNullOrEmpty(user))
            {
                try
                {
                    List<string> groupList = GetGroups(user, fQDomainName, ou);
                    foreach (object group in groupList)
                    {
                        if (!string.Equals(group.ToString(), "Domain Users"))
                        {
                            RemoveUserFromGroup(user, fQDomainName, ou, group.ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void MoveToDisabledUsersOU(string userDN, string newOU)
        {
            //Move an object from one ou to another
            DirectoryEntry eLocation = new DirectoryEntry("LDAP://" + userDN);
            DirectoryEntry nLocation = new DirectoryEntry("LDAP://" + newOU);
            string newName = eLocation.Name;
            eLocation.MoveTo(nLocation, newName);
            nLocation.Close();
            eLocation.Close();
        }

        public string RandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public void PopulateADLocations(string fQDomainName, string ou)
        {
            foreach (string location in Properties.Settings.Default.ADLocations)
            {
                //populations AD PhysicalDeliveryOfficeName field based on group membership
                RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
                Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
                myRunSpace.Open();
                Pipeline ps = myRunSpace.CreatePipeline();
                Command getADGroupMemberCommand = new Command("Get-ADGroupMember");
                CommandParameter getADGroupMemberArgs = new CommandParameter("Identity", location);
                getADGroupMemberCommand.Parameters.Add(getADGroupMemberArgs);
                ps.Commands.Add(getADGroupMemberCommand);

                Command setADUserCommand = new Command("Set-ADUser");
                CommandParameter setADUserArgs = new CommandParameter("Office", location);
                setADUserCommand.Parameters.Add(setADUserArgs);
                ps.Commands.Add(setADUserCommand);

                // Call the PowerShell.Invoke() method to run the 
                // commands of the pipeline.
                StringBuilder output = new StringBuilder();
                foreach (PSObject result in ps.Invoke())
                {
                    output.AppendLine(result.ToString());


                } // End foreach.
                MessageBox.Show(output.ToString() + location + " complete.");

                myRunSpace.Dispose();
            }


        }

        public void PopulateADTitles(string fQDomainName, string ou)
        {
            foreach (string title in Properties.Settings.Default.ADTitles)
            {
                //populations AD Title field based on group membership
                RunspaceConfiguration rsConfig = RunspaceConfiguration.Create();
                Runspace myRunSpace = RunspaceFactory.CreateRunspace(rsConfig);
                myRunSpace.Open();
                Pipeline ps = myRunSpace.CreatePipeline();
                Command getADGroupMemberCommand = new Command("Get-ADGroupMember");
                CommandParameter getADGroupMemberArgs = new CommandParameter("Identity", title);
                getADGroupMemberCommand.Parameters.Add(getADGroupMemberArgs);
                ps.Commands.Add(getADGroupMemberCommand);

                Command setADUserCommand = new Command("Set-ADUser");
                CommandParameter setADUserArgs = new CommandParameter("Title", title.TrimEnd('s'));
                setADUserCommand.Parameters.Add(setADUserArgs);
                ps.Commands.Add(setADUserCommand);

                // Call the PowerShell.Invoke() method to run the 
                // commands of the pipeline.
                StringBuilder output = new StringBuilder();
                foreach (PSObject result in ps.Invoke())
                {
                    output.AppendLine(result.ToString());


                } // End foreach.
                MessageBox.Show(output.ToString() + title + " complete.");

                myRunSpace.Dispose();
            }
        }



    }
}
