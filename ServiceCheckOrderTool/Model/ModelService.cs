using System;
using System.Diagnostics;
using System.IO;

namespace ServiceCheckOrderTool.Model
{
    class ModelService
    {
        public static void WriteLogError(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString("g") + ": " + ex.Source + "; " + ex.Message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
                // ignored
            }
        }
        public static void WriteLogError(string message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString("g") + ": " + message);
                sw.Flush();
                sw.Close();
            }
            catch
            {
                // ignored
            }
        }
        public static void OpenTool(string path)
        {
            Process process = new Process();
            process.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + $"{path}" + ".exe";
            process.Start();
        }
    }
}
