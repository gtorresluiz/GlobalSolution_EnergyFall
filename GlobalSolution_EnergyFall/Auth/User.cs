namespace GlobalSolution_EnergyFall.Auth
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        
        public override string ToString()
        {
            return $"{Name};{Email};{Password}";
        }

        public static User FromString(string line)
        {
            var parts = line.Split(';');
            return new User(parts[0], parts[1], parts[2]);
        }
    }
}
