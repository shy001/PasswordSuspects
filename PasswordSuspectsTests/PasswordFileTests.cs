using NUnit.Framework;
using PasswordDeterminationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSuspectsTests
{
    [TestFixture]
    public class PasswordFileTests
    {
        public PasswordDetermination _passwordDetermination;
        [SetUp]
        public void setupConnection()
        {
            _passwordDetermination = new PasswordDetermination();
        }

        [Test]
        [TestCase("originalpassword.txt", "Empty File")]
        public void ReadInputFile_IfEmpty_Return_Message(string input, string expectedResult)
        {
            var actualResult = _passwordDetermination.ReadInputFile(input);
            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        [TestCase("invalidpassword.txt", "False")]
        public void ReadInputFile_ValidateFirstLine_Return_False(string input, string expectedResult)
        {
            var actualResult = _passwordDetermination.ReadInputFile(input);
            Assert.AreEqual(expectedResult, actualResult);
        }


        //[Test]
        //[TestCase("passwordValid.txt")]
        //public void ReadInputFile_ValidateFirstLine_Return_NullErrorMessage(string input)
        //{
        //    var actualResult = _passwordDetermination.ReadInputFile(input);
        //    Assert.IsNull(actualResult);
        //}

        [Test]
        [TestCase("invalidNoZeroZeropassword.txt", "Does not contain '0 0'")]
        public void ReadInputFile_ValidateContainsZeroZero_Return_NullErrorMessage(string input, string expectedResult)
        {
            var actualResult = _passwordDetermination.ReadInputFile(input);
            Assert.AreEqual(actualResult,expectedResult);
        }

        [Test]
        [TestCase("password.txt", "141167095653376")]
        public void ReadInputFile_Return_NumberOfSuspects(string input, string expectedResult)
        {
            var actualResult = _passwordDetermination.ReadInputFile(input);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase(10, 2,2)]
        [TestCase(4, 1, 1)]
        public void ReadInputFile_Return_NumberOfSuspectsWithSubstrings(int input, int noOfKnownSubstrings,int expectedResult)
        {
            var actualResult = _passwordDetermination.ManageCombinations(input,noOfKnownSubstrings);
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
