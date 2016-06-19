using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Windows.Forms;

namespace DomainCommander
{
    class UserPrincipalExSearchFilter : AdvancedFilters
    {
        public UserPrincipalExSearchFilter(Principal p) : base(p) { }

        public void LogonCount(int value, MatchType mt)
        {
            this.AdvancedFilterSet("Logoncount", value, typeof(int), mt);
        }
    }
}
