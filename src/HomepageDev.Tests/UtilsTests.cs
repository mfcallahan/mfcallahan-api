using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using Utils = HomepageDev.API.Utils;

namespace HomepageDev.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UtilsTests
    {
        [Test]
        [TestCase(100)]
        public void GenerateRandomString_Should_Return_Random_String_With_Correct_Length(int length)
        {
            string randomString = Utils.GenerateRandomString(length);

            Assert.That(randomString.Length == length);
        }

        [Test]
        [TestCase(100)]
        public void GenerateRandomString_Calls_Should_Return_Different_Strings(int length)
        {
            string randomString1 = Utils.GenerateRandomString(length);
            string randomString2 = Utils.GenerateRandomString(length);

            Assert.That(!string.Equals(randomString1, randomString2));
        }

        [Test]
        [TestCase(1, 1000)]
        public void GenerateRandomInteger_Should_Return_Random_Integer_Between_Minimum_And_Maximum(int minValue, int maxValue)
        {
            int randomInt = Utils.GenerateRandomInteger(minValue, maxValue);

            Assert.That(randomInt >= minValue);
            Assert.That(randomInt <= maxValue);
        }

        [Test]
        [TestCase(1000, 1)]
        public void GenerateRandomInteger_Should_Throw_ArgumentOutOfRangeException_When_MinValue_Is_Greater_Than_MaxValue(int minValue, int maxValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Utils.GenerateRandomInteger(minValue, maxValue));
        }
    }
}
