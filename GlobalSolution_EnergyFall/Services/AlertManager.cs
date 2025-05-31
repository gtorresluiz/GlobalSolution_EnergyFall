using GlobalSolution_EnergyFall.Log;

namespace GlobalSolution_EnergyFall.Alert
{
    public static class AlertManager
    {
        public static void ShowLastLogs()
        {
            var logs = LogService.ReadLogs();

            Console.WriteLine("\n--- Últimos Logs ---");
            foreach (var log in logs.TakeLast(10))
            {
                Console.WriteLine(log);
            }
        }
    }
}
