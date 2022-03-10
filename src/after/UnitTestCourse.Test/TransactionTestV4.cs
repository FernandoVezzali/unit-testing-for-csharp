using System;
using Xunit;

namespace UnitTestCourse.Test
{
    /*

    [Theory] Atribute
    [InLineData(1,2,3)] // must be static (constant, enum, values) complex types arent accepted
            
    */

    public class TransactionTestV4
    {
        [Theory]
        [InlineData(100, 200)]
        [InlineData(200, 300)]
        [InlineData(-100, 0)]
        public void ShouldReturnCorrectAmount(int amountToSum, int expected)
        {
            // Arrange
            var transaction = new Transaction(Guid.NewGuid().ToString(), DateTime.Now, 100);

            // Act
            transaction.Sum(amountToSum);

            // Assert
            Assert.Equal(expected, actual: transaction.Amount);
        }
    }
}