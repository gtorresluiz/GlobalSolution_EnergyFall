using GlobalSolution_EnergyFall.Services;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("⛔ Simulando queda de energia...");
        Thread.Sleep(2000); // Simula tempo offline

        Console.WriteLine("🔌 Energia restabelecida. Reiniciando servidor...\n");

        // Reinicia serviços simulados
        ServiceRestarter restarter = new();
        restarter.RestartAllServices();

        // Verifica integridade dos dados
        DataIntegrityChecker integrityChecker = new();
        integrityChecker.Check();

        // Gera alerta caso necessário
        AlertManager alertManager = new();
        alertManager.CheckForIssues();

        // Gera log final
        LogService.GenerateStatusReport(); 

        Console.WriteLine("\n✅ Sistema reiniciado com sucesso!");
    }
}
