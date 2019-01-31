@ECHO OFF
REM BFCPEOPTIONSTART
REM Advanced BAT to EXE Converter www.BatToExeConverter.com
REM BFCPEEXE=C:\Users\timoh\Desktop\KillSkype.exe
REM BFCPEICON=C:\Users\timoh\Pictures\NoSkypeSmaller.ico
REM BFCPEICONINDEX=-1
REM BFCPEEMBEDDISPLAY=0
REM BFCPEEMBEDDELETE=1
REM BFCPEADMINEXE=0
REM BFCPEINVISEXE=1
REM BFCPEVERINCLUDE=1
REM BFCPEVERVERSION=1.0.0.0
REM BFCPEVERPRODUCT=KillSkype
REM BFCPEVERDESC=Stops Skype from running in the backgrou
REM BFCPEVERCOMPANY=None
REM BFCPEVERCOPYRIGHT=TimoHalofan
REM BFCPEOPTIONEND
@ECHO ON
TIMEOUT /T 60
taskkill /f /im skypeapp.exe
taskkill /f /im skypehost.exe
taskkill /f /im SkypeBackgroundHost.exe
taskkill /f /im SkypeBridge.exe
exit
