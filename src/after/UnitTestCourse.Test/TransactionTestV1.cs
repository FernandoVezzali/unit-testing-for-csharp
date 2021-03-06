using System;
using Xunit;

namespace UnitTestCourse.Test
{
        /*
                   NUnit               MSTest          Xunit

        Class:     [TestFixture]       [TestClass]         

        Method:    [Test]	           [TestMethod]	[Fact]

        */

    public class TransactionTestV1
    {
        [Fact]
        public void ShouldReturnAmount100()
        {
            // Arrange
            var transaction = new Transaction(Guid.NewGuid().ToString(), DateTime.Now, 100);

            // Assert
            Assert.Equal(100, transaction.Amount);
        }

        [Fact]
        public void ShouldReturnAmount200()
        {
            // Arrange
            var transaction = new Transaction(Guid.NewGuid().ToString(), DateTime.Now, 100);

            // Act
            transaction.Sum(100);

            // Assert
            Assert.Equal(200, transaction.Amount);
        }
    }
}
