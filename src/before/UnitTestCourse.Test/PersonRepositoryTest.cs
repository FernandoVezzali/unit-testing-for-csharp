using Bogus;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
// todo 04 xUnit: Executing tests multiple times with Theory and InLineData
namespace UnitTestCourse.Test
{
    public class PersonRepositoryTest
    {
        [Theory]
        [InlineData(1, 10, 11)]
        [InlineData(10, 100, 12)]
        [InlineData(100, 1000, 13)]
        public void ShouldReturnCorrectAmountOfRows(int numberOfRowsToReturn, int numberOfTotalRows, int yearsToGoBack)
        {

        }
    }
}
