using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestCourse.Test
{
    public class AuthorizedTransactionTests
    {
        [Fact]
        public void ShouldHandleNotImplementedException()
        {
            // Arrange
            var externalAuthorization = new ExternalAuthorization();
            var transaction = new AuthorizedTransaction(Guid.NewGuid().ToString(), DateTime.Now, 100, externalAuthorization);

            // Assert
            Assert.Throws<NotImplementedException>(() => transaction.Sum(100));
        }

        [Fact]
        public void ShouldReturnAmount200AsItsAuthorized()
        {
            // Arrange
            var externalAuthorization = new Mock<IExternalAuthorization>();
            externalAuthorization.Setup(x=>x.IsAuthorized()).Returns(true);
            var transaction = new AuthorizedTransaction(Guid.NewGuid().ToString(), DateTime.Now, 100, externalAuthorization.Object);

            // Act
            transaction.Sum(100);

            // Assert
            Assert.Equal(200, transaction.Amount);
        }

        [Fact]
        public void ShouldReturnAmount100AsItsNotAuthorized()
        {
            // Arrange
            var externalAuthorization = new Mock<IExternalAuthorization>();
            externalAuthorization.Setup(x => x.IsAuthorized()).Returns(false);
            var transaction = new AuthorizedTransaction(Guid.NewGuid().ToString(), DateTime.Now, 100, externalAuthorization.Object);

            // Act
            transaction.Sum(100);

            // Assert
            Assert.Equal(100, transaction.Amount);
        }
    }
}
