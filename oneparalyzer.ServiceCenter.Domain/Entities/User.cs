

namespace oneparalyzer.ServiceCenter.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Login { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Surname { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }

        public User(string login, string firstName, string lastName, string surname, string password, Role role)
        {
            Role = role;
        }

        private User(string login, string firstName, string lastName, string surname, string password)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            Surname = surname;
            Password = password;
        }
    }
}
