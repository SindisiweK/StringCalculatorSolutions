using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator5th2nd
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenInvalidInputOfEmptyStrings_ShouldReturnZero(string input)
        {
            //Arrange
            var expected = 0;
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase("10",10)]
        [TestCase("10,20",30)]
        [TestCase("10,20,30",60)]
        public void Add_GivenInputOfNumbersThatAreCommaseparated_ShouldReturnTheSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("10\n100", 110)]
        [TestCase("10,20\n200", 230)]
        [TestCase("10\n20,30", 60)]
        public void Add_GivenInputOfNumbersThatAreSeparatedByNewLine_ShouldReturnTheSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;10\n100", 110)]
        [TestCase("//;10,20\n200", 230)]
        [TestCase("//;10\n20,30", 60)]
        public void Add_GivenInputOfNumbersThatAreSeparatedByNewLineAndSupportDifferentDelimeterofSlashes_ShouldReturnTheSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;-10\n-100")]
        [TestCase("//;-10,-20\n-200")]
        [TestCase("//;-10\n-20,-30")]
        public void Add_GivenInputOfnegativeNumbers_ShouldThrowAnExceptionMessage(string input)
        {
            //Arrange
            var expected = "Negative values are restricted" + input;
            var sut = new StringCalculator();
            //Act
            var actual = Assert.Throws<Exception>(()=>sut.Add(input));
            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("//;3050\n1000", 1000)]
        [TestCase("//;2500;10,20\n200", 230)]
        [TestCase("//;1006;10\n20,30", 60)]
        public void Add_GivenInputOfNumbersThatAreGreaterThan1000_ShouldReturnTheSumOfAllNumbersThatAreLessThan1000(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;[***]10\n100", 110)]
        [TestCase("//;[***]10***20***200***", 230)]
        [TestCase("//;[***]10\n20***30", 60)]
        public void Add_GivenInputOfNumbersThatAreSeparatedByNewLineAndSupportDifferentDelimetersIncludingBrackets_ShouldReturnTheSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;{&$^}10\n100", 110)]
        [TestCase("//;(:?!)10%@~20<#>200...", 230)]
        [TestCase("//;|```|10\n20___30^^^", 60)]
        public void Add_GivenInputOfNumbersThatAreSeparatedByNewLineAndSupportAnyKindOfDelimeter_ShouldReturnTheSumOfAllNumbers(string input, int expected)
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
