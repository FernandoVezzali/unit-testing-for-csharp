using System.Linq;
using Bogus;
using Xunit;

namespace UnitTestCourse.Test
{
    public class BasicPersonTest
    {
        [Fact]
        public void ShouldHaveCorrectPropertyValuesFaker()
        {
            // Arrange
            var person = new Faker<BasicPerson>("pt_BR")
                .RuleFor(c => c.Id, f => f.Random.Int(1,10))
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.DateOfBirth, f => f.Date.Past(15).Date).Generate(1).FirstOrDefault();

            // Assert
            Assert.NotNull(person.FirstName);
            Assert.NotNull(person.LastName);
            Assert.NotNull(person.Email);
            Assert.Equal(0, person.DateOfBirth.Hour);
            Assert.Equal(0, person.DateOfBirth.Minute);
            Assert.Equal(0, person.DateOfBirth.Second);
        }
    }
}
