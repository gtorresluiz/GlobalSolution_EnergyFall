namespace GlobalSolution_EnergyFall.Services
{
    public static class LogService
    {
        private static readonly string logFile = "eventlog.txt";

        public static void Log(string message)
        {
            string logEntry = $" {DateTime.Now}: {message}";
            File.AppendAllText(logFile, logEntry + Environment.NewLine);
        }

        public static List<string> ReadLogs()
        {
            return File.Exists(logFile)
                ? File.ReadAllLines(logFile).ToList()
                : new List<string>();
        }

        public static void GenerateStatusReport()
        {
            Console.WriteLine("\n Relatório de status final:");
            var logs = ReadLogs();
            foreach (var line in logs)
            {
                Console.WriteLine(line);
            }
        }
    }
}
