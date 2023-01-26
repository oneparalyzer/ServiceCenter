

namespace oneparalyzer.ServiceCenter.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public List<User> Users { get; set; }

        public Role(string title)
        {
            Title = title;
        }
    }
}
