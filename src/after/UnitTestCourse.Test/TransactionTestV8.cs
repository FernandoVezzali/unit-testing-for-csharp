using Xunit;

// todo 13 xUnit: Skip
namespace UnitTestCourse.Test
{
    public class TransactionTestV8
    {
        [Fact(Skip = "skipping the test")]
        public void ShouldReturnAmount200()
        {
            Assert.Equal(1, 2);
        }
    }
}
