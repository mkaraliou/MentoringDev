using DictionaryReplacer;
using FluentAssertions;
using System.Collections;

namespace DictionaryReplacerTest
{
    public class DictionaryReplacerTests
    {
        private DictionaryReplacerClass class1 = new DictionaryReplacerClass();

        private static IEnumerable TestDataDictipnaryReplacerPositive()
        {
            yield return new TestCaseData("$temp$",
                new Dictionary<string, string>() { { "temp", "temporary" } },
                "temporary");

            yield return new TestCaseData("$temp$ here comes the name $name$",
                new Dictionary<string, string>() { { "temp", "temporary" }, { "name", "John Doe" } },
                "temporary here comes the name John Doe");

            yield return new TestCaseData("$Temp$ here comes the name $temp$ $name$",
                new Dictionary<string, string>() { { "temp", "temporary" }, { "name", "John Doe" } },
                "$Temp$ here comes the name temporary John Doe");

            yield return new TestCaseData("$temp$ here comes the name $temp$ $name$",
                new Dictionary<string, string>() { { "temp", "temporary" }, { "name1", "John Doe" } },
                "temporary here comes the name temporary $name$");

            yield return new TestCaseData("$temp here comes the name $temp$ $name$",
                new Dictionary<string, string>() { { "temp", "temporary" }, { "name1", "John Doe" } },
                "$temp here comes the name temporary $name$");

            yield return new TestCaseData("temp$ here comes the name $temp$ $name$",
                new Dictionary<string, string>() { { "temp", "temporary" }, { "name1", "John Doe" } },
                "temp$ here comes the name temporary $name$");

            yield return new TestCaseData(string.Empty,
                new Dictionary<string, string>() { },
                string.Empty);

            yield return new TestCaseData(string.Empty,
               new Dictionary<string, string>() { { "temp", "temporary" }, { "name1", "John Doe" } },
               string.Empty);

            yield return new TestCaseData("$$temp$$ here comes the name",
                new Dictionary<string, string>() { { "temp", "temporary" } },
                "$temporary$ here comes the name");

            yield return new TestCaseData("$sss $temp name$ sss$ here comes the name",
                new Dictionary<string, string>() { { "temp name", "temporary" }, { "temporary", "some" } },
                "some here comes the name");

            yield return new TestCaseData("$$temp$$ here comes the name",
                new Dictionary<string, string>() { { "temporary", "some" }, { "temp", "temporary" }  },
                "some here comes the name"); //?

            yield return new TestCaseData("$$temp$ here comes$ here comes the name",
                new Dictionary<string, string>() { { "temp", "temporary" }, { "temporary", "some" } },
                "$temporary here comes$ here comes the name");
        }

        private static IEnumerable TestDataDictipnaryReplacerNegative()
        {
            yield return new TestCaseData("$temp$",
                new Dictionary<string, string>() { { "temp", null } });

            yield return new TestCaseData(null,
                new Dictionary<string, string>() { { "temp", "temporary" } });

            yield return new TestCaseData("$temp$", null);
        }

        [TestCaseSource(nameof(TestDataDictipnaryReplacerPositive))]
        public void ReplaceFromDictionary_CorrectStringAndDictionary_ReturnsReplacedStringByUsingDictionary(string value, Dictionary<string, string> dictionary, string expected)
        {
            class1.ReplaceFromDictionary(value, dictionary).Should().Be(expected);
        }

        [TestCaseSource(nameof(TestDataDictipnaryReplacerNegative))]
        public void ReplaceFromDictionary_NullValueOrNullDictionary_ThrowsArgumentException(string value, Dictionary<string, string> dictionary)
        {
            Action act = () => class1.ReplaceFromDictionary(value, dictionary);

            act.Should().Throw<ArgumentException>();
        }
    }
}