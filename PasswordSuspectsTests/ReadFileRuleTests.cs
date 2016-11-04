using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordDeterminationLogic;
using NUnit.Framework;

namespace PasswordSuspectsTests
{
    [TestFixture]
    public class ReadFileRuleTests 
    {
        public PasswordDetermination _passwordDetermination;
        public ReadFileRule _readFileRule;
        [SetUp]
        public void setupConnection()
        {
            _passwordDetermination = new PasswordDetermination();
            _readFileRule = new ReadFileRule();
        }

        [Test]
        [TestCase(@"originalpassword.txt", "Empty File")]
        [TestCase(@"filedoesnotexist.txt", "File does not Exist")]
        [TestCase(@"invalidpassword.txt", "Does not contain '0 0'")]
        public void ReadInputFile_IfEmpty_Return_Message(string input, string expectedResult)
        {
            var actualResult = _passwordDetermination.ReadInputFile(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        //[Test]
        //[TestCase(@"invalidpassword.txt", "Does not contain '0 0'")]
        //public void ReadInputFile_ValidateFirstLine_Return_DoesNotContainZeroZero(string input, string expectedResult)
        //{
        //    var actualResult = _passwordDetermination.ReadInputFile(input);
        //    Assert.AreEqual(expectedResult, actualResult);
        //}

        [Test]
        [TestCase(@"c:\mytest\passwordValid.txt",null)]
        [TestCase(@"c:\mytest\originalpassword.txt", "Empty File")]
        [TestCase(@"c:\mytest\filedoesnotexist.txt", "File does not Exist")]
        [TestCase(@"c:\mytest\invalidpassword.txt", "Does not contain '0 0'")]
        public void ReadInputFile_ValidateFirstLine_Return_NullErrorMessage(string input, string expectedResult)
        {
            var actualResult = _readFileRule.ValidateFile(input);
            Assert.AreEqual(actualResult, expectedResult);
        }

        //[Test]
        //[TestCase("password.txt", "141167095653376")]
        //public void ReadInputFile_Return_NumberOfSuspects(string input, string expectedResult)
        //{
        //    var actualResult = _passwordDetermination.ReadInputFile(input);
        //    Assert.AreEqual(actualResult, expectedResult);
        //}

        [Test]
        [TestCase("e", false)]
        [TestCase("3", true)]
        [TestCase("3e", false)]
        public void ReadIsDigitsOnly_Return_BooleanResult(string input, bool expectedResult)
        {
            var actualResult = _readFileRule.IsDigitsOnly(input);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase(3, 2, 8)]
        [TestCase(3, 3, 27)]
        public void Read_FindPowerOf_Return_DoubleResult(int baseValue, int powerOf, double expectedResult)
        {
            var actualResult = _passwordDetermination.FindPowerOf(baseValue, powerOf);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase(10, 2, 2)]
        [TestCase(4, 1, 1)]
        public void Read_ManageCombinations_Return_IntResult(int lengthOfString, int numberOfKnownSubstrings, int expectedResult)
        {
            var actualResult = _passwordDetermination.ManageCombinations(lengthOfString, numberOfKnownSubstrings);
            Assert.AreEqual(actualResult, expectedResult);
        }

    }
}
