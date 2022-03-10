using System;
using Xunit;

namespace UnitTestCourse.Test
{
    public class ImmutablePersonTest
    {
        [Theory]
        [InlineData(1, "John", "Smith", "john@gmail.com")]
        public void ShouldHaveCorrectPropertyValues(int id, string firstName, string lastName, string email)
        {

        }
    }
}
