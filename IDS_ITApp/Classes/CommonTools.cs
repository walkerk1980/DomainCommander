using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DomainCommander
{
    public class CommonTools
    {
        protected string pcListPath = Properties.Settings.Default.pcListPath;
        protected string fullyQualifiedDomainName = Environment.UserDomainName;
        protected string organizationalUnit = "DC=" + Environment.UserDomainName + ",DC=" + Properties.Settings.Default.finalDomainComponent; // removed for AKA compatibility "OU=" + Properties.Settings.Default.OU + ",
        //protected string desktopLocation = backslashes + pcname + @"\" + cshare + @"\Documents and Settings\";
        protected string cshare = Properties.Settings.Default.cshare;
        protected System.Collections.Specialized.StringCollection desktopLocations = Properties.Settings.Default.desktopLocations;
        protected System.Collections.Specialized.StringCollection documentsLocations = Properties.Settings.Default.documentsLocations;
        protected string domain = Properties.Settings.Default.domain;
        protected string finalDomainComponent = Properties.Settings.Default.finalDomainComponent;
        public static readonly string backslashes = @"\\";
        protected static readonly string disabledUsersOU = Properties.Settings.Default.disabledUsersOU;


        public string GetDesktopLocation(string profile)
        {
            string desktopLocation = null;
            foreach (string location in desktopLocations)
            {
                if (Directory.Exists(location + profile))
                {
                    desktopLocation = location;
                }
            }
            return desktopLocation;
        }

        public string GetDocumentsLocation(string profile)
        {
            string documentsLocation = null;
            foreach (string location in desktopLocations)
            {
                if (Directory.Exists(location + profile))
                {
                    documentsLocation = location;
                }
            }
            return documentsLocation;
        }

        public string RemoveBackslashesFromPCName(string pcname)
        {
            if (pcname.Contains(@"\\"))
            {
                //backslashes = "";
                pcname = pcname.Substring(2);
            }
            else
            {
                //backslashes = @"\\";
            }
            return pcname;
        }

        public bool PcNameIsNotNullOrVoid(string pcname)
        {
            if (String.IsNullOrEmpty(pcname))
            {
                System.Windows.Forms.MessageBox.Show("PC name is empty!" + Environment.NewLine + "Using Localhost if applicable.");
                return false;
            }
            else
                return true;
        }

        public string CleanPCName(string pcname)
        {
            pcname = RemoveBackslashesFromPCName(pcname);
            pcname = pcname.Trim();
            return pcname;
        }

        public string CheckForProfileDotDomain(string pcname, string profile)
        {
            if (Directory.Exists(backslashes + pcname + @"\" + cshare + @"\Documents and Settings\" + profile + "." + domain))
            {
                profile = profile + "." + domain;
            }
            if (Directory.Exists(backslashes + pcname + @"\" + cshare + @"\Documents and Settings\" + profile + "." + domain + finalDomainComponent))
            {
                profile = profile + "." + domain + finalDomainComponent;
            }
            return profile;
        }
    }
}
