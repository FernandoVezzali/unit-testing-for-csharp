using System;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestCourse.Test
{
    /*

    Output
            
    */

    public class TransactionTestV7
    {
        readonly ITestOutputHelper _output;

        public TransactionTestV7(ITestOutputHelper output)
        {
            _output = output;
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
            
            _output.WriteLine($"Final amount was {transaction.Amount}");
        }
    }
}