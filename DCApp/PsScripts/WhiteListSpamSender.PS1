Add-PSSnapin Microsoft.Exchange.Management.PowerShell.SnapIn
$sender = Read-Host 'Enter the name of the sender you would like to WHITELIST '
Set-ContentFilterConfig -BypassedSenders @{Add=$sender}