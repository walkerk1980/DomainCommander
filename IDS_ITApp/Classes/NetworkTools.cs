using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DomainCommander
{
    public class NetworkTools : CommonTools
    {

        public void PingTheMachine(string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                pcname = CleanPCName(pcname);
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "ping";
                    proc.StartInfo.Arguments = "-a -t " + pcname;
                    proc.Start();
                    //proc.WaitForExit();
                }
                catch (Exception restartException)
                {
                    MessageBox.Show(restartException.Message);
                }
            }

        }

        public void FlushDNS(string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                pcname = CleanPCName(pcname);
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "psexec";
                    proc.StartInfo.Arguments = backslashes + pcname + " cmd /c \"ipconfig /flushdns & pause\"";
                    proc.Start();
                    //proc.WaitForExit();
                }
                catch (Exception restartException)
                {
                    MessageBox.Show(restartException.Message);
                }
            }
        }

        public void NetworkInfo(string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                pcname = CleanPCName(pcname);
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "psexec";
                    proc.StartInfo.Arguments = backslashes + pcname + " cmd /c \"ipconfig /all & pause\"";
                    proc.Start();
                    //proc.WaitForExit();
                }
                catch (Exception restartException)
                {
                    MessageBox.Show(restartException.Message);
                }
            }
        }

        public void Netstat(string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                pcname = CleanPCName(pcname);
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "psexec";
                    proc.StartInfo.Arguments = backslashes + pcname + " cmd /c \"netstat & pause\"";
                    proc.Start();
                    //proc.WaitForExit();
                }
                catch (Exception restartException)
                {
                    MessageBox.Show(restartException.Message);
                }
            }
        }

        public void DisableFirewall(string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                pcname = CleanPCName(pcname);
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "psexec";
                    proc.StartInfo.Arguments = backslashes + pcname + " " + "netsh firewall set opmode disable";
                    proc.Start();
                    //proc.WaitForExit();
                    MessageBox.Show("Firewall Disabled.");
                }
                catch (Exception firewallException)
                {
                    MessageBox.Show(firewallException.Message);
                }
            }
        }

        public void EnableRemoteDesktop(string pcname)
        {
            pcname = CleanPCName(pcname);
            if (PcNameIsNotNullOrVoid(pcname))
            {
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "psexec";
                    proc.StartInfo.Arguments = backslashes + pcname + " " + "\"\"reg add \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server\" /v fDenyTSConnections /t REG_DWORD /d 0 /f\"\"";
                    proc.Start();
                    //proc.WaitForExit();
                    MessageBox.Show("Remote Desktop Enabled.");
                }
                catch (Exception firewallException)
                {
                    MessageBox.Show(firewallException.Message);
                }
            }
        }

        public void RenewDHCPLease(string pcname)
        {
            if (PcNameIsNotNullOrVoid(pcname))
            {
                pcname = CleanPCName(pcname);
                try
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "psexec";
                    proc.StartInfo.Arguments = backslashes + pcname + " cmd /c \"ipconfig /renew & pause\"";
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
