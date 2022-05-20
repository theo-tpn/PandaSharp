using NUnit.Framework;
using PandaSharp.Entities;
using PandaSharp.Utils;
using PandaSharp.Utils.Enums;
using System;

namespace PandaSharp.Tests
{
    public class PandaRequestTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void FromOperationShouldThrowsExceptionWhenWrongEntity()
        {
            //arrange
            var badEntity = (PandaEntity)int.MaxValue;
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                var request = new PandaRequest().From(badEntity);
            });
        }

        [Test]
        public void FromOperationShouldThrowsExceptionWhenAlreadyChained()
        {
            //arrange
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                var request = new PandaRequest()
                .From(PandaEntity.Leagues)
                .From(PandaEntity.Ow);
            });
        }

        [Test]
        public void GetOperationShouldThrowsExceptionWhenWrongEntity()
        {
            //arrange
            var badEntity = (PandaEntity)int.MaxValue;
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                var request = new PandaRequest().Get(badEntity);
            });
        }

        [Test]
        public void GetOperationShouldThrowsExceptionWhenAlreadyChained()
        {
            //arrange
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                var request = new PandaRequest()
                .Get(PandaEntity.Leagues)
                .Get(PandaEntity.Ow);
            });
        }

        [Test]
        public void QueryOperationShouldThrowsExceptionWhenAlreadyChained()
        {
            //arrange
            //act
            //assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                var request = new PandaRequest()
                .AddQuery(new PandaQuery())
                .AddQuery(new PandaQuery());
            });
        }

        [Test]
        public void ToStringShouldReturnNotEmptyValueWhenOperationsChained()
        {
            //arrange
            var request = new PandaRequest()
                .Get(PandaEntity.Leagues);
            //act
            var result = request.ToString();

            //assert
            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void ToStringShouldReturnQueryWhenChained()
        {
            //arrange
            var request = new PandaRequest()
                .Get(PandaEntity.Leagues)
                .AddQuery(new PandaQuery()
                    .AddFilter<Match>(x => x.Slug, new[] { "value" })
                    );
            //act
            var result = request.ToString();

            //assert
            Assert.IsTrue(result.Contains('?'));
        }
    }
}
