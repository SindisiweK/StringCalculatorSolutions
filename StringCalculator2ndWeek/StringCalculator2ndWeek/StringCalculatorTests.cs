using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculator2ndWeek
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenAnInvalidInput_ShouldReturn0(string input)
        {
            {
                //Arrange
                var expected = 0;
                var sut = new StringCalculator();

                //Act
                var actual = sut.Add(input);

                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestCase("1",1)]
        [TestCase("1,2",3)]
        [TestCase("1,2,3",6)]
        public void Add_GivenInputOfCommaSeparatedNumbers_ShouldReturnSumOfAllNumeralNNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("1\n1", 2)]
        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        public void Add_GivenInputOfNewlineSeparatedNumbers_ShouldReturnSumOfAllNumeralNNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//;\n1,1", 2)]
        [TestCase("//;1\n2", 3)]
        [TestCase("//1\n2;3", 6)]
        public void Add_GivenInputOfNumbersThatSupportDifferentDelimeters_ShouldReturnSumOfAllNumeralNNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("-1\n-1")]
        [TestCase("-1\n-2")]
        [TestCase("-1\n-2,-3")]
        public void Add_GivenInputOfNegativeNumbers_ShouldThrowAnExceptionMessage(string input)
        {
            //Arrange
            var expected = "Negatives are not allowed" + input;
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }
        [TestCase("//;\n1000,0", 1000)]
        [TestCase("//;1000\n2", 1002)]
        [TestCase("//1000\n2;3", 1005)]
        public void Add_GivenInputOfNumbersGreaterThan1000_ShouldIgnoreTheGreaterNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[***]\n1***3***6", 10)]
        [TestCase("//[***]\n5***10***20", 35)]
        public void Add_GivenInputOfNumbersThatSupportDelimetersWithSquareBrackets_ShouldReturnSumOfAllNumeralNNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//{%%%}\n1", 1)]
        [TestCase("//(~~~)\n1^^^2", 3)]
        [TestCase("//|###|\n1!!!2$$$3", 6)]
        public void Add_GivenValidInputContainMultipleDelimeters_ShouldSumofAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
