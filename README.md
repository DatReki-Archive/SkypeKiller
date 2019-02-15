# A program that stops Skype running in the background
Ever noticed how with the newest Windows updates Skype is showing up on the system tray?
Even if you disable it from showing up on the system tray it will keep running in the background
That's why I made this program to stop it from running.

Too sum it up this program needs to start as an start up program with Windows after which it'll wait 60 seconds then it will close down Skype related processes soon after that the program will shut itself down. "RuntimeBroker.exe" might keep running for a little while but that too should shut down a little later. **This isn't the best or a good permanent solution** but it's an solution none the less.

# Different versions
## Batch
The batch script that was used for the .exe. If you wish to look at the code or don't want to run it as an .exe or want to compile it yourself this option is for you!
## C#
Was working on a C# version however this sadly **doesn't work** as of yet
### C# CMD
Runs it from a silent CMD window
### C# Batch
Runs it from a batch file

# Setup
This will show you how to enable/setup the program

### Batch to .exe
Download the batch script and download and install [Bat To Exe Converter](http://www.f2ko.de/en/b2e.php) or any other batch to .exe converter you might want to use. After you converted it you should be able to just drop it into the start up folder using **shell:startup** and it should stop Skype around 60/80 seconds after the PC booted into Windows.
