using FluentAssertions;
using Task7_EvenOdd;

namespace EvenOddTests
{
    public class Tests
    {
        Class1 class1 = new Class1();

        [TestCase(5,7, new string[] { "5", "even", "7" })]
        [TestCase(0,4, new string[] { "0", "1", "2", "3", "even" })]
        [TestCase(7, 10, new string[] { "7", "even", "odd", "even" })]
        [TestCase(107, 113, new string[] { "107", "even", "109", "even", "odd", "even", "113" })]
        [TestCase(100, 100, new string[] { "even" })]
        [TestCase(153, 153, new string[] { "odd" })]
        [TestCase(599, 599, new string[] { "599" })]
        public void Test1_Positive(int first, int last, IEnumerable<string> result)
        {
            var k = class1.SomeM(first, last).ToList();
            class1.SomeM(first, last).Should().BeEquivalentTo(result);
        }

        public void Test_NegativeNumbers()
        {
            Action act = () => class1.SomeM(-5, 7);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCase(10, 0)]
        [TestCase(5, -7)]
        public void Test_FirstLessThenLast(int first, int last)
        {
            Action act = () => class1.SomeM(first, last);

            act.Should().Throw<ArgumentException>();
        }
    }
}