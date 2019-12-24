using System.Collections.Generic;

using NUnit.Framework;

using RestKami.Core;

namespace RestKami.UnitTests
{
    [TestFixture]
    public class PermutationHelperTests
    {
        private readonly PermutationHelper _sut = new PermutationHelper();

        [Test]
        public void Test()
        {
            //Arrange
            var source = new List<string[]>
            {
                new[]
                {
                    "a",
                    "b",
                    "c"
                },
                new[]
                {
                    "1",
                    "2"
                },
                new[]
                {
                    "6",
                    "7"
                }
            };

            //Act
            var result = _sut.Permutate(source);

            //Assert
            Assert.That(result.Count, Is.EqualTo(12));
        }
    }
}