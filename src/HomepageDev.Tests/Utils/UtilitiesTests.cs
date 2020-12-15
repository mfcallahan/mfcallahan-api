using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using HomepageDev.API.Utils;

namespace HomepageDev.Tests.Utils
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
            object TestDelegate() => Utilities.GenerateRandomInteger(minValue, maxValue);

            // Act
            // Assert
            Assert.That(TestDelegate, Throws.TypeOf<ArgumentOutOfRangeException>());
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
        
        [Test]
        [TestCase(45, 125)]
        [TestCase(-25, 15)]
        [TestCase(-45, -5)]
        public void GenerateRandomDecimal_Should_Return_Random_Double_Between_Minimum_And_Maximum_Inclusive(int minValue, int maxValue)
        {
            // Act
            double randomInt = Utilities.GenerateRandomDecimal(minValue, maxValue);

            // Assert
            Assert.That(randomInt >= minValue);
            Assert.That(randomInt <= maxValue);
        }
        
        [Test]
        [TestCase(100, 20)]
        [TestCase(-25, -40)]
        public void GenerateRandomDecimal_Should_Throw_ArgumentOutOfRangeException_When_MinValue_Is_Greater_Than_MaxValue(int minValue, int maxValue)
        {
            // Arrange
            object TestDelegate() => Utilities.GenerateRandomDecimal(minValue, maxValue);

            // Act
            // Assert
            Assert.That(TestDelegate, Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        
        [Test]
        [TestCase(100, 100)]
        public void GenerateRandomDecimal_MinValue_And_MaxValue_Params_Should_Be_Inclusive(int minValue, int maxValue)
        {
            // Act
            double randomInt = Utilities.GenerateRandomDecimal(minValue, maxValue);

            // Assert
            Assert.That(randomInt == minValue);
            Assert.That(randomInt == maxValue);
        }
    }
}
