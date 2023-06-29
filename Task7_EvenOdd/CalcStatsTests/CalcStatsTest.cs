using CalcStats;
using FluentAssertions;

namespace CalcStatsTests
{
    public class CalcStatsTest
    {
        private CalcStatsClass class1 = new CalcStatsClass();

        [TestCase(new int[] { 6, 9, 15, -2, 92, 11 }, "min = -2, max = 92, length = 6, average = 21.83")]
        [TestCase(new int[] { 0 }, "min = 0, max = 0, length = 1, average = 0")]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1}, "min = 1, max = 1, length = 6, average = 1")]
        [TestCase(new int[] { 15, 20, 35, 20, 15, 35, 16 }, "min = 15, max = 35, length = 7, average = 22.29")]
        [TestCase(new int[] { 35, 20, 15, 5, 0 }, "min = 0, max = 35, length = 5, average = 15")]
        [TestCase(new int[] { -5, 5, 15, 20, 35 }, "min = -5, max = 35, length = 5, average = 14")]
        [TestCase(new int[] { -5, -4, -3, -2, -1 }, "min = -5, max = -1, length = 5, average = -3")]
        public void Test1(int[] array, string result)
        {
            class1.GetStats(array).Should().Be(result); 
        }

        [TestCase(new int[] { })]
        [TestCase(null)]
        public void Test2_Negative(int[] array)
        {
            Action act = () => class1.GetStats(array);

            act.Should().Throw<ArgumentException>();
        }
    }
}