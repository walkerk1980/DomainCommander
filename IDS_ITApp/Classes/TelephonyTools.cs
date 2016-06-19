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
    class TelephonyTools
    {
        public void UpdateDvmIPs(string subnet, string dvmIP)
        {
            try
            {
                int subnetInt;
                subnet = subnet.Trim();
                dvmIP = dvmIP.Trim();
                int.TryParse(subnet, out subnetInt);
                if (String.IsNullOrEmpty(subnet) || String.IsNullOrEmpty(dvmIP))
                {
                    MessageBox.Show("Subnet or DVM IP not specified.");
                }
                else if (subnetInt == 0 && !String.Equals(subnet, "0")) 
                {
                    //Had to do this comparison because when int.TryParse fails it sets subnetInt to 0,
                    //which can be a valid subnet input
                    MessageBox.Show("Subnet " + subnet + " is not valid.");
                }
                else if (subnetInt > 255 || subnetInt < 0)
                {
                    MessageBox.Show("Subnet " + subnet + " out of range.");
                }
                else if (!IsValidIPv4(dvmIP))
                {
                    MessageBox.Show("IP address \"" + dvmIP + "\" is invalid.");
                }
                else
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "UpdateDVMbySubnet.bat";
                    proc.StartInfo.Arguments = subnet + " " + dvmIP;
                    proc.Start();
                    //proc.WaitForExit();
                }
            }
            catch (Exception dvmException)
            {
                MessageBox.Show(dvmException.Message);
            }
        }

        public bool IsValidIPv4(string value)
        {
            var quads = value.Split('.');

            // if we do not have 4 quads, return false
            if (!(quads.Length == 4)) return false;
            // for each quad
            foreach (var quad in quads)
            {
                int q;
                // if parse fails 
                // or length of parsed int != length of quad string (i.e.; '1' vs '001')
                // or parsed int < 0
                // or parsed int > 255
                // return false
                if (!Int32.TryParse(quad, out q)
                    || !q.ToString().Length.Equals(quad.Length)
                    || q < 0
                    || q > 255) { return false; }
            }
            return true;
        }
    }
}
