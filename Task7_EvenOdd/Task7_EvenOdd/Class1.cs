namespace Task7_EvenOdd
{
    public class Class1
    {
        public IEnumerable<string> SomeM(int first, int last)
        {
            if (first < 0)
            {
                throw new ArgumentOutOfRangeException("First number should be nonnegative.");
            }

            if (last < first)
            {
                throw new ArgumentException("Last number should be more then first.");
            }

            for (int i = first; i <= last; i++)
            {
                yield return TransformToEvenOdd(i);
            }

            //var result = new List<string>();

            //for (int i = first; i <= last; i++)
            //{
            //    result.Add(TransformToEvenOdd(i));
            //}

            //return result;
        }

        private string TransformToEvenOdd(int number)
        {
            if (number < 3) return number.ToString();
            if (number % 2 == 0) return "even";

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return "odd";

            return number.ToString();
        }
    }
}
