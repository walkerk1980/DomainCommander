using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Windows.Forms;

namespace DomainCommander
{
    [DirectoryObjectClass("user")]
    [DirectoryRdnPrefix("CN")]
    public class UserPrincipalsEx : UserPrincipal
    {
        public UserPrincipalsEx(PrincipalContext context) : base(context) { }

        public UserPrincipalsEx(PrincipalContext context, string samAccountName, string password, bool enabled) : base(context, samAccountName, password, enabled) { }

        UserPrincipalExSearchFilter searchFilter;

        new UserPrincipalExSearchFilter AdvancedSearchFilter
        {
            get
            {
                if (null == searchFilter)
                    searchFilter = new UserPrincipalExSearchFilter(this);

                return searchFilter;
            }
        }

        [DirectoryProperty("Title")]
        public string title
        {
            get
            {
                if (ExtensionGet("Title").Length != 1)
                    return null;

                return (string)ExtensionGet("Title")[0];

            }
            set { this.ExtensionSet("Title", value); }
        }

        [DirectoryProperty("Company")]
        public string company
        {
            get
            {
                if (ExtensionGet("Company").Length != 1)
                    return null;

                return (string)ExtensionGet("Company")[0];

            }
            set { this.ExtensionSet("Company", value); }
        }

        [DirectoryProperty("physicalDeliveryOfficeName")]
        public string office
        {
            get
            {
                if (ExtensionGet("physicalDeliveryOfficeName").Length != 1)
                    return null;

                return (string)ExtensionGet("physicalDeliveryOfficeName")[0];

            }
            set { this.ExtensionSet("physicalDeliveryOfficeName", value); }
        }

        [DirectoryProperty("Department")]
        public string department
        {
            get
            {
                if (ExtensionGet("Department").Length != 1)
                    return null;

                return (string)ExtensionGet("Department")[0];

            }
            set { this.ExtensionSet("Department", value); }
        }

        [DirectoryProperty("Manager")]
        public string manager
        {
            get
            {
                if (ExtensionGet("Manager").Length != 1)
                    return null;

                return (string)ExtensionGet("Manager")[0];

            }
            set { this.ExtensionSet("Manager", value); }
        }

        // Implement the overloaded search method FindByIdentity
        public static new UserPrincipalsEx FindByIdentity(PrincipalContext context, string identityValue)
        {
            return (UserPrincipalsEx)FindByIdentityWithType(context, typeof(UserPrincipalsEx), identityValue);
        }

        // Implement the overloaded search method FindByIdentity. 
        public static new UserPrincipalsEx FindByIdentity(PrincipalContext context, IdentityType identityType, string identityValue)
        {
            return (UserPrincipalsEx)FindByIdentityWithType(context, typeof(UserPrincipalsEx), identityType, identityValue);
        }

    }
}
