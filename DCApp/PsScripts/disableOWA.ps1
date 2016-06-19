$members=Get-Group -Identity "all aka employees" |select members

Foreach($person in $members)
{
$name = $person.members.name
    Foreach($n in $name)
    {
        Write-Host $n
        Set-CasMailbox -identity $n -OWAEnabled $false
    }
}