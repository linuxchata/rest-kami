using NUnit.Framework;

using RestKami.Core;

namespace RestKami.UnitTests
{
    [TestFixture]
    public class StringGeneratorTests
    {
        private readonly StringSeedDataGenerator _sut = new StringSeedDataGenerator();

        [Test]
        public void Test1()
        {
            //Act
            string[] result = _sut.GenerateStringWithEscapeCharacters();

            //Assert
            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void Test2()
        {
            //Act
            string[] result = _sut.GenerateLongString();

            //Assert
            Assert.That(result, Is.Not.Empty);
        }
    }
}