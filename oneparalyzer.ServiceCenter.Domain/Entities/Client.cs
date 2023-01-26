

namespace oneparalyzer.ServiceCenter.Domain.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; } 
        public string LastName { get; private set; } 
        public string Surname { get; private set; } 
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public List<Order> Orders { get; set; }

        public Client(string firstName, string lastName, string surname, string phoneNumber, string email = "Не указан")
        {
            FirstName = firstName;
            LastName = lastName;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Email = email;
            Orders = new List<Order>();  
        }
    }
}
