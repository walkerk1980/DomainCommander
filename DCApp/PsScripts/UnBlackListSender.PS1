Add-PSSnapin Microsoft.Exchange.Management.PowerShell.SnapIn
$sender = Read-Host 'Enter the name of the sender you would like to REMOVE from BLACKLIST '
Set-SenderFilterConfig -BlockedSenders @{Remove=$sender}