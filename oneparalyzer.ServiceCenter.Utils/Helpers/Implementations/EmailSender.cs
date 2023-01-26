using oneparalyzer.ServiceCenter.Utils.Helpers.Interfaces;


namespace oneparalyzer.ServiceCenter.Utils.Helpers.Implementations
{
    public class EmailSender : ISend
    {
        private readonly string _message;
        private readonly string _email;

        public EmailSender(string message, string email)
        {
            _message = message;
            _email = email;
        }

        public void Send()
        {
            throw new NotImplementedException();
        }
    }
}
