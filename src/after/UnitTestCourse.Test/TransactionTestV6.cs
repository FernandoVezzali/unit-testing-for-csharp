using System;
using Xunit;

namespace UnitTestCourse.Test
{
    /*

    Exceptions
            
    */

    public class TransactionTestV6
    {
        [Fact]
        public void ShouldHandleException()
        {
            // Arrange
            var transaction = new Transaction(Guid.NewGuid().ToString(), DateTime.Now, 100);

            // Assert
            Assert.Throws<DivideByZeroException>(() => transaction.Divide(0));
        }
    }
}