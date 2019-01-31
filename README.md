# A program that stops Skype running in the background
Ever noticed how with the newest Windows updates Skype is showing up on the system tray?
Even if you disable it from showing up on the system tray it will keep running in the background
That's why I made this program to stop it from running

# Different versions
## .exe
Just a simple batch script converted to an silent .exe using [Bat To Exe Converter](http://www.f2ko.de/en/b2e.php).
## Batch
The batch script that was used for the .exe. If you wish to look at the code or don't want to run it as an .exe or want to compile it yourself this option is for you!
## C#
Was working on a C# version however this sadly doesn't work as of yet
### C# CMD
Runs it from a silent CMD window
### C# Batch
Runs it from a batch file

# Setup
This will show you how to enable/setup the program

## .exe
This .exe file will most likely show up as an virus. This however is because it's supposed to execute siliently so no popupes arise.
You might need to disable your browsers security to be able to download it and if you have any antivirus installed/Windows Defender you'll have to set it as a false positve/make the anti virus ignore it.

Once you have done that press ctrl + r and type shell:startup. This will take you to an folder which Windows will run programs out of on boot. The program will run around 60-80 seconds after boot before closing this is because it will take a while before Skype actually starts up. You can change this timer by downloading the batch file if you want too.
