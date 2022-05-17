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
        public void ShouldReturnFullQuery()
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
        public void ShouldThrowsExceptionIfOperationHasAlreadyBeDone()
        {
            //arrange
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() => 
            { 
                new PandaQuery()
                .AddFilter<Foo>(x => x.Name, new string[] { "value" })
                .AddFilter<Foo>(x => x.Name, new string[] { "value" }); 
            });
        }
    }

    public class Foo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
