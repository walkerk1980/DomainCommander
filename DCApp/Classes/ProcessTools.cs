using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DomainCommander
{
    public class ProcessTools : CommonTools
    {
        public void TaskKill(string pcname)
        {
            try
            {

                string processName = Prompt.ShowDialog("Enter name of process to kill.", "Kill Process");
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "taskkill";
                if (PcNameIsNotNullOrVoid(pcname))
                {
                    proc.StartInfo.Arguments = "/s " + pcname + " /im " + processName;
                }
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
            }
            catch (Exception killException)
            {
                MessageBox.Show(killException.Message);
            }
        }

        public void TaskList(string pcname)
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = "tasklist";
                proc.StartInfo.UseShellExecute = false;
                if (PcNameIsNotNullOrVoid(pcname))
                {
                    proc.StartInfo.Arguments = "/s " + pcname;
                }
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                //string tasklist = proc.StandardOutput.ReadToEnd();
                TextBoxForm.ShowText(proc.StandardOutput.ReadToEnd(), "Running processes on " + pcname);
                //MessageBox.Show(proc.StandardOutput.ReadToEnd());
                //proc.WaitForExit();
            }
            catch (Exception tasklistException)
            {
                MessageBox.Show(tasklistException.Message);
            }
        }
    }
}
