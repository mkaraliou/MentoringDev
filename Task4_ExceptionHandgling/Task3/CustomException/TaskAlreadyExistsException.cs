using System;

namespace Task3.CustomException
{
    public class TaskAlreadyExistsException : Exception
    {
        public TaskAlreadyExistsException() : base("User have the same task.")
        {

        }


        public TaskAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
