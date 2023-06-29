namespace CalcStats
{
    public class CalcStatsClass
    {
        public string GetStats(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException();
            }

            int min = array[0], max = array[0], sum = 0;
            double average;

            int length = array.Length;

            foreach(var i in array)
            {
                if (i < min)
                {
                    min = i;
                }

                if (i > max)
                {
                    max = i;
                }

                sum += i;
            }

            average = sum / (double)length;

            return $"min = {min}, max = {max}, length = {length}, average = {(average == 0 ? 0 : average.ToString("#.##"))}";
        }
    }
}