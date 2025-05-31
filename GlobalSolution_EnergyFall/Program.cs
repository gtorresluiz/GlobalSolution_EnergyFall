using GlobalSolution_EnergyFall.Auth;
using GlobalSolution_EnergyFall.Log;
using System;
using System.Threading;

namespace GlobalSolution_EnergyFall
{
    class Program
    {
        static void Main()
        {
            int userCountBefore = AuthService.GetUserCount();
            bool authenticated = false;
            string loggedUserName = "";

            while (!authenticated)
            {
                Console.WriteLine("\n1 - Login");
                Console.WriteLine("2 - Cadastro");
                Console.Write("Escolha uma opção: ");

                string optionInput = Console.ReadLine();
                int option;

                try
                {
                    if (!int.TryParse(optionInput, out option))
                        throw new FormatException("Entrada inválida. Digite apenas números (1 ou 2).");

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Senha: ");
                    string password = Console.ReadLine();

                    switch (option)
                    {
                        case 1:
                            authenticated = AuthService.Login(email, password);
                            if (authenticated)
                            {
                                loggedUserName = AuthService.GetUserName(email);
                                LogService.Log("Login realizado com sucesso.", loggedUserName);
                            }
                            break;

                        case 2:
                            Console.Write("Nome: ");
                            string name = Console.ReadLine();
                            bool registered = AuthService.Register(name, email, password);
                            if (registered)
                            {
                                LogService.Log("Usuário cadastrado com sucesso.", name);
                            }
                            break;

                        default:
                            Console.WriteLine("Opção inválida. Escolha 1 ou 2.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                    LogService.Log("Erro de entrada: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro inesperado.");
                    LogService.Log("Erro inesperado: " + ex.Message);
                }
            }

            // 🔌 Simula queda de energia
            Console.WriteLine("\n---  QUEDA DE ENERGIA SIMULADA ---");
            LogService.Log(" Simulação de queda de energia iniciada.", loggedUserName);

            SimularQuedaDeEnergia(userCountBefore, loggedUserName);
        }

        static void SimularQuedaDeEnergia(int usuariosAntes, string usuario)
        {
            Console.WriteLine("\nReinicializando o sistema...");
            Thread.Sleep(2000);

            int usuariosDepois = AuthService.GetUserCount();
            var logs = LogService.ReadLogs();

            Console.WriteLine("\n---  Diagnóstico pós-queda ---");
            Console.WriteLine($"Usuários antes da queda: {usuariosAntes}");
            Console.WriteLine($"Usuários após a queda:  {usuariosDepois}");

            if (usuariosDepois < usuariosAntes)
                Console.WriteLine("  Perda de dados detectada!");
            else
                Console.WriteLine(" Nenhuma perda de dados identificada.");

            Console.WriteLine("\n---  Últimos logs registrados ---");
            foreach (var log in logs.TakeLast(5))
                Console.WriteLine(log);

            LogService.Log("Diagnóstico pós-falha concluído.", usuario);

            Console.WriteLine("\nSistema finalizado com sucesso.\n");
            Environment.Exit(0);
        }
    }
}
