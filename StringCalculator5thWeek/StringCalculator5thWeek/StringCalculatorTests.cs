using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculator5thWeek
{
    [TestFixture]
   public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenInvalidInputOfEmptyString_ShouldReturnZero(string input)
        {
            //Arrange
            var expected = 0;
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase("1",1)]
        [TestCase("1,2",3)]
        [TestCase("10,20,30",60)]
        public void Add_GivenInputOfCommaSeparatedNumbers_ShouldReturnTheSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;1\n3;7", 11)]
        [TestCase("//;1\n27", 28)]
        [TestCase("//;10\n20,30;45", 105)]
        public void Add_GivenInputOfNumbersThatSupportDifferentDelimeters_ShouldReturnTheSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;-1\n-3;-7")]
        [TestCase("//;-1\n-27")]
        [TestCase("//;-10\n-20,-30;-45")]
        public void Add_GivenInputOfNegativeValues_ShouldReturnExceptionMessage(string input)
        {
            //Arrange
            var expected = "Negative values are forbiden" + input;
            var sut = new StringCalculator();
            //Act
            var actual =Assert.Throws<Exception>(()=> sut.Add(input));
            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("//;1001\n3;7", 10)]
        [TestCase("//;1020\n27", 27)]
        [TestCase("//;1222\n20,30;45", 95)]
        public void Add_GivenInputOfNumbersThatAreGreaterThan1000_ShouldReturnTheSumOfAllNumbersThatAreLesserThan1000(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase("//;[***]\n1***3", 4)]
        [TestCase("//;[***]\n100***56***", 156)]
        [TestCase("//;[***]\n32***62***92", 186)]
        public void Add_GivenInputOfNumbersWithDifferentTypesOfDelimeters_ShouldReturnSumOfAllNumber(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;|<>|\n1", 1)]
        [TestCase("//;(^){#}\n1!?~2`@:", 3)]
        [TestCase("//;[*][%]\n1*2&3", 6)]
        public void Add_GivenInputOfNumbersWithDifferentTypesOfAnyDelimeters_ShouldReturnSumOfAllNumber(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//;|<>|(!)\n1<19", 20)]
        [TestCase("//;(^){#}\n1!?~2`@:", 3)]
        [TestCase("//;[*][%][?]\n1*2&3", 6)]
        public void Add_GivenInputOfNumbersWithDifferentTypesOfAnyDelimetersWithAnyAmountOfNumbers_ShouldReturnSumOfAllNumber(string input, int expected)
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
