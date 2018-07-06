using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculatorFourth
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenEmptyOrNullInput_ShouldReturnSumOfZero(string input )
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
        [TestCase("1,2,3",6)]
        public void Add_GivenInputOfCommaSeparetedNumbers_ShouldReturnSumOfAllInput(string input ,int expected)
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
        public void Add_GivenInputOfCommaSeparetedNumbersAddedNewLines_ShouldReturnSumOfAllInput(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n1;2;3", 6)]
        [TestCase("//;\n1;2,4", 7)]
        public void Add_GivenInputOfNumbersThatContainSeparateLineCustomDelimeter_ShouldReturnSumOfAllInput(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("-1")]
        [TestCase("-1,-2")]
        [TestCase("-1,-2,-3")]
        public void Add_GivenInputOfNegativeNumbers_ShouldReturnSumOfAllInput(string input)
        {
            //Arrange
            var expected = "Negatives are forbbiden" + input;

            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(()=>sut.Add(input));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }
        [TestCase("//;\n1000;1", 1001)]
        [TestCase("//;\n1000;2;3", 1005)]
        [TestCase("//;\n1000;2,4", 1006)]
        public void Add_GivenInputOfNumbersGreaterThan1000_ShouldReturnSumOfNumbersLessThanOrEqualTo1000(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[***]\n1***4***5", 10)]
        [TestCase("//[***]\n1***", 1)]
        public void Add_GivenInputOfNumbersWithAnyLengthOfDelimeter_ShouldReturnSumOfNumbersLessThanOrEqualTo1000(string input, int expected)
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
