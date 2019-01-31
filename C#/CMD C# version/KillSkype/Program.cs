using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace KillSkype
{
    class Program
    {
        public static string DPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\KillSkype";
        public static string FilePath = $@"{DPath}\KillSkype.bat";
        public static string Logs = $@"{DPath}\logs.txt";

        static void Main(string[] args)
        {
                try
                {
                    if (!Directory.Exists($"{DPath}")) { Directory.CreateDirectory(DPath); }
                    else if (File.Exists(Logs)) { File.WriteAllText(Logs, ""); }
                    KillSkypeProcess().Wait();
                }
                catch (Exception ex)
                {
                    TextWriter LogsWriter = new StreamWriter(Logs, true);
                    LogsWriter.WriteLine($"There was an exception: {ex.ToString()}");
                }
        }

        static private async Task KillSkypeProcess()
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(60));

                StringBuilder CMDCommands = new StringBuilder();
                CMDCommands.AppendLine("Taskkill /IM skypeapp.exe /F");
                CMDCommands.AppendLine("Taskkill /IM skypehost.exe /F");
                CMDCommands.AppendLine("Taskkill /IM SkypeBackgroundHost.exe /F");
                CMDCommands.AppendLine("Taskkill /IM SkypeBackgroundHost.exe /F");

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                //Enable this (the line above) again if you want it to run silently
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C" + CMDCommands; //FilePath
                process.StartInfo = startInfo;
                process.Start();

                await Task.Delay(1); //This is just to ensure all previous tasks finish 

            }
            catch (Exception e)
            {
                TextWriter LogsWriter = new StreamWriter(Logs, true);
                LogsWriter.WriteLine($"There was an exception: {e.ToString()}");
            }
            finally { Environment.Exit(0); }
        }
    }
}
