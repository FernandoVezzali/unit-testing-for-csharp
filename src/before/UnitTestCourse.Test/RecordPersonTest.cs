using System;
using Xunit;

namespace UnitTestCourse.Test
{
    public class RecordPersonTest
    {
        /// <summary>
        /// Since record types are immutable (when properly built) it is no longer necessary adding this kind of test
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        [Theory]
        [InlineData(1, "John", "Smith", "john@gmail.com")]
        public void ShouldHaveCorrectPropertyValues(int id, string firstName, string lastName, string email)
        {

        }
    }
}
