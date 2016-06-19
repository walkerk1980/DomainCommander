using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DomainCommander
{
    public class SystemTools : CommonTools
    {

        public void DeleteTempFiles(string profile, string pcname, int winversion)
        {
            pcname = CleanPCName(pcname);
            profile = CheckForProfileDotDomain(pcname, profile);
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                //run batch files based on OS selection
                if (winversion == 0)
                {
                    proc.StartInfo.FileName = "rdeltemp";
                }
                else
                {
                    proc.StartInfo.FileName = "rdeltemp7";
                }
                if (PcNameIsNotNullOrVoid(pcname))
                {
                    proc.StartInfo.Arguments = pcname + " " + profile;
                    proc.Start();
                }
                //proc.WaitForExit();
                //MessageBox.Show("All Temp files on remote PC have been deleted.");
            }
            catch (Exception deltempException)
            {
                MessageBox.Show(deltempException.Message);
            }
        }

        public void RecycleThread(string pcname, int winversion)
        {
            pcname = CleanPCName(pcname);
            try
            {
                if (winversion == 0)  // XP
                {
                    if (Directory.Exists(backslashes + pcname + @"\" + cshare + @"\RECYCLER"))
                    {
                        Directory.Delete(backslashes + pcname + @"\" + cshare + @"\RECYCLER", true);
                    }
                }
                else // WIN7
                {
                    if (Directory.Exists(backslashes + pcname + @"\" + cshare + @"\$Recycle.Bin"))
                    {
                        Directory.Delete(backslashes + pcname + @"\" + cshare + @"\$Recycle.Bin", true);
                    }
                }
                MessageBox.Show("Recycle Bin emptied.");

            }
            catch (Exception deltempException)
            {
                MessageBox.Show(deltempException.Message);
            }
            finally
            {

            }
        }

        public void EmptyRecycler(string pcname, int winversion)
        {
            pcname = CleanPCName(pcname);
            if (PcNameIsNotNullOrVoid(pcname))
            {
                Thread recycleThread = new Thread(() => RecycleThread(pcname, winversion));
                recycleThread.Start();
            }
        }

        public void RegEdit()
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "regedit";
                //proc.StartInfo.Arguments = "/Computer=" + pcname;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception regeditException)
            {
                MessageBox.Show(regeditException.Message);
            }
        }

        public void ManageThePC(string pcname)
        {
            pcname = CleanPCName(pcname);
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "compmgmt.msc";
                proc.StartInfo.Arguments = "/Computer=" + pcname;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception manageException)
            {
                MessageBox.Show(manageException.Message);
            }
        }

        public void RemoteControlThePC(string pcname)
        {
            pcname = CleanPCName(pcname);
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "mstsc";
                proc.StartInfo.Arguments = "/v:" + pcname;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception manageException)
            {
                MessageBox.Show(manageException.Message);
            }
        }

        public void RemoteControlThePC(string pcname, string spanned)
        {
            pcname = CleanPCName(pcname);
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "mstsc";
                proc.StartInfo.Arguments = "/v:" + pcname + " " + spanned;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception manageException)
            {
                MessageBox.Show(manageException.Message);
            }
        }

        public void GroupPolicyEditor(string pcname)
        {
            pcname = CleanPCName(pcname);
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "gpedit.msc";
                if (PcNameIsNotNullOrVoid(pcname))
                {
                    proc.StartInfo.Arguments = @"/gpcomputer: " + pcname;
                }
                proc.Start();
                //proc.WaitForExit();
                //MessageBox.Show("");
            }
            catch (Exception analyzeException)
            {
                MessageBox.Show(analyzeException.Message);
            }
        }

        public void RunMsInfo32(string pcname)
        {
            pcname = CleanPCName(pcname);
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "msinfo32.exe";
                if (PcNameIsNotNullOrVoid(pcname))
                {
                    proc.StartInfo.Arguments = @"/computer " + pcname;
                }
                proc.Start();
                //proc.WaitForExit();
                //MessageBox.Show("");
            }
            catch (Exception msinfo32Exception)
            {
                MessageBox.Show(msinfo32Exception.Message);
            }
        }

        public void SytemFileChecker(string pcname, int winversion)
        {
            if (winversion == 0)
            {
                MessageBox.Show("Can only be performed remotely on Windows 7 machines.");
            }
            else
            {
                try
                {
                    pcname = CleanPCName(pcname);
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = @"psexec";
                    if (PcNameIsNotNullOrVoid(pcname))
                    {
                        proc.StartInfo.Arguments = backslashes + pcname + " " + "sfc /scannow";
                    }
                    proc.Start();
                    //proc.WaitForExit();
                }
                catch (Exception sfcException)
                {
                    MessageBox.Show(sfcException.Message);
                }
            }
        }

        public void PsInfo(string psInfoArgs, string pcname)
        {
            try
            {
                pcname = CleanPCName(pcname);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "psinfo";
                proc.StartInfo.UseShellExecute = false;
                if (PcNameIsNotNullOrVoid(pcname))
                {
                    proc.StartInfo.Arguments = " " + backslashes + pcname + " " + psInfoArgs;
                }
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                MessageBox.Show(proc.StandardOutput.ReadToEnd());
                //proc.WaitForExit();
            }
            catch (Exception psInfoException)
            {
                MessageBox.Show(psInfoException.Message);
            }
        }

        public void RunGpInventory()
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "gpinventory.exe";
                //proc.StartInfo.Arguments=;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception inventoryException)
            {
                MessageBox.Show(inventoryException.Message);
            }
        }

        public List<string> CheckOSTSize(string pcname, string profile, int winversion)
        {
            string ostpath, ostpathMyDocs;
            List<string> resultList = new List<string>();

            pcname = CleanPCName(pcname);
            profile = CheckForProfileDotDomain(pcname, profile);

            if (winversion == 0)
            {
                ostpath = backslashes + pcname + @"\" + cshare + @"\" + @"Documents and Settings\" + profile + @"\Local Settings\Application Data\Microsoft\Outlook\";
            }
            else
            {
                ostpath = backslashes + pcname + @"\" + cshare + @"\" + @"Users\" + profile + @"\AppData\Local\Microsoft\Outlook\";
            }


            FileInfo ostInfo;
            long ostSize, readableSize;

            try
            {
                string[] ostFiles = Directory.GetFiles(ostpath, "*.ost", SearchOption.TopDirectoryOnly);
                foreach (string i in ostFiles)
                {
                    ostInfo = new FileInfo(i);
                    ostSize = ostInfo.Length;
                    readableSize = ostSize / 1024 / 1024;
                    //MessageBox.Show(i + " file size: " + readableSize.ToString() + " MB");
                    resultList.Add(i);
                    resultList.Add("  File Size: " + readableSize.ToString() + " MB");
                    resultList.Add("");
                }
            }
            catch (Exception ostError)
            {
                MessageBox.Show(ostError.Message);
            }

            FileInfo pstInfo;
            long pstSize, readableSize2;
            ostpathMyDocs = GetDesktopLocation(profile) + profile + @"\Documents\Outlook Files\";

            try
            {
                string[] pstFiles = Directory.GetFiles(ostpath, "*.pst", SearchOption.TopDirectoryOnly);
                foreach (string j in pstFiles)
                {
                    pstInfo = new FileInfo(j);
                    pstSize = pstInfo.Length;
                    readableSize2 = pstSize / 1024 / 1024;
                    //MessageBox.Show(j + " file size: " + readableSize2.ToString() + " MB");
                    resultList.Add(j);
                    resultList.Add("  File Size: " + readableSize2.ToString() + " MB");
                    resultList.Add("");
                }
                if (Directory.Exists(ostpathMyDocs))
                {
                    string[] pstFilesMyDocs = Directory.GetFiles(ostpathMyDocs, "*.pst", SearchOption.TopDirectoryOnly);
                    foreach (string g in pstFilesMyDocs)
                    {
                        pstInfo = new FileInfo(g);
                        pstSize = pstInfo.Length;
                        readableSize2 = pstSize / 1024 / 1024;
                        //MessageBox.Show(g + " file size: " + readableSize2.ToString() + " MB");
                        resultList.Add(g);
                        resultList.Add("  File Size: " + readableSize2.ToString() + " MB");
                        resultList.Add("");
                    }
                }
            }
            catch (Exception pstError)
            {
                MessageBox.Show(pstError.Message);
            }
            return resultList;
        }

        public void ClearClipboard(string pcname, string profile)
        {
            try
            {
                pcname = CleanPCName(pcname);
                profile = CheckForProfileDotDomain(pcname, profile);

                if (PcNameIsNotNullOrVoid(pcname) && !string.IsNullOrEmpty(profile))
                {
                    try
                    {
                        if (!File.Exists(backslashes + pcname + @"\" + cshare + @"\Windows\System32\ClearClipboard.bat"))
                        {
                            File.Copy(@"\\adm-dc\IT Dept\Clear Clipboard\PutTheseFilesInSystem32\ClearClipboard.bat", backslashes + pcname + @"\" + cshare + @"\Windows\System32\ClearClipboard.bat");
                        }
                        if (!File.Exists(GetDesktopLocation(profile) + profile + @"\Desktop\Clear Clipboard.lnk"))
                        {
                            File.Copy(@"\\adm-dc\IT Dept\Clear Clipboard\Clear Clipboard.lnk", GetDesktopLocation(profile) + profile + @"\Desktop\Clear Clipboard.lnk");
                        }

                        MessageBox.Show("Created shortcut to Clear Clipboard.bat on " + profile + "'s Desktop");

                    }
                    catch (IOException ioe)
                    {
                        MessageBox.Show(ioe.Message);
                    }

                }
            }
            catch (Exception clipboardException)
            {
                MessageBox.Show(clipboardException.Message);
            }
        }

        public void RebootTheMachine(string pcname)
        {
            try
            {
                pcname = CleanPCName(pcname);

                DialogResult yesNoDialog;
                yesNoDialog = MessageBox.Show("Are you sure you want to reset " + pcname + "?", "Reset PC?", MessageBoxButtons.YesNo);

                if (yesNoDialog == DialogResult.Yes)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "shutdown";
                    proc.StartInfo.Arguments = "-m " + pcname + " -r -f -t 10";
                    MessageBox.Show("PC will reboot in 10 seconds after you press OK.");
                    proc.Start();
                    //proc.WaitForExit();
                }
            }
            catch (Exception restartException)
            {
                MessageBox.Show(restartException.Message);
            }
        }

        public void RebootTheMachine(string pcname, bool abort)
        {
            try
            {
                pcname = CleanPCName(pcname);

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "shutdown";
                proc.StartInfo.Arguments = "-m " + pcname + " -a";
                proc.Start();
                MessageBox.Show("Shutdown aborted.");
                //proc.WaitForExit();
            }
            catch (Exception restartException)
            {
                MessageBox.Show(restartException.Message);
            }
        }

        public void RunGPUpdateForce(string pcname)
        {
            try
            {
                pcname = CleanPCName(pcname);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = @"psexec";
                if (PcNameIsNotNullOrVoid(pcname))
                {
                    proc.StartInfo.Arguments = backslashes + pcname + " " + "gpupdate /force";
                }
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception gpException)
            {
                MessageBox.Show(gpException.Message);
            }
        }

        public void RemoteCMDLine(string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                pcname = CleanPCName(pcname);
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "psexec";
                    proc.StartInfo.Arguments = backslashes + pcname + " cmd";
                    proc.Start();
                    //proc.WaitForExit();
                }
                catch (Exception restartException)
                {
                    MessageBox.Show(restartException.Message);
                }
            }
        }


    }
}
