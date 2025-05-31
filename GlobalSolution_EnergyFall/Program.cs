using GlobalSolution_EnergyFall.Services;
using GlobalSolution_EnergyFall.Auth;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Simulando queda de energia...");
        Thread.Sleep(2500); // Simula tempo offline

        bool authenticated = false;

        while (!authenticated)
        {
            Console.WriteLine("Bem-vindo ao Sistema de Energia");
            Console.WriteLine("1 - Login");
            Console.WriteLine("2 - Cadastro");
            Console.Write("Escolha uma opção: ");
            string option = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Senha: ");
            string password = Console.ReadLine();

            switch (option)
            {
                case "1":
                    authenticated = AuthService.Login(email, password);
                    break;
                case "2":
                    Console.Write("Nome: ");
                    string name = Console.ReadLine();
                    AuthService.Register(name, email, password);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        Console.WriteLine("Energia restabelecida. Reiniciando servidor...\n");

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

        Console.WriteLine("\nSistema reiniciado com sucesso!");
    }
}
