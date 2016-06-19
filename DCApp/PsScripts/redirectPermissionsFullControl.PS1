Write-Host ""
Write-Host ""
$startingDir = "\\adm-fs\redirect"
$domain = "headstart"
cd $startingDir

Function setPermissions
{
    param ($file, $user)
    $user = $domain + "\" + $user
    Write-Host user is $user
    $objUser = New-Object System.Security.Principal.NTAccount($user)
    $objDomAdmin = New-Object System.Security.Principal.NTAccount($user)
    $InheritanceFlag = [System.Security.AccessControl.InheritanceFlags]"ContainerInherit, ObjectInherit"
    $PropagationFlag = [System.Security.AccessControl.PropagationFlags]"NoPropagateInherit"
    $objType =[System.Security.AccessControl.AccessControlType]::Allow
    $objACEFull = New-Object System.Security.AccessControl.FileSystemAccessRule `
        ($objUser, "FullControl", $InheritanceFlag, $PropagationFlag, $objType)
    $acl = Get-Acl $file.ToString()
    $acl.SetOwner($objUser)
    Set-Acl $file $acl
    $acl.AddAccessRule($objACEFull)
    Set-Acl $file $acl
    Get-Acl $file |fl
    Get-ChildItem $file -Recurse | ForEach-Object {
        setOwner $_.FullName.ToString() $objUser
    }
}

Function setOwner
{
    param ($file, $user)
    Write-Host Setting ownership of $file to $user
    $owner = New-Object System.Security.Principal.NTAccount($user)
    $acl = Get-Acl $file
    $acl.SetOwner($owner)
    Set-Acl $file $acl
}


Get-ChildItem $startingDir | ForEach-Object {
    $folderFullPath = $_.FullName
    $user = $_.Name.ToString()
    Write-Host Setting permissions on $folderFullPath
    setPermissions $folderFullPath $user
}

