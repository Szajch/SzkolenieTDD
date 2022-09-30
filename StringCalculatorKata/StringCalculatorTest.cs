using System;
using StringCalculator;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTest
    {
        [Theory]
        [Trait("Traktowanie null'a i pustego stringa jako zero", "Testy kalkulatora")]
        [InlineData("")]
        [InlineData(null)]
        public void AddReturnZeroWhenSuppliedEmptyOrNullString(string numbers)
        {
            var result = StringCalculator.Add(numbers);
            Assert.Equal(0, result);
        }

        [Theory]
        [Trait("Dodawanie pojedynczej liczby", "Testy kalkulatora")]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("3", 3)]
        public void AddReturnNumberWhenSuppliedSingleNumberInString(string number, int expectedResult)
        {
            var result = StringCalculator.Add(number);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [Trait("Dodawanie z enterem jako rozdzielaczem", "Testy kalkulatora")]
        [InlineData("1,2,3", 6)]
        [InlineData("3\n2", 5)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2\n3,4,5", 15)]
        public void AddReturnSumWhenSuppliedNumbersInStringWithNewLineAsDelimiter(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [Trait("Dodawanie wielu liczb", "Testy kalkulatora")]
        [InlineData("0,1", 1)]
        [InlineData("0,1,1", 2)]
        [InlineData("0,2", 2)]
        [InlineData("0,2,2", 4)]
        [InlineData("0,3", 3)]
        [InlineData("0,3,2", 5)]
        [InlineData("0,3,3", 6)]
        public void AddReturnSumWhenSuppliedMultipleNumbersInString(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [Trait("Ignorowanie liczb powy¿ej 1000", "Testy kalkulatora")]
        [InlineData("0,3,1001", 3)]
        [InlineData("0,3,1000", 1003)]
        public void AddReturnSumByIgnoringMoreThanThousandWhenSuppliedMultipleNumbersInString(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [Trait("Alternatywne rozdzielacze", "Testy kalkulatora")]
        [InlineData("//*\n1*2", 3)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//;\n1;2;3;4;5;6;7;8;9;10", 55)]
        public void AddWhenGivenDefinedDelimiterUsesThatDelimiter(string input, int expectation)
        {
            var result = StringCalculator.Add(input);
            Assert.Equal(expectation, result);
        }

        [Theory]
        [Trait("Wyrzucenie warunku dla ujemnych liczb", "Testy kalkulatora")]
        [InlineData("1,-1")]
        public void ThrowArgumentException(string numbers)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.Add(numbers));
        }
    }

}
