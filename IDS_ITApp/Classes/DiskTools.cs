using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Threading;

namespace DomainCommander
{
    public class DiskTools : CommonTools
    {
        string browsePCName = null;

        public void CheckTheDisc(string pcname)
        {
            try
            {
                pcname = CleanPCName(pcname);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = @"psexec";
                if (PcNameIsNotNullOrVoid(pcname))
                {
                    proc.StartInfo.Arguments = backslashes + pcname + " cmd /c \"chkdsk & pause\"";
                    proc.Start();
                }
                //proc.WaitForExit();
            }
            catch (Exception chkdskException)
            {
                MessageBox.Show(chkdskException.Message);
            }
        }

        public void DefragTheDisc(string pcname, int winversion)
        {
            try
            {
                pcname = CleanPCName(pcname);
                if (winversion == 0)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = @"psexec";
                    if (PcNameIsNotNullOrVoid(pcname))
                    {
                        proc.StartInfo.Arguments = backslashes + pcname + " cmd /c \"defrag c: -v -f & pause\"";
                        proc.Start();
                    }
                    //proc.WaitForExit();
                    //MessageBox.Show("Remote PC has been defragmented.");  
                }
                else
                {
                    MessageBox.Show("Cannot remote defrag Windows 7 machines.");
                }

            }
            catch (Exception defragException)
            {
                MessageBox.Show(defragException.Message);
            }
        }

