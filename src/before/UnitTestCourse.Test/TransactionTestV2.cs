using System;
using Xunit;
// todo 02 xUnit: Reusing code across different test methods
namespace UnitTestCourse.Test
{
    /*
                    NUnit       MSTest              Xunit

    Code reuse:     [SetUp]	    [TestInitialize]	Constructor         

    */

    public class TransactionTestV2
    {
        

        public TransactionTestV2()
        {
            
        }

        [Fact]
        public void ShouldReturnAmount100()
        {

        }

        [Fact]
        public void ShouldReturnAmount200()
        {

        }
    }
}
