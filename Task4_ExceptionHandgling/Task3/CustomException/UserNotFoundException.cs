using System;

namespace Task3.CustomException
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found") { }
    }
}
