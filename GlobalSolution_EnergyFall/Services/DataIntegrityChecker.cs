using GlobalSolution_EnergyFall.Services;

namespace GlobalSolution_EnergyFall.Services
{
    public class DataIntegrityChecker
    {
        public void Check()
        {
            Console.WriteLine("\n Verificando integridade dos dados...");

            try
            {
                // Simulação simples
                Random rand = new();
                bool hasCorruption = rand.Next(0, 2) == 1;

                if (hasCorruption)
                {
                    Console.WriteLine(" Arquivos corrompidos detectados!");
                    LogService.Log(" Corrupção detectada em arquivos críticos.");
                }
                else
                {
                    Console.WriteLine(" Todos os dados estão íntegros.");
                    LogService.Log(" Nenhuma corrupção detectada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Erro ao verificar integridade: {ex.Message}");
            }
        }
    }
}
