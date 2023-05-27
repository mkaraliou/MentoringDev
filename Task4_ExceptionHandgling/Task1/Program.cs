using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Implement the task here.
            if (args == null || args.Count() == 0)
            {
                throw new ArgumentException("Args count should be more than 0.");
            }

            foreach (var arg in args) 
            {
                if (string.IsNullOrEmpty(arg))
                {
                    throw new ArgumentException("Each line in args should not be null or empty.");
                }

                Console.WriteLine($"\"{arg.First()}\"");
            }
        }
    }
}