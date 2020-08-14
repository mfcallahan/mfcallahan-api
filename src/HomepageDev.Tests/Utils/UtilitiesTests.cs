using HomepageDev.API.Utils;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UtilitiesTests
    {
        [Test]
        [TestCase(100)]
        public void GenerateRandomString_Should_Return_Random_String_With_Correct_Length(int length)
        {
            // Act
            string randomString = Utilities.GenerateRandomString(length);

            // Assert
            Assert.That(randomString.Length == length);
        }

        [Test]
        [TestCase(100)]
        public void GenerateRandomString_Calls_Should_Return_Different_Strings(int length)
        {
            // Act
            string randomString1 = Utilities.GenerateRandomString(length);
            string randomString2 = Utilities.GenerateRandomString(length);

            // Assert
            Assert.That(!string.Equals(randomString1, randomString2));
        }

        [Test]
        [TestCase(1, 1000)]
        public void GenerateRandomInteger_Should_Return_Random_Integer_Between_Minimum_And_Maximum_Inclusive(int minValue, int maxValue)
        {
            // Act
            int randomInt = Utilities.GenerateRandomInteger(minValue, maxValue);

            // Assert
            Assert.That(randomInt >= minValue);
            Assert.That(randomInt <= maxValue);
        }

        [Test]
        [TestCase(1000, 1)]
        public void GenerateRandomInteger_Should_Throw_ArgumentOutOfRangeException_When_MinValue_Is_Greater_Than_MaxValue(int minValue, int maxValue)
        {
            // Arrange
            object testDelegate() => Utilities.GenerateRandomInteger(minValue, maxValue);

            // Act
            // Assert
            Assert.That(testDelegate, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(100, 100)]
        public void GenerateRandomInteger_MinValue_And_MaxValue_Params_Should_Be_Inclusive(int minValue, int maxValue)
        {
            // Act
            int randomInt = Utilities.GenerateRandomInteger(minValue, maxValue);

            // Assert
            Assert.That(randomInt == minValue);
            Assert.That(randomInt == maxValue);
        }
    }
}
