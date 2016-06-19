using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace DomainCommander
{
    public class PrinterTools : CommonTools
    {

        public void RestartTheSpooler(string pcname)
        {
            try
            {
                StopTheSpooler(pcname);

                Thread.Sleep(1500);

                //Thread stopSpoolThread = new Thread(new ThreadStart(stopTheSpooler));
                //stopSpoolThread.Start();

                DeletePrintJobs(pcname);

                StartTheSpooler(pcname);
            }
            catch (Exception spoolerException)
            {
                MessageBox.Show(spoolerException.Message);
            }
        }

        public void StopTheSpooler(string pcname)
        {
            pcname = CleanPCName(pcname);

            //stop spooler
            System.Diagnostics.Process stopspooler = new System.Diagnostics.Process();
            stopspooler.EnableRaisingEvents = false;
            stopspooler.StartInfo.FileName = "psservice";
            if (PcNameIsNotNullOrVoid(pcname))
            {
                stopspooler.StartInfo.Arguments = backslashes + pcname + " stop spooler";
                stopspooler.Start();
                stopspooler.WaitForExit();
            }

        }

        public void DeletePrintJobs(string pcname)
        {
            //delete print jobs
            if (PcNameIsNotNullOrVoid(pcname))
            {
                if (Directory.Exists(backslashes + pcname + @"\" + cshare + @"\windows\system32\spool\printers\"))
                {
                    Directory.Delete(backslashes + pcname + @"\" + cshare + @"\windows\system32\spool\printers", true);
                }
                Directory.CreateDirectory(backslashes + pcname + @"\" + cshare + @"\windows\system32\spool\PRINTERS");
            }
        }

        public void StartTheSpooler(string pcname)
        {
            //start spooler
            System.Diagnostics.Process startspooler = new System.Diagnostics.Process();
            startspooler.EnableRaisingEvents = false;
            startspooler.StartInfo.FileName = "psservice";
            if (PcNameIsNotNullOrVoid(pcname))
            {
                startspooler.StartInfo.Arguments = backslashes + pcname + " start spooler";
                startspooler.Start();
            }

        }

        public void DeletePrinter(string pcname)
        {
            string printerName = Prompt.ShowDialog("Paste Name of printer to delete.", "Delete Printer");
            WmiTools wt = new WmiTools();
            wt.WMIDeletePrinter(pcname, printerName);
        }

        public void ListPrinters(string pcname)
        {
            StringBuilder sb = new StringBuilder();
            WmiTools wt = new WmiTools();
            foreach (string s in wt.WMIGetPrinterList(pcname))
            {
                sb.Append(s);
                sb.Append(Environment.NewLine);
            }
            TextBoxForm.ShowText(sb.ToString(), "Printers Mapped on " + pcname);
        }
    }
}
