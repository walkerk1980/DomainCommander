using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Threading;
using System.Data.SqlClient;
using System.Management;
using System.Xml;
using System.DirectoryServices;


namespace DomainCommander
{
    public partial class DCMainForm : Form
    {
        //Global variables for Main form
        string pcListPath = Properties.Settings.Default.pcListPath;
        string backslashes = @"\\";
        string fullyQualifiedDomainName = Environment.UserDomainName; // + ".local";
        string organizationalUnit = "DC=" + Environment.UserDomainName + ",DC=" + Properties.Settings.Default.finalDomainComponent; //removed for aka compatibility "OU=" + Properties.Settings.Default.OU + ",
        string cshare = Properties.Settings.Default.cshare;

        //string ProfileNameBoxText

        public DCMainForm()
        {
            InitializeComponent();
        }

        private void ITAppMainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iDSpcNamesDataSet.pcnames' table. You can move, or remove it, as needed.
            this.pcnamesTableAdapter.Fill(this.iDSpcNamesDataSet.pcnames);
            //LoadOptions();
        }

        private void LoadOptions()
        {
            List<string> topLevelList = new List<string>() { ".com", ".net", ".co.uk", ".org", ".int", ".edu", ".gov", ".local" };
            foreach (string finalComponent in topLevelList)
            {
                if (Environment.UserDomainName.Contains(finalComponent))
                {
                    Properties.Settings.Default.finalDomainComponent = "";
                    organizationalUnit = "DC=" + Environment.UserDomainName + ",DC=" + Properties.Settings.Default.finalDomainComponent; //removed for AKA "OU=" + Properties.Settings.Default.OU + ",
                }
            }
            //MessageBox.Show(organizationalUnit);  //uncomment to check resulting Fully Qualified OU
        }

        private void rdefragButton_Click(object sender, EventArgs e)
        {
            DiskTools dt = new DiskTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            dt.DefragTheDisc(pcnameBox.Text, winversion);
        }

        private void ranalyzeButton_Click(object sender, EventArgs e)
        {
            DiskTools dt = new DiskTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            dt.AnalyzeTheDisc(pcnameBox.Text, winversion);
        }

