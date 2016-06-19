using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DomainCommander
{
    public class ApplicationTools : CommonTools
    {
        
        public void DisableJavaUpdate(string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                pcname = CleanPCName(pcname);
                if (Directory.Exists(@"\\" + pcname + @"\" + cshare + @"\Program Files\Common Files\Java\Java Update"))
                {
                    Directory.Move(@"\\" + pcname + @"\" + cshare + @"\Program Files\Common Files\Java\Java Update", @"\\" + pcname + @"\" + cshare + @"\Program Files\Common Files\Java\Java Update.bak");
                    MessageBox.Show("Java Update Disabled");
                }
                else
                {
                    MessageBox.Show("Java Update Already Disabled.");
                }
            }
        }

        public void DisablePopupBlocker(string pcname, string profile)
        {
            try
            {
                if (PcNameIsNotNullOrVoid(pcname) && !string.IsNullOrEmpty(profile))
                {
                    pcname = CleanPCName(pcname);
                    profile = CheckForProfileDotDomain(pcname, profile);
                    //string filename = backslashes + pcname + @"\" + cshare + @"\Documents and Settings\" + profile + @"\Desktop\Disable PopUp Blocker.bat";
                    string filename = GetDesktopLocation(profile) +profile + @"\Desktop\Disable PopUp Blocker.bat";
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                    }
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filename))
                        {
                            writer.WriteLine(@"@echo off");
                            writer.WriteLine(@"");
                            writer.WriteLine(@"echo Windows Registry Editor Version 5.00 >popup.reg");
                            writer.WriteLine(@"echo ;Pop up blocker disable >>popup.reg");
                            writer.WriteLine(@"echo [HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\2]  >>popup.reg");
                            writer.WriteLine("echo \"1809\"=dword:00000003 >>popup.reg");
                            writer.WriteLine("echo \"2200\"=dword:00000000 >>popup.reg");
                            writer.WriteLine("echo \"1609\"=dword:00000000 >>popup.reg");
                            writer.WriteLine("echo \"2101\"=dword:00000000 >>popup.reg");
                            writer.WriteLine(@"");
                            writer.WriteLine(@"regedit.exe /s popup.reg");
                            writer.WriteLine(@"");
                            writer.WriteLine(@"del /q popup.reg");
                            writer.WriteLine(@"del %0");
                            writer.Flush();
                            writer.Close();
                            MessageBox.Show("Created Disable PopUp Blocker.bat on " + profile + "'s Desktop.");
                            writer.Dispose();
                        }
                    }
                    catch (IOException ioe)
                    {
                        MessageBox.Show(ioe.Message);
                    }

                }
            }
            catch (Exception popupException)
            {
                MessageBox.Show(popupException.Message);
            }
        }

        public void GetBrowserVersion(string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                try
                {
                    pcname = CleanPCName(pcname);
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "browserVsn.vbs";
                    proc.StartInfo.Arguments = pcname;
                    proc.Start();
                    //proc.WaitForExit();
                }
                catch (Exception browserVersionException)
                {
                    MessageBox.Show(browserVersionException.Message);
                }
            }
        }

    }
}
