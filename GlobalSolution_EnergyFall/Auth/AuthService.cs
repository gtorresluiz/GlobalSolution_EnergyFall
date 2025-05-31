using System.Text.RegularExpressions;

namespace GlobalSolution_EnergyFall.Auth
{
    public static class AuthService
    {
        private static List<User> users = new();

        public static bool Register(string name, string email, string password)
        {
            if (!IsValidEmail(email))
            {
                Console.WriteLine(" Email inválido.");
                return false;
            }

            if (!IsValidPassword(password))
            {
                Console.WriteLine(" A senha deve conter letras e números.");
                return false;
            }

            if (users.Any(u => u.Email == email))
            {
                Console.WriteLine(" Já existe um usuário com esse email.");
                return false;
            }

            users.Add(new User(name, email, password));
            Console.WriteLine(" Cadastro realizado com sucesso!");
            return true;
        }

        public static bool Login(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                Console.WriteLine(" Email ou senha incorretos.");
                return false;
            }

            Console.WriteLine($" Bem-vindo(a), {user.Name}!");
            return true;
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private static bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d).+$");
        }
    }
}
