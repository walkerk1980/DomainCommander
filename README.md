DomainCommander
===============

Application for performing common IT tasks on remote Windows computers

Replace all Placeholder files with the respective files from the download links contained in the Placeholder.

PsTools and GPInventory are required for full functionality.

A Microsoft SQL database with a table named 'pcnames' and two columns 'username' and 'pcname', with username being the primary unique key.


----------
2015.4.20
Added Tools -> System Tools -> Remote Command Line (Brings up an interactive dos command line on remote pc)

----------
2014.10.24
Added Tools -> Exchange Tools -> Blocked Senders
Added Tools -> Exchange Tools -> Whitelisted Senders
Added Tools -> Exchange Tools -> Blacklisted Domains
Added Tools -> Exchange Tools -> Whitelisted Domains

----------
2014.10.23

Added Tools -> User Tools -> Populate AD Locations
Populates OfficeLocation based on group memberships defined in application properties
Added Tools -> User Tools -> Populate AD Titles
Populates Title based on group memberships defined in application properties
Added Tools -> Exchange Tools -> Get Mailbox

----------
2014.1.23

Update strings and OU's for AKA
Change MapRBJDrives to MapPY48forms
Fixed date in description when enabling/disabling users

----------
2013.7.21

Bugfix release

----------
2013.7.17

Updated Termination email templates BCC line to include ID Card Access Requests email

----------
2013.7.16

Added Tools -> User Tools -> Send Termination Email
Added Tools -> Network Tools -> DHCP Renew (ipconfig /renew)

----------
2013.6.21

Added Tools -> Network Tools -> Netstat

----------
2013.6.13

Added Tools -> Network Tools -> Disable Firewall
Added Tools -> Network Tools -> Enable Remote Desktop

----------
2013.6.11

Added Tools -> Application Tools -> Get Browser Version

----------
2013.5.29

Added Tools -> System Tools -> Update Group Policy (gpupdate /force)

----------
2013.5.10

Added AD user info to prompt when disabling user account
Added Tools -> User Tools -> Get User's AD Info

----------
2013.5.2

Added TelephonyTools Class
Added Tools -> Testing -> SubnetPcmServerUpdater in Menu
Added functionality to update Shoretel DVM IP in PCMs subnet wide

----------
2013.4.26

Added Tools -> User Tools -> GetSamAccountName and matching method.
Added Tools -> User Tools -> GetFullName and matching method.
Added Full Name to title bar of window returned by Tools -> User Tools -> Show AD Groups

----------
2013.4.2

Added tolerance for profiles ending in .DOMAIN.
Improved tolerance for PCNAMES starting with backslashes.

----------
2013.3.27

Changed OST printouts to list instead of Message Boxes.
Added Help -> Changelog.

----------
