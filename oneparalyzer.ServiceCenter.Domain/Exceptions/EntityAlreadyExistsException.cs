

namespace oneparalyzer.ServiceCenter.Domain.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string msg) : base(msg) 
        {

        }
    }
}
