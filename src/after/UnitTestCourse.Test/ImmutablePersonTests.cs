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
            // Act
            var person = new ImmutablePerson(id, firstName, lastName, email, DateTime.Now.Date);

            // Assert
            Assert.Equal(person.Id, id);
            Assert.Equal(person.FirstName, firstName);
            Assert.Equal(person.LastName, lastName);
            Assert.Equal(person.Email, email);
        }
    }
}
