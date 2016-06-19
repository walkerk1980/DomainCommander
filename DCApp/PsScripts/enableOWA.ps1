$members=Get-Group -Identity "exemptemployees" |select members

Foreach($person in $members)
{
$name = $person.members.name
    Foreach($n in $name)
    {
        Write-Host $n
        Set-CasMailbox -identity $n -OWAEnabled $true
    }
}

$members=Get-Group -Identity "centerdirectors" |select members

Foreach($person in $members)
{
$name = $person.members.name
    Foreach($n in $name)
    {
        Write-Host $n
        Set-CasMailbox -identity $n -OWAEnabled $true
    }
}