Add-PSSnapin Microsoft.Exchange.Management.PowerShell.SnapIn
$domain = Read-Host 'Enter the name of the domain you would like to WHITELIST '
Set-ContentFilterConfig -BypassedSenderDomains @{Add=$domain}