using GlobalSolution_EnergyFall.Services;

namespace GlobalSolution_EnergyFall.Services
{
    public class AlertManager
    {
        public void CheckForIssues()
        {
            Console.WriteLine("\n🔔 Verificando necessidade de alertas...");

            // Simula um alerta caso algum log contenha "corrupção"
            var logs = LogService.ReadLogs();
            if (logs.Any(log => log.Contains("Corrupção")))
            {
                Console.WriteLine("🚨 ALERTA: Corrupção de dados detectada!");
                LogService.Log("Alerta gerado: Corrupção de dados.");
            }
            else
            {
                Console.WriteLine("✅ Nenhum alerta necessário.");
            }
        }
    }
}
