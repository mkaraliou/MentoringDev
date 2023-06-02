using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private const char Minus = '-';
        private const char Plus = '+';
        private const char Zero = '0';

        private int _count;

        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException("String value should not be null or empty.");
            }

            stringValue = stringValue.TrimEnd();

            if (string.IsNullOrEmpty(stringValue))
            {
                throw new FormatException("String can't contain only spaces.");
            }

            int multiplier = 1;
            var firstCharacter = stringValue.First();

            if (firstCharacter == Minus)
            {
                multiplier = -1;
                stringValue = stringValue.Remove(0, 1);
            }

            if (firstCharacter == Plus)
            {
                stringValue = stringValue.Remove(0, 1);
            }

            _count = stringValue.Length;
            var intCollection = stringValue.Select(ch => CharTryToInt(ch)).ToList();
            if (_count > 10)
            {
                throw new OverflowException("Overflow.");
            }

            if (_count == 10)
            {
                return ParseStringWithTenCharacters(intCollection, multiplier);
            }

            return ParseCorrectInt(intCollection) * multiplier;
        }

        private int ParseStringWithTenCharacters(IEnumerable<int> intCollection, int multiplier)
        {
            var newCollection = intCollection.Take(_count - 1);

            var result = ((long)ParseCorrectInt(newCollection) * 10 + intCollection.ElementAt(_count - 1)) * multiplier;

            if (result > int.MaxValue || result < int.MinValue)
            {
                throw new OverflowException();
            }

            return (int)result;
        }

        private int ParseCorrectInt(IEnumerable<int> intCollection)
        {
            int result = 0;

            for (int power = intCollection.Count() - 1, index = 0; power >= 0; power--, index++)
            {
                result += (int)Math.Pow(10, power) * intCollection.ElementAt(index); 
            }

            return result;
        }

        private int CharTryToInt(char c)
        {
            int intValue = c - Zero;

            if (intValue > 9 || intValue < 0)
            {
                throw new FormatException("String value must contains only from numbers, '+' and '-'.");
            }

            return intValue;
        }
    }
}