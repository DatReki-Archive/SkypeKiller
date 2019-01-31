using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SkypeKillerBatch
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
                MakeSkypeKiller().Wait();
                KillSkypeProcess().Wait();
            }
            catch (Exception ex)
            {
                TextWriter LogsWriter = new StreamWriter(Logs, true);
                LogsWriter.WriteLine($"There was an exception: {ex.ToString()}");
            }
        }

        static private async Task MakeSkypeKiller()
        {
            StringBuilder BatchWriter = new StringBuilder();
            BatchWriter.AppendLine("SETCONSOLE /minimize");
            BatchWriter.AppendLine("taskkill /f /im skypeapp.exe");
            BatchWriter.AppendLine("taskkill /f /im skypehost.exe");
            BatchWriter.AppendLine("taskkill /f /im SkypeBackgroundHost.exe");
            BatchWriter.AppendLine("taskkill /f /im SkypeBridge.exe");

            if (!File.Exists(FilePath))
            {
                using (var tw = new StreamWriter(FilePath, true))
                {
                    tw.WriteLine(BatchWriter);
                }
            }
            await Task.Delay(1); //This is just to ensure all previous tasks finish
        }

        static private async Task KillSkypeProcess()
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(60));

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C" + FilePath;
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
