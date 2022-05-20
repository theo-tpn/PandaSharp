using Newtonsoft.Json;
using NUnit.Framework;
using PandaSharp.Utils;
using System;
using System.Text.Json.Serialization;

namespace PandaSharp.Tests
{
    public class PandaQueryTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ToStringShouldReturnFullQuery()
        {
            //arrange
            var q = new PandaQuery().AddFilter<Foo>(x => x.Name, new string[] { "value" });

            //act
            var result = q.ToString();

            //assert
            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result);
            Assert.That(result.Split('=')[1] == "value");
        }

        [Test]
        public void ToStringShouldEmptyValue()
        {
            //arrange
            var q = new PandaQuery();

            //act
            var result = q.ToString();

            //assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void ShouldThrowsExceptionIfOperationHasAlreadyBeDone()
        {
            //arrange
            var filterValues = new string[] { "value" };
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() => 
            { 
                new PandaQuery()
                .AddFilter<Foo>(x => x.Name, filterValues)
                .AddFilter<Foo>(x => x.Name, filterValues); 
            });
        }

        [Test]
        public void ShouldThrowsExceptionIfPropertyJsonAttributeCannotBeEvaluate()
        {
            //arrange
            var filterValue = new string[] { "value" };
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                new PandaQuery()
                .AddFilter<Foobad>(x => x.Name, filterValue);
            });
        }

        class Foo
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }
        }

        class Foobad
        {
            public string Name { get; set; }
        }
    }
}
