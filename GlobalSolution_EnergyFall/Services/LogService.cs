using System;

namespace GlobalSolution_EnergyFall.Log
{
    public static class LogService
    {
        private static readonly string logPath = "log.txt";

        public static void Log(string message, string userName = "Sistema")
        {
            string entry = $"[{DateTime.Now}] [{userName}] {message}";
            File.AppendAllText(logPath, entry + Environment.NewLine);
        }

        public static List<string> ReadLogs()
        {
            if (!File.Exists(logPath))
                return new List<string>();

            return File.ReadAllLines(logPath).ToList();
        }
    }
}
