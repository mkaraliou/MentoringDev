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
        public void SomeM_PositiveFirstAndLast_ReturnsStringArray(int first, int last, IEnumerable<string> result)
        {
            class1.SomeM(first, last).Should().BeEquivalentTo(result);
        }

        [Test]
        public void SomeM_NegativeFirstAndPositiveLast_ThrowsArgumentOutOfRangeException()
        {
            Action act = () => class1.SomeM(-5, 7).ToList();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [TestCase(10, 0)]
        [TestCase(5, -7)]
        public void SomeM_LastMoreFirst_ThrowsArgumentException(int first, int last)
        {
            Action act = () => class1.SomeM(first, last).ToList();

            act.Should().Throw<ArgumentException>();
        }
    }
}