        private void rdeltempButton_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            st.DeleteTempFiles(profileNameBox.Text, pcnameBox.Text, winversion);
        }

        private void trackitButton_Click(object sender, EventArgs e)
        {
            LocalApplications lt = new LocalApplications();
            lt.RunTrackIT();
        }

        private void lmiButton_Click(object sender, EventArgs e)
        {
            LocalApplications lt = new LocalApplications();
            lt.RunLMI();
        }

        private void chkdskButton_Click(object sender, EventArgs e)
        {
            DiskTools dt = new DiskTools();
            dt.CheckTheDisc(pcnameBox.Text);
        }

        private void repairdiskButton_Click(object sender, EventArgs e)
        {
            DiskTools dt = new DiskTools();
            dt.RepairTheDisc(pcnameBox.Text);
        }

        private void homePageLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LocalApplications lt = new LocalApplications();
            lt.intranetSite();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            BrowseThePC();
        }

        private void BrowseThePC()
        {
            DiskTools dt = new DiskTools();
            dt.BrowsePC(pcnameBox.Text);
        }

        private void ostButton_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            if (!String.IsNullOrEmpty(pcnameBox.Text) && !String.IsNullOrEmpty(profileNameBox.Text))
            {
                string pronam = profileNameBox.Text, pcnam = pcnameBox.Text;
                //Thread ostThread = new Thread(() => st.CheckOSTSize(pcnam, pronam, winver));
                //ostThread.Start();
                ListBoxForm.ShowList(st.CheckOSTSize(pcnam, pronam, winversion), "Outlook Files on " + pcnam);
            }

        }

        private void sfcButton_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            st.SytemFileChecker(pcnameBox.Text, winversion);
        }

        private void compmgmtButton_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.ManageThePC(pcnameBox.Text);
        }

        private void openCsvButton_Click(object sender, EventArgs e)
        {
            //UpdatePCNamesList();
            MessageBox.Show("CSV must be in the format of \"username,pcname,\"\nOne user per line");
            UpdatePCNamesDB();
        }

        private void SearchADForUser(string profile, string fqDomainName, string ou)
        {
            if (!string.IsNullOrEmpty(profile))
            {
                try
                {
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fqDomainName, ou);
                    UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, profileNameBox.Text);


                    if (usr != null)
                    {
                        //TO DO
                        //return value
                        //profileNameBox.Text = usr.DisplayName;
                        //MessageBox.Show(usr.DisplayName);
                        usr.Dispose();
                    }
                    ctx.Dispose();
                }
                catch (Exception searchUserException)
                {
                    MessageBox.Show(searchUserException.Message);
                }
            }
        }


        private void pskillButton_Click(object sender, EventArgs e)
        {
            ProcessTools pt = new ProcessTools();
            pt.TaskKill(pcnameBox.Text);
            //ProcessTools.TaskKill(pcnameBox.Text);
        }

        private int CheckWinVersion(string pcname)
        {
            if (!string.IsNullOrEmpty(pcname))
            {
                try
                {
                    if (pcname.Contains(@"\\"))
                    {
                        backslashes = "";
                    }
                    else
                    {
                        backslashes = @"\\";
                    }
                    //perform check to see if pc name belongs to a XP or 7 machine and set box appropriately
                    if (Directory.Exists(backslashes + pcname + Path.DirectorySeparatorChar + cshare + @"\Users"))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (IOException ioe2)
                {
                    MessageBox.Show(ioe2.Message);
                    return 0;
                }
            }
            else
            {
                MessageBox.Show("Enter PC Name");
                return 0;
            }
        }


        private void tasklistButton_Click(object sender, EventArgs e)
        {
            ProcessTools pt = new ProcessTools();
            pt.TaskList(pcnameBox.Text);
            //ProcessTools.TaskList(pcnameBox.Text);
        }



        private void regeditButton_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.RegEdit();
        }

        private void pcNameBox_EnterKeyPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(pcnameBox.Text))
                {
                    DiskTools dt = new DiskTools();
                    dt.BrowsePC(pcnameBox.Text);
                }
                //Browse Remote PC if computer name is entered and then user hits return key.
            }
        }


        private void profileNameBox_EnterKeyPressed(object sender, System.Windows.Forms.KeyPressEventArgs f)
        {
            if (f.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(pcnameBox.Text) && !string.IsNullOrEmpty(profileNameBox.Text))
                {
                    DiskTools dt = new DiskTools();
                    dt.browseProfile(pcnameBox.Text, profileNameBox.Text);
                }
                //Browse Remote PC in user's profile directory if computer name is entered and then user hits return key.
            }
        }

        private void pcNameList_Click(object sender, EventArgs e)
        {
            //AddToPCNameList();
            AddToPCNameDB(profileNameBox.Text, pcnameBox.Text);
        }

        private void getPCNameButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(profileNameBox.Text))
            {
                //SearchADForUser(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit);
                pcnameBox.Text = GetPCNameFromDB(profileNameBox.Text, pcnameBox.Text);
                //GetPCNameFromList();
                //Thread winversionThread = new Thread(() => CheckWinVersion(pcnameBox.Text));
                //winversionThread.Start();
                CheckWinVersion(pcnameBox.Text);
            }
        }

        private string GetPCNameFromDB(string profile, string pcname)
        {
            if (!string.IsNullOrEmpty(profile))
            {
                try
                {
                    pcname = pcnamesTableAdapter.pcNameQuery(profile).ToString();
                    return pcname;
                }
                catch (Exception pcNameQueryException)
                {
                    MessageBox.Show("Computer name for " + profile + " not known.\n\n" + pcNameQueryException.Message);
                    return pcname;
                }
            }
            return pcname;
        }

        private string GetPCNameFromList(string profile, string listPath, string pcname)
        {
            if (!string.IsNullOrEmpty(profile))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(listPath + profile + ".txt"))
                    {
                        pcname = reader.ReadLine();
                        reader.Close();
                        return pcname;
                    }
                }
                catch (IOException ioe2)
                {
                    MessageBox.Show(ioe2.Message);
                    return pcname;
                }
            }
            else
            {
                return pcname;
            }
        }

        private void UpdatePCNamesDB()
        {
            /*Takes PC names and profile names from comma delimited text file (csv)
            * in the format exported by managing qls-dc for example and exporting
            * shared folder sessions by clicking export list and choosing .csv not .txt
            * saves data to IDSpcNamesDataSet
            * csv file must have username before first comma deliminator and pcname between first and second
            * anything after second comma is ignored.
            */
            string inputFilename;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((inputFilename = openFileDialog1.FileName) != null)
                    {
                        using (StreamReader reader = new StreamReader(inputFilename))
                        {
                            if (!reader.EndOfStream)
                            {
                                int i = 0;
                                List<String> pcNameLines = new List<String>();
                                string line;
                                while (!reader.EndOfStream)
                                {
                                    line = reader.ReadLine();
                                    if (!line.Contains("192.168") && !line.Contains("mh-ts") && !line.Contains("vm-ts") && !line.Contains("mail") && !line.Contains("qcmc-ts") && !line.Contains("qe-ts") && !line.Contains("mh-ts".ToUpper()) && !line.Contains("vm-ts".ToUpper()) && !line.Contains("mail".ToUpper()) && !line.Contains("qcmc-ts".ToUpper()) && !line.Contains("qe-ts".ToUpper()) && !line.Contains("qls-ts") && !line.Contains("qls-ts".ToUpper()) && !line.Contains("actimate"))
                                    {
                                        pcNameLines.Add(line);
                                    }
                                    i++;
                                }
                                foreach (string s in pcNameLines)
                                {
                                    string proName = s.Substring(0, s.IndexOf(","));
                                    string pcsub = s.Substring(s.IndexOf(",") + 1);
                                    string pc = pcsub.Substring(0, pcsub.IndexOf(","));
                                    if (pc.Contains("domain.local"))
                                    {
                                        pc = pc.Substring(0, pc.IndexOf("."));
                                    }
                                    if (pcnamesTableAdapter.UsernameExistsQuery(proName).Equals(1))
                                    {
                                        pcnamesTableAdapter.UpdateUsernameQuery(pc, proName);
                                    }
                                    else
                                    {
                                        pcnamesTableAdapter.Insert(proName, pc);
                                    }
                                }
                            }

                            reader.Close();
                            reader.Dispose();
                        }

                    }

                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    openFileDialog1.Dispose();
                }
            }
        }

        private void uDriveButton_Click(object sender, EventArgs e)
        {
            DiskTools dt = new DiskTools();
            dt.BrowseUDrive(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit);
        }

        private void openCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CSV must be in the format of \"username,pcname,\"\nOne user per line");
            PCNameTools pt = new PCNameTools();
            pt.UpdatePCNamesList(pcListPath);
        }

        private void cycleSpoolerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterTools prt = new PrinterTools();
            prt.RestartTheSpooler(pcnameBox.Text);
        }

        private void browsePCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowseThePC();
        }

        private void registryEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.RegEdit();
        }

        private void managePCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.ManageThePC(pcnameBox.Text);
        }

        private void systemFileCheckerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            st.SytemFileChecker(pcnameBox.Text, winversion);
        }

        private void deleteTempFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            st.DeleteTempFiles(profileNameBox.Text, pcnameBox.Text, winversion);
        }

        private void stopSpoolerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterTools prt = new PrinterTools();
            prt.StopTheSpooler(pcnameBox.Text);
        }

        private void deletePrintJobsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterTools prt = new PrinterTools();
            prt.DeletePrintJobs(pcnameBox.Text);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterTools prt = new PrinterTools();
            prt.StartTheSpooler(pcnameBox.Text);
        }

        private void installedHotfixesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PsInfo("-h", pcnameBox.Text);
            WmiTools wt = new WmiTools();
            ListBoxForm.ShowList(wt.WMIGetHotfixes(pcnameBox.Text), "Hotfixes installed on " + pcnameBox.Text);
        }

        private void installedSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pcname = pcnameBox.Text;
            //PsInfo("-s", pcnameBox.Text);
            WmiTools wt = new WmiTools();
            //Thread softThread = new Thread(() => ListBoxForm.ShowList(wt.WMISoftwareQuery(pcname), "Software installed on " + pcname));
            //softThread.Start();
            ListBoxForm.ShowList(wt.WMIGetInstalledSoftware(pcname), "Software installed on " + pcname);
        }

        private void volumeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.PsInfo("-d", pcnameBox.Text);
        }

        private void volumeInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            Thread volThread = new Thread(() => st.PsInfo("-d", pcnameBox.Text));
            volThread.Start();
        }

        private void showLoggedOnUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WmiTools wt = new WmiTools();
            ListBoxForm.ShowList(wt.WMIGetLoggedOnUser(pcnameBox.Text), "Users logged on to " + pcnameBox.Text);
            UserTools ut = new UserTools();
            Thread psLogThread = new Thread(() => ut.PsLoggedOn("-l", pcnameBox.Text));
            psLogThread.Start();
        }

        private void remoteControlPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.RemoteControlThePC(pcnameBox.Text);
        }

        private void rdpSpannedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //osversion 5 = xp 7 = 7
            if (Environment.OSVersion.Version.Major == 5)
            {
                SystemTools st = new SystemTools();
                st.RemoteControlThePC(pcnameBox.Text, @"/span");
            }
            else
            {
                SystemTools st = new SystemTools();
                st.RemoteControlThePC(pcnameBox.Text, @"/span /multimon");
            }
        }

        private void mapDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiskTools dt = new DiskTools();
            dt.MapTheDrive(pcnameBox.Text, profileNameBox.Text);
        }

        public void showEditPCNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ITAppPCNamesForm pcNamesForm = new ITAppPCNamesForm();
            pcNamesForm.pcnamesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pcNamesForm_pcnamesDataGridView_CellDoubleClick);
            pcNamesForm.Show();
        }

        private void pcNamesForm_pcnamesDataGridView_CellDoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.RunGpInventory();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void groupPolicyEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.GroupPolicyEditor(pcnameBox.Text);
        }

        private void AddToPCNameDB(string profile, string pcname)
        {
            if (!string.IsNullOrEmpty(pcname) && !string.IsNullOrEmpty(profile) && pcname.Length > 0 && profile.Length > 0)
            {
                try
                {
                    if (pcnamesTableAdapter.UsernameExistsQuery(profile).Equals(1))
                    {
                        pcnamesTableAdapter.UpdateUsernameQuery(pcname, profile);
                        MessageBox.Show("Updated " + profile + " PC Name in PC Name DB.");
                    }
                    else
                    {
                        pcnamesTableAdapter.Insert(profile, pcname);
                        MessageBox.Show("Added " + profile + " to PC Name DB.");
                    }
                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.Message);
                }
            }
        }

        private void profileNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            profileNameBox.Text = profileNameComboBox.Text;
            pcnameBox.Text = GetPCNameFromDB(profileNameBox.Text, pcnameBox.Text);
            CheckWinVersion(pcnameBox.Text);
        }

        private void getNameFromDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcnameBox.Text = GetPCNameFromDB(profileNameBox.Text, pcnameBox.Text);
        }

        private void getNameFromListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pcnameBox.Text = GetPCNameFromList(profileNameBox.Text, pcListPath, pcnameBox.Text);
        }

        private void addToPCNameListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PCNameTools pt = new PCNameTools();
            pt.AddToPCNameList(profileNameBox.Text, pcnameBox.Text, pcListPath);
        }

        private void addToPCNameDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToPCNameDB(profileNameBox.Text, pcnameBox.Text);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm1 = new OptionsForm();
            optionsForm1.ShowDialog();
        }

        private void mapRBJDrivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiskTools dt = new DiskTools();
            dt.MapPY48Drive(pcnameBox.Text, profileNameBox.Text);
        }

        private void disableJavaUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationTools at = new ApplicationTools();
            at.DisableJavaUpdate(pcnameBox.Text);
        }

        private void inventoryQueryPCsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.RunGpInventory();
        }

        private void getServiceTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WmiTools wt = new WmiTools();
            ListBoxForm.ShowList(wt.WMIGetServiceTag(pcnameBox.Text), "Service Tag for system " + pcnameBox.Text + ": ");
        }

        private List<string> DisplayXMLContents(string filename)
        {
            XmlTextReader wmiQueriesXML = new XmlTextReader(filename);
            wmiQueriesXML.Read();
            //if the node has a value
            List<string> resultList = new List<string>();
            while (wmiQueriesXML.Read())
            {
                //move to first/next element
                wmiQueriesXML.MoveToElement();
                resultList.Add("Name: " + wmiQueriesXML.Name.ToString());
                resultList.Add("Value: " + wmiQueriesXML.Value.ToString());
                resultList.Add("");
            }
            wmiQueriesXML.Close();
            return resultList;
        }

        private void readXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            string inputFilename = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((inputFilename = openFileDialog1.FileName) != null)
                    {
                        inputFilename = openFileDialog1.FileName;
                        ListBoxForm.ShowList(DisplayXMLContents(inputFilename), "Contents of " + Path.GetFileName(inputFilename));
                    }
                }
                catch (Exception InputEx)
                {
                    MessageBox.Show(InputEx.Message);
                }
            }
        }

        private void clearClipboardShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.ClearClipboard(pcnameBox.Text, profileNameBox.Text);
        }

        private void listMappedPrintersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterTools prt = new PrinterTools();
            prt.ListPrinters(pcnameBox.Text);
        }

        private void deletePrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterTools prt = new PrinterTools();
            prt.DeletePrinter(pcnameBox.Text);
        }

        private void emptyRecyclersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            st.EmptyRecycler(pcnameBox.Text, winversion);
        }

        private void deleteTempFilesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            st.DeleteTempFiles(profileNameBox.Text, pcnameBox.Text, winversion);
        }

        private void rebootMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.RebootTheMachine(pcnameBox.Text);
        }

        private void abortShutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.RebootTheMachine(pcnameBox.Text, true);
        }

        private void pingMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkTools nt = new NetworkTools();
            nt.PingTheMachine(pcnameBox.Text);
        }

        private void networkInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkTools nt = new NetworkTools();
            nt.NetworkInfo(pcnameBox.Text);
        }

        private void flushDNSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkTools nt = new NetworkTools();
            nt.FlushDNS(pcnameBox.Text);
        }

        private void disablePopupBlockerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationTools at = new ApplicationTools();
            at.DisablePopupBlocker(pcnameBox.Text, profileNameBox.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qCMCFileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiskTools dt = new DiskTools();
            if (!string.IsNullOrEmpty(pcnameBox.Text))
            {
                dt.QCMCFileList(pcnameBox.Text);
            }
            else
            {
                dt.QCMCFileList();
            }
        }

        private void checkOSTPSTSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            int winversion = CheckWinVersion(pcnameBox.Text);
            string pronam = profileNameBox.Text, pcnam = pcnameBox.Text;
            Thread ostThread = new Thread(() => st.CheckOSTSize(pcnam, pronam, winversion));
            ostThread.Start();
        }


        private void msInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.RunMsInfo32(pcnameBox.Text);
        }

        private void pSSystemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            Thread psinfoThread = new Thread(() => st.PsInfo("", pcnameBox.Text));
            psinfoThread.Start();
        }

        private void showGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            //Thread showGroupsThread = new Thread(() => ut.GetGroups(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));
            //showGroupsThread.Start();
            ListBoxForm.ShowList(ut.GetGroups(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit), ut.GetFullName(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit) + "'s AD Groups");
        }

        private void disableAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            Thread disableAccountThread = new Thread(() => ut.DisableAccount(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));
            disableAccountThread.Start();
        }

        private void unlockButton_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            Thread unlockUserThread = new Thread(() => ut.UnlockUser(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));
            unlockUserThread.Start();
        }

        private void passResetButton_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            Thread resetPassThread = new Thread(() => ut.ResetUsersPassword(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));
            resetPassThread.Start();
        }

        private void enableAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            Thread enableAccountThread = new Thread(() => ut.EnableAccount(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));
            enableAccountThread.Start();
        }

        private void removeUserFromGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            List<string> currentGroups = ut.GetGroups(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit);
            ListBoxForm.ShowList(currentGroups, profileNameBox.Text + "'s current groups");
            string groupName = Prompt.ShowDialog("Enter name of group to remove user from", "Remove user from group.");
            Thread resetPassThread = new Thread(() => ut.RemoveUserFromGroup(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit, groupName));
            resetPassThread.Start();
        }

        private void tempAccountDisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            Thread disableAccountThread = new Thread(() => ut.DisableAccountTemp(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));
            disableAccountThread.Start();
        }

        private void addUserToGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            List<string> currentGroups = ut.GetGroups(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit);
            ListBoxForm.ShowList(currentGroups, profileNameBox.Text + "'s current groups");
            string groupName = Prompt.ShowDialog("Enter name of group to add user to", "Add user to group.");
            Thread resetPassThread = new Thread(() => ut.AddUserToGroup(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit, groupName));
            resetPassThread.Start();
        }

        private void skypeAccountHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkypeForm skypeForm = new SkypeForm();
            skypeForm.Show();
        }

        private void openChatWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChatForm chatForm = new ChatForm();
            chatForm.Show();
        }

        private void unmapDriveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiskTools dt = new DiskTools();
            dt.UnmapTheDrive(pcnameBox.Text, profileNameBox.Text);
        }

        private void listMappedDrivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pcname = pcnameBox.Text;
            if (!String.IsNullOrEmpty(pcname))
            {
                WmiTools wt = new WmiTools();
                //Thread softThread = new Thread(() => ListBoxForm.ShowList(wt.WMISoftwareQuery(pcname), "Software installed on " + pcname));
                //softThread.Start();
                ListBoxForm.ShowList(wt.GetMappedDrives(pcname), "Mapped Drives on " + pcname);
            }
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpTools ht = new HelpTools();
            ListBoxForm.ShowList(ht.ShowChangelog(), "Changelog");
        }

        private void scanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(new NotImplementedException().Message.ToString());
        }

        private void getSamAccountNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            Thread softThread = new Thread(() => MessageBox.Show(ut.GetSamAccountName(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit)));
            softThread.Start();
        }

        private void getFullNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            Thread softThread = new Thread(() => MessageBox.Show(ut.GetFullName(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit)));
            softThread.Start();
        }

        private void subnetDvmUpdaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string subnetPromptText = "Enter the subnet, (0-255) number only,\nthat you would like to update PCM DVM IPs on:";
            string dvmIpPromptText = "Please enter ip address you would like DVMs to be set to in subnet\nExample 192.168.97.10:";
            TelephonyTools tt = new TelephonyTools();
            Thread softThread = new Thread(() => tt.UpdateDvmIPs(Prompt.ShowDialog(subnetPromptText, "Enter Subnet to Update"), Prompt.ShowDialog(dvmIpPromptText,"Enter DVM IP")));
            softThread.Start();
        }

        private void getUsersADInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            var combinedList = new List<string>();
            combinedList.AddRange(ut.GetADUserInfo(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));
            combinedList.Add("");
            combinedList.Add("GROUP MEMBERSHIPS: ");
            combinedList.AddRange(ut.GetGroups(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));
            //ListBoxForm.ShowList(combinedList, "AD Info for " + ut.GetFullName(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));
            TextBoxForm.ShowText(string.Join<string>(Environment.NewLine, combinedList), "AD Info for " + ut.GetFullName(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit));

        }

        private void exchangeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            var list = et.getBlockedSenders();
            ListBoxForm.ShowList(list, "Exchange Test");

        }

        private void updateGroupPolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            st.RunGPUpdateForce(pcnameBox.Text);
        }

        private void getBrowserVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationTools at = new ApplicationTools();
            at.GetBrowserVersion(pcnameBox.Text);
        }

        private void disableFirewallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkTools nt = new NetworkTools();
            nt.DisableFirewall(pcnameBox.Text);
        }

        private void enableRemoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkTools nt = new NetworkTools();
            nt.EnableRemoteDesktop(pcnameBox.Text);
        }

        private void netstatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkTools nt = new NetworkTools();
            nt.Netstat(pcnameBox.Text);
        }

        private void sendTerminationEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            et.SendTerminationEmail(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit);
        }

        private void renewDHCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NetworkTools nt = new NetworkTools();
            nt.RenewDHCPLease(pcnameBox.Text);
        }

        private void sendTestEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            et.SendTestTerminationEmail(profileNameBox.Text, fullyQualifiedDomainName, organizationalUnit);
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toDay = DateTime.Today.Date.ToString();
            MessageBox.Show(toDay.Substring(0, toDay.IndexOf(" ")));
        }

        private void websiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LocalApplications lt = new LocalApplications();
            lt.webSite();
        }

        private void populateADLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            ut.PopulateADLocations(fullyQualifiedDomainName, organizationalUnit);
        }

        private void testPowerShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            et.testPowerShell();
        }

        private void populateADTitlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserTools ut = new UserTools();
            ut.PopulateADTitles(fullyQualifiedDomainName, organizationalUnit);
        }

        private void getMailboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            var list = et.getMailbox(profileNameBox.Text);
            ListBoxForm.ShowList(list, "Get-Mailbox " + profileNameBox.Text);
            //Thread getMailboxThread = new Thread(() => ListBoxForm.ShowList(list, "Get-Mailbox"));
            //getMailboxThread.Start();
        }

        private void BlockedSendersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            var list = et.getBlockedSenders();
            ListBoxForm.ShowList(list, "Blocked Senders");
        }

        private void whitelistedSendersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            var list = et.getWhitelistedSenders();
            ListBoxForm.ShowList(list, "Whitelisted Senders");
        }

        private void blacklistedDomainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            var list = et.getBlacklistedDomains();
            ListBoxForm.ShowList(list, "Blacklisted Domains");
        }

        private void whitelistedDomainsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            var list = et.getWhitelistedDomains();
            ListBoxForm.ShowList(list, "Whitelisted Domains");
        }

        private void getJunkEmailConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailTools et = new EmailTools();
            var list = et.getJunkEmailConfig(profileNameBox.Text);
            ListBoxForm.ShowList(list, "Mailbox Junk Email Configuration " + profileNameBox.Text);
        }

        private void remoteCommandLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemTools st = new SystemTools();
            Thread cmdThread = new Thread(() => st.RemoteCMDLine(pcnameBox.Text));
            cmdThread.Start();
        }


    }
}
