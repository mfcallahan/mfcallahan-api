using HomepageDev.API;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HomepageDev.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExtensionMethodsTests
    {
        private Dictionary<string, string> Dict;

        [SetUp]
        public void SetUp()
        {
            Dict = new Dictionary<string, string>() {
                { "foo", "bar" }
            };
        }

        [Test]
        [TestCase("baz", "qux")]
        public void AddIfNotNull_Should_Add_Key_Value_Pair_To_Dictionary_If_Value_Is_Not_Null(string key, string value)
        {
            var expectedDictLength = Dict.Count + 1;

            Dict.AddIfNotNull(key, value);

            Assert.That(Dict.Count == expectedDictLength);
            Assert.That(Dict.ContainsKey(key) && Dict[key] == value);
        }

        [Test]
        [TestCase("baz", null)]
        public void AddIfNotNull_Should_Not_Add_Key_Value_Pair_To_Dictionary_If_Value_Is_Null(string key, string value)
        {
            var expectedDictLength = Dict.Count;

            Dict.AddIfNotNull(key, value);

            Assert.That(Dict.Count == expectedDictLength);
            Assert.That(!Dict.ContainsKey(key));
        }
    }
}
