Add-PSSnapin Microsoft.Exchange.Management.PowerShell.SnapIn
$domain = Read-Host 'Enter the name of the domain you would like to BLACKLIST '
Set-SenderFilterConfig -BlockedDomains @{Add=$domain} 