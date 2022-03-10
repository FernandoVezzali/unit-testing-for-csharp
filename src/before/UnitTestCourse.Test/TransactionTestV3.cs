using System;
using Xunit;
// todo 03 xUnit: Tests categorization
namespace UnitTestCourse.Test
{
    /*
    
    [Trait("", "")]

    dotnet test --filter Category=Sum

    */

    public class TransactionTestV3
    {
        [Fact]
        [Trait("Category", "Sum")]
        public void ShouldReturnAmount100()
        {

        }

        [Fact]
        [Trait("Category", "Sum")]
        public void ShouldReturnAmount200()
        {

        }

        [Fact]
        [Trait("Category", "Subtract")]
        public void ShouldReturnAmount100WhenSubtracting()
        {

        }

        [Fact]
        [Trait("Category", "Subtract")]
        public void ShouldReturnAmount200WhenSubtracting()
        {

        }
    }
}
