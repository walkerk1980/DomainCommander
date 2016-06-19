Rem Returns browser version on remote computer.


Rem strComputer = InputBox("Enter computer Name","PC Name")
strComputer = WScript.Arguments.Item(0)

Set objFSO = CreateObject("Scripting.FileSystemObject")
file = "\\" & strComputer & "\C$\Program Files\Internet Explorer\iexplore.exe"
Wscript.Echo objFSO.GetFileVersion(file)