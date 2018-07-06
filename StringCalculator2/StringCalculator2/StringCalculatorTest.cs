using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculator2
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
            var sut = new StringCalculator();
            var expected = 0;
            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Add_GivenstringNiumberOf1_ShouldReturnOne()
        {
            //Arrange
            var sut = new StringCalculator();
            var input = "1";
            var expected = 1;
            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("1",1)]
        [TestCase("1,2",3)]
        [TestCase("1,2,3",6)]
        public void Add_GivenCommaSeparatedNumbers_ShouldReturnSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();
          
            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected,actual);
        }
        [TestCase("1", 1)]
        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        public void Add_GivenNewLineSeparatedNumbers_ShouldReturnSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//;1", 1)]
        [TestCase("//;1\n2", 3)]
        [TestCase("//;1\n2;3", 6)]
        public void Add_GivenNumbersWithDelimeters_ShouldReturnSumOfAllNumbers(string input, int expected)
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
        public void Add_GivenNagativeNumbers_ShouldThrowExceptionMessage(string input)
        {
            //Arrange
            var sut = new StringCalculator();
            var expectedMessage = "Negatives are not allowed" + input;
            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //Assert
            Assert.AreEqual(expectedMessage, actual.Message);
        }
        [TestCase("1000", 1000)]
        [TestCase("//;1000\n2", 1002)]
        [TestCase("//;1000\n2;3", 1005)]
        public void Add_GivenNumbersGreaterThan1000_ShouldReturnIgnoreTheGreaterNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[***]\n4***5***6", 15)]
        [TestCase("//[***]\n7***8***9", 24)]
        public void Add_GivenDelimetersInSquereBrackets_ShouldReturnSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//{~~~}\n1~~~2~~~3", 6)]
        [TestCase("//{~~~}\n4~~~5~~~6", 15)]
        [TestCase("//{~~~}\n7~~~8~~~9", 24)]
        public void Add_GivenAnyKindOfDelimeterInCurlyBraces_ShouldReturnSumOfAllNumbers(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase("//(!!!)\n1!!!2!!!3", 6)]
        [TestCase("//(^^^)\n4^^^5^^^6", 15)]
        [TestCase("//(###)\n7###8###9", 24)]
        public void Add_GivenAnyKindOfDelimeterInParenthisis_ShouldReturnSumOfAllNumbers(string input, int expected)
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
