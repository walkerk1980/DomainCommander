@echo OFF
set COMPUTERNAME=%1
set PROFILENAME="All Users"
set PROFILENAME=%2



del /Q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\Temp\*

rmdir /s /Q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\Temp\

mkdir \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\Temp\

del /q \\%COMPUTERNAME%\C$\windows\temp\*

rmdir /s /q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.ie5\

mkdir \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.ie5\

del /q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.MSO\*

rmdir /s /q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.MSO\

mkdir \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.MSO\

del /q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.Outlook\*

rmdir /s /q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.Outlook\

mkdir \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.Outlook\

del /q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.word\*

rmdir /s /q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.word\

mkdir \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.word\

del /q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.ie5\*

rmdir /s /q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.ie5\

mkdir \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\content.ie5\

del /Q \\%COMPUTERNAME%\C$\"Documents and Settings"\%PROFILENAME%\"Local Settings"\"Temporary Internet Files"\*

echo.

set /P USERNAME=Press Enter to continue... %=%