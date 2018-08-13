using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculatorSixthWeek
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenInvalidInputOfEmpties_ShouldReturnZero(string input)
        {
            //Arrange
            var expected = 0;
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestCase("1,2,3",6)]
        [TestCase("100,200,300",600)]
        [TestCase("23,33,43",99)]
        public void Add_GivenInputOfNumbersThatAreCommaSeparatedDelimeters_ShouldReturnSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2\n3", 6)]
        [TestCase("100,200\n300", 600)]
        [TestCase("23\n33\n43", 99)]
        public void Add_GivenInputOfNumbersThatAreCommaSeparatedWithANewLineAdded_ShouldReturnSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n1;2;3", 6)]
        [TestCase("//;\n100,200\n300", 600)]
        [TestCase("//;\n23\n33;43", 99)]
        public void Add_GivenInputOfNumbersThatSupportDifferentDelimeters_ShouldReturnSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Arrange
            Assert.AreEqual(expected, actual);
        }

        [TestCase("//;\n-1;-2;3")]
        [TestCase("//;\n-100,-200\n-300")]
        [TestCase("//;\n-23\n-33;-43")]
        public void Add_GivenInputOfNegativeNumbers_ShouldThrowAnExceptionMessage(string input)
        {
            //Arrange
            var expected = "Negative values are not allowed" + input;
            var sut = new StringCalculator();
            //Act
            var actual = Assert.Throws<Exception>(()=>sut.Add(input));
            //Arrange
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("//;\n1003;1000;2;3", 1005)]
        [TestCase("//;\n2500,100,200\n300", 600)]
        [TestCase("//;\n3001,23\n33;43", 99)]
        public void Add_GivenInputOfNumbersThatAreGreaterThan1000_ShouldReturnSumOfAllNumbersThatAreLessThan1000(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
            //Act
            var actual = sut.Add(input);
            //Arrange
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

