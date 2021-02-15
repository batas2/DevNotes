using System;
using Xunit;
using static UnitTests.ValueObjectValidation.ValueObjectBuilder;

namespace UnitTests.ValueObjectValidation
{
    public class ValueObjectTests
    {
        [Fact]
        public void CorrectModelCanBeConstructed()
        {
            AValueObject().Build();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(999)]
        public void ModelCanNotBeCreatedWithWrongStatus(int status)
        {
            Assert.Throws<InvalidOperationException>(() =>
                AValueObject()
                    .WithStatus((Status) status)
                    .Build());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(999)]
        public void ModelCanNotBeCreatedWithWrongWithKeyId(int key)
        {
            Assert.Throws<InvalidOperationException>(() =>
                AValueObject()
                    .WithKeyId(key)
                    .Build());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(999)]
        public void ModelCanNotBeCreatedWithWrongSharingContextStatus(int foreignId)
        {
            Assert.Throws<InvalidOperationException>(() =>
                AValueObject()
                    .WithForeignId(foreignId)
                    .Build());
        }
    }
}