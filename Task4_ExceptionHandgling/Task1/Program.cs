using System;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                // TODO: Implement the task here.
                if (args == null || args.Count() == 0)
                {
                    throw new ArgumentException("Args count should be more than 0.");
                }

                foreach (var arg in args)
                {
                    try
                    {
                        Console.WriteLine(GetFirstCharacter(arg));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine($"Exception 1: {e.Message}");
                    }
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine($"Exception 2: {e.Message}");
            }
        }

        private static char GetFirstCharacter(string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                throw new ArgumentException("Each line in args should not be null or empty.");
            }

            return stringValue.First();
        }
    }
}