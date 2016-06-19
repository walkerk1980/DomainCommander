using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Permissions;

namespace DomainCommander
{
    public class WmiTools : CommonTools
    {

        public List<string> WMIGetInstalledSoftware(string pcname)
        {
            string query = "select Name from win32_product";

            pcname = CleanPCName(pcname);

            StringBuilder queryResult = new StringBuilder();
            List<string> resultList = new List<string>();
            try
            {
                ManagementScope scope = new ManagementScope(backslashes + pcname + @"\root\cimv2");
                scope.Connect();
                ObjectQuery obquery = new ObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, obquery);

                foreach (ManagementObject obj in searcher.Get())
                {
                    try
                    {
                        resultList.Add(obj["Name"].ToString());
                    }
                    catch
                    {
                        resultList.Add("Unknown");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            resultList.Sort();
            return resultList;
        }

        public List<string> WMIGetHotfixes(string pcname)
        {
            string query = "select HotFixID from Win32_QuickFixEngineering";

            pcname = CleanPCName(pcname);

            StringBuilder queryResult = new StringBuilder();
            List<string> resultList = new List<string>();
            try
            {
                ManagementScope scope = new ManagementScope(backslashes + pcname + @"\root\cimv2");
                scope.Connect();
                ObjectQuery obquery = new ObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, obquery);
                foreach (ManagementObject obj in searcher.Get())
                {
                    try
                    {
                        if (!obj["HotFixID"].Equals(null))
                        {
                            if (!obj["HotFixID"].ToString().Contains("File 1"))
                            {
                                resultList.Add(obj["HotFixID"].ToString());
                            }
                        }
                    }
                    catch
                    {
                        resultList.Add("Unknown");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            resultList.Sort();
            return resultList;
        }

        public List<string> WMIGetServiceTag(string pcname)
        {
            string query = "Select * from Win32_SystemEnclosure";

            pcname = CleanPCName(pcname);

            pcname = CleanPCName(pcname);
            StringBuilder queryResult = new StringBuilder();
            List<string> resultList = new List<string>();
            try
            {
                ManagementScope scope = new ManagementScope(backslashes + pcname + @"\root\cimv2");
                scope.Connect();
                ObjectQuery obquery = new ObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, obquery);
                foreach (ManagementObject obj in searcher.Get())
                {
                    try
                    {
                        resultList.Add(obj["SerialNumber"].ToString());
                    }
                    catch
                    {
                        resultList.Add("Unknown");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            resultList.Sort();
            return resultList;
        }

        public List<string> WMIGetPrinterList(string pcname)
        {
            string query = "Select * from Win32_Printer";

            pcname = CleanPCName(pcname);

            StringBuilder queryResult = new StringBuilder();
            List<string> resultList = new List<string>();
            if (PcNameIsNotNullOrVoid(pcname))
            {
                try
                {
                    ManagementScope scope = new ManagementScope(backslashes + pcname + @"\root\cimv2");
                    scope.Connect();
                    ObjectQuery obquery = new ObjectQuery(query);
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, obquery);
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        try
                        {
                            resultList.Add("Name: " + obj["Name"].ToString());
                            resultList.Add("Port: " + obj["PortName"].ToString());
                            resultList.Add("DeviceID: " + obj["DeviceID"].ToString());
                            resultList.Add("DriverName: " + obj["DriverName"].ToString());
                            if (obj["Shared"].ToString().Equals(true.ToString()))
                            {
                                resultList.Add("Share Name: " + obj["ShareName"].ToString());
                            }
                            //resultList.Add("Status: " + obj["Status"].ToString());
                            //resultList.Add("Printer Status: " + obj["PrinterStatus"].ToString());
                            //resultList.Add("Printer State: " + obj["PrinterState"].ToString());

                            //int state = Int32.Parse(obj["ExtendedPrinterStatus"].ToString());
                            //switch (state)
                            //{
                            //    case 1: //Other
                            //        resultList.Add("Other");
                            //        break;
                            //    case 2: //Unknown
                            //        resultList.Add("Unknown 2");
                            //        break;
                            //    case 7: //Offline
                            //        resultList.Add("Offline");

                            //        break;
                            //    case 9: //error
                            //        resultList.Add("Error");
                            //        break;
                            //    case 11: //Not Available
                            //        break;
                            //    default:
                            //        resultList.Add("None of the above.");
                            //        break;
                            //}

                            resultList.Add("");

                        }
                        catch
                        {
                            resultList.Add("Unknown");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            //resultList.Sort();
            return resultList;
        }

        //Deletes the printer
        public void WMIDeletePrinter(string pcname, string printerName)
        {
            try
            {
                if (PcNameIsNotNullOrVoid(pcname) && !string.IsNullOrEmpty(printerName))
                {
                    string query = @"SELECT * FROM Win32_Printer WHERE Name = '" + printerName.Replace("\\", "\\\\") + "'";

                    pcname = CleanPCName(pcname);

                    ManagementScope scope = new ManagementScope(backslashes + pcname + @"\root\cimv2");
                    scope.Connect();

                    SelectQuery obquery = new SelectQuery(query);

                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, obquery);
                    ManagementObjectCollection oObjectCollection = searcher.Get();

                    if (oObjectCollection.Count > 0)
                    {
                        foreach (ManagementObject oItem in oObjectCollection)
                        {
                            oItem.Delete();
                            MessageBox.Show(oItem["Name"].ToString() + " deleted.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Printer not Found");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public List<string> WMIGetLoggedOnUser(string pcname)
        {
            string query = "select UserName from Win32_ComputerSystem";

            pcname = CleanPCName(pcname);

            StringBuilder queryResult = new StringBuilder();
            List<string> resultList = new List<string>();
            try
            {
                ManagementScope scope = new ManagementScope(backslashes + pcname + @"\root\cimv2");
                scope.Connect();
                ObjectQuery obquery = new ObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, obquery);
                foreach (ManagementObject obj in searcher.Get())
                {
                    try
                    {
                        resultList.Add(obj["UserName"].ToString());
                    }
                    catch
                    {
                        resultList.Add("Unknown");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            resultList.Sort();
            return resultList;
        }

        public List<string> GetMappedDrives(string pcname)
        {

            pcname = CleanPCName(pcname);

            List<string> resultList = WMIGetMappedDrives(pcname);
            List<string> resultList2 = RegGetMappedDrives(pcname);
            resultList.Add("");
            List<string> combinedList = new List<string>();
            combinedList.AddRange(resultList);
            combinedList.AddRange(resultList2);
            return combinedList;
        }

        private List<string> WMIGetMappedDrives(string pcname)
        {
            List<string> resultList = new List<string>();
            string query = "Select * from Win32_MappedLogicalDisk";
            StringBuilder queryResult = new StringBuilder();
            try
            {
                ManagementScope scope = new ManagementScope(backslashes + pcname + @"\root\cimv2");
                scope.Connect();
                ObjectQuery obquery = new ObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, obquery);
                foreach (ManagementObject obj in searcher.Get())
                {
                    try
                    {
                        resultList.Add(obj["Name"].ToString() + " " + obj["ProviderName"]);
                    }
                    catch
                    {
                        resultList.Add("Unknown");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //resultList.Sort();
            return resultList;
        }

        private List<string> RegGetMappedDrives(string pcname)
        {
            string sid = WmiGetUserSID(pcname, WmiGetExplorerProcessOwner(pcname));

            pcname = CleanPCName(pcname);

            RegistryKey regKey;
            StringBuilder queryResult = new StringBuilder();
            List<string> resultList = new List<string>();
            try
            {
                regKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.Users, pcname).OpenSubKey(sid + @"\\Network");
                //PrintKeys(rk);
                foreach (string subKeyName in regKey.GetSubKeyNames())
                {
                    try
                    {
                        string strPath = regKey.OpenSubKey(subKeyName).GetValue("RemotePath").ToString();
                        resultList.Add(subKeyName + ":  " + strPath);
                    }
                    catch
                    {
                        resultList.Add("Unknown");
                    }
                }
                regKey.Close();
                resultList.Sort();
                regKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.Users, pcname).OpenSubKey(sid + @"\\Volatile Environment");
                resultList.Add(regKey.GetValue("HOMEDRIVE").ToString() + "  " + regKey.GetValue("HOMESHARE").ToString() + "  (HOMEDRIVE setting)");
                regKey.Close();

            }
            catch //(Exception e)
            {
                //MessageBox.Show(e.GetType().Name + ": " + e.Message);
                resultList.Add("");
            }
            return resultList;
        }

        private string WmiGetUserSID(string pcname, string domainBslashAccount)
        {
            string domain, user;
            domain = domainBslashAccount.Substring(0, domainBslashAccount.IndexOf(@"\"));
            user = domainBslashAccount.Substring(domainBslashAccount.IndexOf(@"\") + 1);
            //string query = "Select * from Win32_UserAccount" + " Where Name='hadye' and Domain='domain'";
            string query = "Select * from Win32_UserAccount" + " Where Name='" + user + "' and Domain='" + domain + "'";
            ManagementScope scope = new ManagementScope(backslashes + pcname + @"\root\cimv2");
            string sid = "unknown";
            StringBuilder queryResult = new StringBuilder();
            List<string> resultList = new List<string>();

            pcname = CleanPCName(pcname);

            try
            {
                scope.Connect();
                ObjectQuery obquery = new ObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, obquery);

                foreach (ManagementObject obj in searcher.Get())
                {
                    try
                    {
                       sid = obj["SID"].ToString();
                        return sid;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return sid;
                    }
                }
                return sid;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "SID unknown";
            }
        }

        private string WmiGetExplorerProcessOwner(string pcname)
        {
            string query = "Select * from Win32_Process" + " Where Name='explorer.exe'"; // and SessionID=0"; sessionid=0 is not correct on widnows7
            ManagementScope scope = new ManagementScope(backslashes + pcname + @"\root\cimv2");
            StringBuilder queryResult = new StringBuilder();
            List<string> resultList = new List<string>();

            pcname = CleanPCName(pcname);

            try
            {
                scope.Connect();
                ObjectQuery obquery = new ObjectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, obquery);
                //MessageBox.Show(searcher.Get().Count.ToString());

                if (searcher.Get().Count >= 0)
                {
                    ManagementObjectCollection processList = searcher.Get();

                    foreach (ManagementObject obj in processList)
                    {
                        string[] argList = new string[] { string.Empty, string.Empty };
                        int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                        if (returnVal == 0)
                        {
                            // return DOMAIN\user
                            string owner = argList[1] + "\\" + argList[0];
                            return owner;
                        }
                    }
                }
                else
                {
                    return @"localhost\administrator";
                }
                return @"localhost\administrator";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return @"localhost\administrator";
            }
        }

        //static void PrintRegKeys(RegistryKey rkey)
        //{

        //    // Retrieve all the subkeys for the specified key.
        //    String[] names = rkey.GetSubKeyNames();

        //    int icount = 0;

        //    MessageBox.Show("Subkeys of " + rkey.Name);
        //    MessageBox.Show("-----------------------------------------------");

        //    // Print the contents of the array to the console.
        //    foreach (String s in names)
        //    {
        //        MessageBox.Show(s);

        //        // The following code puts a limit on the number
        //        // of keys displayed.  Comment it out to print the
        //        // complete list.
        //        icount++;
        //        if (icount >= 10)
        //            break;
        //    }
        //}

    }
}
