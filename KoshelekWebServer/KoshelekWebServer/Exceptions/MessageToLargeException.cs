namespace KoshelekWebServer.Exceptions
{
    public class MessageToLargeException : Exception
    {
        public MessageToLargeException() { }
        public MessageToLargeException(string message)
            : base(message) { }
    }
}