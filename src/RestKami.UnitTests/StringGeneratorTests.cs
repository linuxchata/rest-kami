using NUnit.Framework;

using RestKami.Core;

namespace RestKami.UnitTests
{
    [TestFixture]
    public class StringGeneratorTests
    {
        private readonly StringSeedDataGenerator sut = new StringSeedDataGenerator();

        [Test]
        public void Test1()
        {
            //Act
            var result = this.sut.GenerateStringWithEscapeCharacters();

            //Assert
            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void Test2()
        {
            //Act
            var result = this.sut.GenerateLongString();

            //Assert
            Assert.That(result, Is.Not.Empty);
        }
    }
}