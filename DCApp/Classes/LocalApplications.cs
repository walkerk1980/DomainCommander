using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DomainCommander
{
    public class LocalApplications
    {
        public void RunLMI()
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "C:\\Program Files\\LogMeIn Rescue Technician Console\\LogMeInRescueTechnicianConsole_x86\\LMIRTechConsole.exe";
                //proc.StartInfo.Arguments=;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception lmiException)
            {
                MessageBox.Show(lmiException.Message);
            }
        }

        public void intranetSite()
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "iexplore.exe";
                proc.StartInfo.Arguments = Properties.Settings.Default.IntranetSite;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception sharepointException)
            {
                MessageBox.Show(sharepointException.Message);
            }
        }

        public void webSite()
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "iexplore.exe";
                proc.StartInfo.Arguments = Properties.Settings.Default.WebSite;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception sharepointException)
            {
                MessageBox.Show(sharepointException.Message);
            }
        }

        public void skypeWebsite()
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "chrome";
                proc.StartInfo.Arguments = "http://www.skype.com/intl/en-us/business/skype-manager";
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception sharepointException)
            {
                MessageBox.Show(sharepointException.Message);
            }
        }

        public void RunTrackIT()
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "C:\\Program Files\\LogMeIn Rescue Technician Console\\LogMeInRescueTechnicianConsole_x86\\LMIRTechConsole.exe";
                //proc.StartInfo.Arguments=;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception lmiException)
            {
                MessageBox.Show(lmiException.Message);
            }
        }

        public void RunNotepad(string inputFileName)
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "notepad";
                proc.StartInfo.Arguments = inputFileName;
                proc.Start();
                //proc.WaitForExit();
            }
            catch (Exception lmiException)
            {
                MessageBox.Show(lmiException.Message);
            }
        }

    }
}
