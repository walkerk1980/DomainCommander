Add-PSSnapin Microsoft.Exchange.Management.PowerShell.SnapIn
$domain = Read-Host 'Enter the name of the domain you would like to REMOVE from WHITELIST '
Set-ContentFilterConfig -BypassedSenderDomains @{Remove=$domain}