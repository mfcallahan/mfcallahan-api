using HomepageDev.API;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Specialized;

namespace HomepageDev.API.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExtensionMethodsTests
    {
        private NameValueCollection TestNameValueCollection;

        [SetUp]
        public void SetUp()
        {
            TestNameValueCollection = new NameValueCollection() { { "foo", "bar" } };
        }

        [Test]
        [TestCase("baz", "qux")]
        public void AddIfNotNull_Should_Add_Key_Value_Pair_To_Dictionary_If_Value_Is_Not_Null(string key, string value)
        {
            // Arrange
            var expectedDictLength = TestNameValueCollection.Count + 1;

            // Act
            TestNameValueCollection.AddIfNotNull(key, value);

            // Assert
            Assert.That(TestNameValueCollection.Count == expectedDictLength);
            Assert.That(TestNameValueCollection[key] == value);
        }

        [Test]
        [TestCase("baz", null)]
        public void AddIfNotNull_Should_Not_Add_Key_Value_Pair_To_Dictionary_If_Value_Is_Null(string key, string value)
        {
            // Arrange
            var expectedDictLength = TestNameValueCollection.Count;

            // Act
            TestNameValueCollection.AddIfNotNull(key, value);

            // Assert
            Assert.That(TestNameValueCollection.Count == expectedDictLength);
            Assert.That(TestNameValueCollection[key] == null);
        }
    }
}
