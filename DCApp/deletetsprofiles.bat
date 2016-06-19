@echo off

set USERTODELETE=nouser

IF .%1 == . (
 echo "Input argument missing: user to delete"
 echo.
 echo Deletes all user profiles for specified user on
 echo MH, QLS, QE and QCMC Terminal Servers
 echo.
 echo The syntax of this command is:
 echo.
 echo DeleteTSProfiles USERTODELETE
 set USERTODELETE=nouser
 echo.
 set /P USERNAME=Press Enter to continue... %=%
 GOTO :eof
)

set USERTODELETE=%1

echo QLS-TS1
rmdir /q /s "\\qls-ts1\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS1
rmdir /q /s "\\mh-ts1\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS2
rmdir /q /s "\\vm-ts2\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS3
rmdir /q /s "\\vm-ts3\f$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS4
rmdir /q /s "\\vm-ts4\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS5
rmdir /q /s "\\vm-ts5\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS6
rmdir /q /s "\\vm-ts6\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS7
rmdir /q /s "\\vm-ts7\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS8
rmdir /q /s "\\mh-ts8\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS9
rmdir /q /s "\\vm-ts9\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS10
rmdir /q /s "\\vm-ts10\e$\Documents and Settings"\%USERTODELETE%
echo.
echo MH-TS11
rmdir /q /s "\\mh-ts11\e$\Documents and Settings\Users"\%USERTODELETE%
echo.
echo QE-TS1
rmdir /q /s "\\qe-ts1\e$\Documents and Settings"\%USERTODELETE%
echo.
echo QCMC-TS1
rmdir /q /s "\\qcmc-ts1\e$\Documents and Settings"\%USERTODELETE%
echo.
echo QCMC-TS2
rmdir /q /s "\\qcmc-ts2\e$\Documents and Settings"\%USERTODELETE%

echo.
echo Finished deleting %USERTODELETE%'s profiles from Terminal Servers.
echo.
set /P USERNAME=Press Enter to continue... %=%