using System;

namespace Task3.CustomException
{
    public class TaskAlreadyExistsException : Exception
    {
        public TaskAlreadyExistsException() : base("The task already exists")
        {

        }
    }
}
