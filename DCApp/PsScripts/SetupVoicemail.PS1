Add-PSSnapin Microsoft.Exchange.Management.PowerShell.SnapIn

$user = Read-Host 'Enter the name of the user you would like to setup voicemail for '

$extension = Read-Host 'Enter 4 digit extension of user '

Enable-UMMailbox -UMMailboxPolicy "AdminDialPlan Default Policy" -PinExpired $true -Pin 8989 -Extensions $extension -Identity $user
