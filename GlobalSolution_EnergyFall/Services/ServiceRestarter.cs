namespace GlobalSolution_EnergyFall.Services
{
    public class ServiceRestarter
    {
        private List<string> services = new() { "Banco de Dados", "API de Autenticação", "Serviço de Email" };

        public void RestartAllServices()
        {
            foreach (var service in services)
            {
                try
                {
                    Console.WriteLine($"🔄 Reiniciando {service}...");
                    Thread.Sleep(1000); // Simula tempo de reinício
                    Console.WriteLine($"✅ {service} reiniciado.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Falha ao reiniciar {service}: {ex.Message}");
                }
            }
        }
    }
}
