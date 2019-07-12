using System.Net;

namespace System
{
    public class ArgumentCustomException : BaseCustomException
    {
        public ArgumentCustomException(string message, string description) : base(message, description, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}