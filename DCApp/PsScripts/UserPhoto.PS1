param([String]$UserName)
Add-PSSnapin Microsoft.Exchange.Management.PowerShell.SnapIn
if (!$UserName) {
    $UserName = Read-Host "Please place photo into \\headstart.admin\share\redirect\UserName\ folder with naming format username.jpg and then type UserName into this script and press enter"
}
Remove-UserPhoto $UserName -Confirm:$False
$DefaultPhotoPath = “\\headstart.admin\share\redirect\” + $UserName + "\"
$PhotoPath = $DefaultPhotoPath + $UserName + “.jpg”
$photo = ([Byte[]] $(Get-Content -Path $PhotoPath -Encoding Byte -ReadCount 0))
Set-UserPhoto -Identity $UserName -PictureData $photo -Confirm:$False
Set-UserPhoto -Identity $UserName -Save -Confirm:$False