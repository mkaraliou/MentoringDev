using System;

namespace Task3.CustomException
{
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException() : base("Invalid userId") { }
    }
}