        public void AnalyzeTheDisc(string pcname, int winversion)
        {
            try
            {
                pcname = CleanPCName(pcname);
                if (winversion == 0)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = @"psexec";
                    if (PcNameIsNotNullOrVoid(pcname))
                    {
                        proc.StartInfo.Arguments = backslashes + pcname + " cmd /c \"defrag c: -v & pause\"";
                        proc.Start();
                    }
                    //proc.WaitForExit();
                    //MessageBox.Show("");
                }
                else
                {
                    MessageBox.Show("Cannot remote defrag Windows 7 machines.");
                }
            }
            catch (Exception analyzeException)
            {
                MessageBox.Show(analyzeException.Message);
            }
        }

        public void RepairTheDisc(string pcname)
        {
            try
            {
                pcname = CleanPCName(pcname);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = @"psexec";
                if (PcNameIsNotNullOrVoid(pcname))
                {
                    proc.StartInfo.Arguments = backslashes + pcname + " cmd /c \"chkdsk /f & pause\"";
                    proc.Start();
                }
                //proc.WaitForExit();
            }
            catch (Exception repairdiskException)
            {
                MessageBox.Show(repairdiskException.Message);
            }
        }

        public void BrowseUDrive(string user, string fqDomainName, string ou)
        {
            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, fqDomainName, ou);

                UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, user);

                if (usr != null)
                {
                    //MessageBox.Show(usr.HomeDirectory.ToString());
                    DiskTools dt = new DiskTools();
                    dt.BrowsePC(usr.HomeDirectory.ToString().Substring(2));
                    usr.Dispose();
                }
                ctx.Dispose();

            }

            catch (Exception searchUserException)
            {
                MessageBox.Show(searchUserException.Message);
            }
        }

        public void BrowsePC(string pcname)
        {
            browsePCName = pcname;
            Thread oBrowsePCThread = new Thread(new ThreadStart(BrowsePCThread));
            oBrowsePCThread.Start();
        }

        public void BrowsePCThread()
        {
            string pcname = browsePCName;
            browsePCName = null;
            if (PcNameIsNotNullOrVoid(pcname))
            {
                try
                {
                    string browsePath = @"\" + cshare + @"";
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "explorer";
                    pcname = CleanPCName(pcname);
                    if (pcname.Contains("$"))
                    {
                        browsePath = "";
                    }
                    proc.StartInfo.Arguments = backslashes + pcname + browsePath;
                    proc.Start();
                    //proc.WaitForExit();
                }
                catch (Exception browseException)
                {
                    MessageBox.Show(browseException.Message);
                }
            }
        }

        public void browseProfile(string pcname, string profile)
        {
            try
            {
                pcname = CleanPCName(pcname);
                //profile = CheckForProfileDotDomain(pcname, profile);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "explorer";
                proc.StartInfo.Arguments = GetDesktopLocation(profile) + profile;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception browseException)
            {
                MessageBox.Show(browseException.Message);
            }
        }

        public void MapTheDrive(string pcname, string profile)
        {
            try
            {
                if (PcNameIsNotNullOrVoid(pcname) && !string.IsNullOrEmpty(profile))
                {
                    pcname = CleanPCName(pcname);
                    profile = CheckForProfileDotDomain(pcname, profile);
                    string driveLetter = Prompt.ShowDialog("Enter drive letter to map.", "Drive Letter");
                    driveLetter = driveLetter.Substring(0, 1);
                    string pathToMap = Prompt.ShowDialog("Enter path to map to.", "Path");
                    if (!string.IsNullOrEmpty(driveLetter) && !string.IsNullOrEmpty(pathToMap))
                    {
                        string mapCommand = "net use " + driveLetter + ": " + "\"" + pathToMap + "\"" + @" /persistent:yes";
                        string filename = GetDesktopLocation(profile) + profile + @"\Desktop\Map" + driveLetter.ToUpper() + "Drive.bat";
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(filename))
                            {
                                writer.WriteLine(@"@echo off");
                                writer.WriteLine(mapCommand);
                                writer.WriteLine(@"set /P USERNAME=Press Enter to continue... %=%");
                                //writer.WriteLine(@"del %0");
                                writer.Flush();
                                writer.Close();
                                MessageBox.Show("Created Map" + driveLetter.ToUpper() + "Drive.bat on " + profile + "'s Desktop.");
                                writer.Dispose();
                            }
                        }
                        catch (IOException ioe)
                        {
                            MessageBox.Show(ioe.Message);
                        }
                    }

                }
            }
            catch (Exception mapdriveException)
            {
                MessageBox.Show(mapdriveException.Message);
            }
        }

        public void UnmapTheDrive(string pcname, string profile)
        {
            try
            {
                pcname = CleanPCName(pcname);
                profile = CheckForProfileDotDomain(pcname, profile);
                if (PcNameIsNotNullOrVoid(pcname) && !string.IsNullOrEmpty(profile))
                {
                    string driveLetter = Prompt.ShowDialog("Enter drive letter to unmap.", "Drive Letter");
                    driveLetter = driveLetter.Substring(0, 1); //strip off all but first character of input
                    if (!string.IsNullOrEmpty(driveLetter))
                    {
                        string mapCommand = "net use " + driveLetter + ": " + @"/DELETE";
                        string filename = GetDesktopLocation(profile) + profile + @"\Desktop\Unmap" + driveLetter.ToUpper() + "Drive.bat";
                        try
                        {
                            using (StreamWriter writer = new StreamWriter(filename))
                            {
                                writer.WriteLine(@"@echo off");
                                writer.WriteLine(mapCommand);
                                writer.WriteLine(@"set /P USERNAME=Press Enter to continue... %=%");
                                //writer.WriteLine(@"del %0");
                                writer.Flush();
                                writer.Close();
                                MessageBox.Show("Created Unmap" + driveLetter.ToUpper() + "Drive.bat on " + profile + "'s Desktop.");
                                writer.Dispose();
                            }
                        }
                        catch (IOException ioe)
                        {
                            MessageBox.Show(ioe.Message);
                        }
                    }

                }
            }
            catch (Exception mapdriveException)
            {
                MessageBox.Show(mapdriveException.Message);
            }
        }

        public void MapPY48Drive(string pcname, string profile)
        {
            try
            {
                if (PcNameIsNotNullOrVoid(pcname) && !string.IsNullOrEmpty(profile))
                {
                    pcname = CleanPCName(pcname);
                    //profile = CheckForProfileDotDomain(pcname, profile);
                    string filename = GetDesktopLocation(profile) + profile + @"\Desktop\MapPY48Drive.bat";
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filename))
                        {
                            writer.WriteLine(@"@echo off");
                            writer.WriteLine("echo _________________________________________");
                            writer.WriteLine("echo mapping py48forms");
                            writer.WriteLine(@"net use r: \\adm-dc\py48forms /PERSISTENT:YES");
                            writer.WriteLine("echo _________________________________________");
                            writer.WriteLine(@"set /P CONT=Press Enter to continue... %=%");
                            writer.WriteLine(@"del %0");
                            writer.Flush();
                            writer.Close();
                            MessageBox.Show("Created MapPY48Drive.bat on " + profile + "'s Desktop.");
                            writer.Dispose();
                        }
                    }
                    catch (IOException ioe)
                    {
                        MessageBox.Show(ioe.Message);
                    }

                }
            }
            catch (Exception mapdriveException)
            {
                MessageBox.Show(mapdriveException.Message);
            }
        }

        public void QCMCFileList()
        {
            string inputFilename;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<String> pcNameLines = new List<String>();
                try
                {
                    if ((inputFilename = openFileDialog1.FileName) != null)
                    {
                        using (StreamReader reader = new StreamReader(inputFilename))
                        {
                            if (!reader.EndOfStream)
                            {
                                int i = 0;
                                string line;
                                while (!reader.EndOfStream)
                                {
                                    line = reader.ReadLine();
                                    pcNameLines.Add(reader.ReadLine());
                                    i++;
                                }
                                reader.Close();
                                reader.Dispose();
                            }
                        }
                        string fileName = null;
                        foreach (string pcName in pcNameLines)
                        {
                            try
                            {
                                if (Directory.Exists(backslashes + pcName + @"\c$\Documents and Settings"))
                                {
                                    fileName = backslashes + pcName + @"\c$\Documents and Settings\All Users\Start Menu\Programs\Startup\listfiles.vbs";
                                }
                                if (Directory.Exists(backslashes + pcName + @"\c$\Users"))
                                {
                                    fileName = backslashes + pcName + @"\c$\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup\listfiles.vbs";
                                }
                                //MessageBox.Show(fileName);
                                if (!string.IsNullOrEmpty(fileName))
                                {
                                    using (StreamWriter writer = new StreamWriter(fileName))
                                    {
                                        writer.WriteLine("Set WshShell = WScript.CreateObject(\"WScript.Shell\")");
                                        writer.WriteLine("WshShell.Run \"\\\\qcmc-fileserver\\audit$\\qcmcfilelist.exe\"");
                                        writer.Flush();
                                        writer.Close();
                                        writer.Dispose();
                                    }
                                }
                            }
                            catch
                            {
                                fileName = null;
                            }
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

        public void QCMCFileList(string pcname)
        {
            string fileName = null;
            try
            {
                pcname = CleanPCName(pcname);
                if (Directory.Exists(backslashes + pcname + @"\c$"))
                {
                    if (Directory.Exists(backslashes + pcname + @"\c$\Documents and Settings"))
                    {
                        fileName = backslashes + pcname + @"\c$\Documents and Settings\All Users\Start Menu\Programs\Startup\listfiles.vbs";
                    }
                    if (Directory.Exists(backslashes + pcname + @"\c$\Users"))
                    {
                        fileName = backslashes + pcname + @"\c$\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup\listfiles.vbs";
                    }
                }

                //MessageBox.Show(fileName);
                if (!string.IsNullOrEmpty(fileName))
                {
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine("Set WshShell = WScript.CreateObject(\"WScript.Shell\")");
                        writer.WriteLine("WshShell.Run \"\\\\qcmc-fileserver\\audit$\\qcmcfilelist.exe\"");
                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Could not find PC");
            }
        }

        public void DeleteTSProfiles(string profileToDelete)
        {
            try
            {
                if (!string.IsNullOrEmpty(profileToDelete))
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "deletetsprofiles.bat";
                    proc.StartInfo.Arguments = profileToDelete;
                    proc.Start();
                    //proc.WaitForExit();
                }
                else
                {

                }

            }
            catch (Exception deleteTSProfileException)
            {
                MessageBox.Show(deleteTSProfileException.Message);
            }
        }

    }
}
