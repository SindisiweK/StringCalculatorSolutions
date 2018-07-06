using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    [TestFixture]
    public class CalculatorTest
    {

        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        public void Add_GivenvalidInputSeparatedByComma_ShouldReturnSumOfAllInputNumbers(string input, int expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        [TestCase("1,2\n4", 7)]
        public void Add_GivenvalidInputOfUnkownNumbersWithNewLines_ShouldReturnSumOfAllInputNumbers(string input, int expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n1;2\n4", 7)]
        [TestCase("//;\n1;2,3", 6)]
        public void Add_GivenvalidInputWithDifferentDelimeters_ShouldReturnSumOfAllInputNumbers(string input, int expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var actual = sut.Add(input);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1", "Negative values are not allowed -1")]
        [TestCase("//-2;-4", "Negative values are not allowed -2,-4")]
        [TestCase("-1\n,-3", "Negative values are not allowed -1,-3")]
        public void Add_GivenAnInputWithNegativeNumbers_ShouldThrowExceptionMessage(string input, string expectedMessage)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var exception = Assert.Throws<Exception>(() => sut.Add(input));

            //Assert
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [TestCase("//;\n1003,3", 3)]
        [TestCase("//;\n1004;2\n4", 6)]
        [TestCase("//;\n1000;2,3", 1005)]
        public void Add_GivenAnInputWithNumbersGreaterThan1000_ShouldReturnSumOfNumberLessThan1000(string input, int expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var actual = sut.Add(input);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[***]\n1***2", 3)]
        [TestCase("//[***]\n1***1", 2)]
        public void Add_GivenvalidInputWithDelimiterInsideTheBrackets_ShouldReturnSumOfAllInputNumbers(string input, int expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var actual = sut.Add(input);


            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[*][%]\n2*4%6", 12)]
        [TestCase("//[*][%]\n3*6%9", 18)]
        public void Add_GivenvalidInputWithMultipleDelimeters_ShouldReturnSumOfAllInputNumbers(string input, int expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var actual = sut.Add(input);


            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//[^][$]\n1*2%3", 6)]
        [TestCase("//[#][!]\n2@4~6", 12)]
        [TestCase("//[&][%]\n3*6&9", 18)]
        public void Add_GivenvalidInputWithAnyKindOfDelimeters_ShouldReturnSumOfAllInputNumbers(string input, int expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var actual = sut.Add(input);


            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
    
}
