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

        }
    }
}