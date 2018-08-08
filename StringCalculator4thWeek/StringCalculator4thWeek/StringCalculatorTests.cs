using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace StringCalculator4thWeek
{   [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenInvalidInput_ShouldReturnZero(string input)
        {
            //Arrange
            var expected = 0;
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        public void Add_GivenInputOfNumbersWithACommaSeparation_ShouldReturnSumOfAllNumber(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase("1\n1", 2)]
        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        public void Add_GivenInputOfNumbersWithNewLines_ShouldReturnSumOfAllNumber(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;1;1", 2)]
        [TestCase("//;1;2", 3)]
        [TestCase("//;1\n2;3", 6)]
        public void Add_GivenInputOfNumbersWithBackSlashesDelimeter_ShouldReturnSumOfAllNumber(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;-1;-1")]
        [TestCase("//;-1;-2")]
        [TestCase("//;-1\n-2;-3")]
        public void Add_GivenInputOfNegativeNumbers_ShouldThrowsAnExceptionMessage(string input)
        {
            //Arrange
            var expected = "Negative values are not allowed" + input;
            var sut = new StringCalculator();
            //Act
            var actual = Assert.Throws<Exception>(()=>sut.Add(input));
            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("//;1001;1", 1)]
        [TestCase("//;1002;2", 2)]
        [TestCase("//;1100\n2;3", 5)]
        public void Add_GivenInputOfNumbersGreaterThan1000_ShouldReturnSumOfLesserNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1", 1)]
        [TestCase("//[***]\n1***2***", 3)]
        [TestCase("//[***]\n1***2***3", 6)]
        public void Add_GivenInputOfNumbersWithDifferentTypesOfDelimeters_ShouldReturnSumOfAllNumber(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//|<>|\n1", 1)]
        [TestCase("//(^){#}\n1!?~2`@:", 3)]
        [TestCase("//[*][%]\n1*2&3", 6)]
        public void Add_GivenInputOfNumbersWithDifferentTypesOfAnyDelimeters_ShouldReturnSumOfAllNumber(string input, int expected)
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
