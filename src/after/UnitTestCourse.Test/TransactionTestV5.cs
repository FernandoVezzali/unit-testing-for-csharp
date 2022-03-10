using System;
using Xunit;

namespace UnitTestCourse.Test
{
    /*

    Rounding
            
    */

    public class TransactionTestV5
    {
        [Fact]
        public void ShouldReturnAmount16()
        {
            // Arrange
            var transaction = new Transaction(Guid.NewGuid().ToString(), DateTime.Now, 100);

            // Act
            var actual = transaction.Divide(6);

            // Assert
            Assert.Equal(expected: 16.667, actual, precision: 3);
        }
    }
}