@echo off
::kwalker 4/12/2013

echo.
:echo Enter the subnet, (0-255) number only,
:set /P SUBNET=that you would like to update PCM DVM IPs on:  %=%
set SUBNET=%1
echo.
::echo Please enter ip address you would like DVMs to be set to in subnet
:set /P DVMIP=Example 192.168.97.10: %=% 
set DVMIP=%2

c:
cd "c:\Documents and Settings"\%username%\Desktop

del ShoretelDvmUpdater%SUBNET%.bat

echo @echo off >>ShoretelDvmUpdater%SUBNET%.bat
echo echo USAGE: ShoretelDvmSingleUser.exe [DVM IP ADDRESS] >>ShoretelDvmUpdater%SUBNET%.bat
echo reg.exe add "HKEY_CURRENT_USER\SOFTWARE\Shoreline Teleworks\ShoreWare Client" /f /v Server /t REG_SZ /d %DVMIP% >>ShoretelDvmUpdater%SUBNET%.bat
echo del %%0 >>ShoretelDvmUpdater%SUBNET%.bat

for /l %%x IN (1, 1, 254) do (
echo.
echo Updating 192.168.%SUBNET%.%%x PCM to %DVMIP% DVM
echo.
echo.
echo Copying Files to startup folder on 192.168.%SUBNET%.%%x
echo.

copy /Y "ShoretelDvmUpdater%SUBNET%.bat" "\\192.168.%SUBNET%.%%x\c$\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup\"
copy /Y "ShoretelDvmUpdater%SUBNET%.bat" "\\192.168.%SUBNET%.%%x\c$\Documents and Settings\All Users\Start Menu\Programs\Startup\"
echo.

echo.
)

del ShoretelDvmUpdater%SUBNET%.bat

set /P USERNAME=Press Enter to continue... %=%
