using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTest
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
            Assert.AreEqual(expected,actual);
        }
        [TestCase("1",1)]
        [TestCase("1,2",3)]
        [TestCase("1,2,3",6)]
        public void Add_GivenValidInputofCommmaSeparated_ShouldSumofAllNumbers(string input, int expected)
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
        [TestCase("1\n2\n3", 6)]
        public void Add_GivenValidInputWithNewLines_ShouldSumofAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//;1\n1", 2)]
        [TestCase("//;1\n2", 3)]
        [TestCase("//;1\n2;3", 6)]
        public void Add_GivenValidInputofWithSeparatelineCustomDelimeter_ShouldSumofAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("-1")]
        [TestCase("-1;-2")]
        [TestCase("-1;-2;-3")]
        public void Add_GivenNeagativeNumbersAsInput_ShouldThrowAnExceptionMessage(string input)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //Assert
            var expected = "Negatives are not allowed" + input;
            Assert.AreEqual(expected, actual.Message);
        }
        [TestCase("//;1000", 1000)]
        [TestCase("//;1000\n2", 1002)]
        [TestCase("//;1000\n2;3", 1005)]
        public void Add_GivenValidInputOfNumbersGreaterThan1000_ShouldReturnSumOfNumbersLessThan1000(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//[***]\n1", 1)]
        [TestCase("//[***]\n1***2", 3)]
        [TestCase("//[***]\n1***2***3", 6)]
        public void Add_GivenValidInputContainSquareBracketsDelimeter_ShouldSumofAllNumbers(string input, int expected)
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
