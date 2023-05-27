using System;

namespace Task3.CustomException
{
    public class InvalidUserIdException : ArgumentOutOfRangeException
    {
        public InvalidUserIdException(string message) : base(message) { }
    }
}
