using Bogus;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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
            List<BasicPerson> people = new Faker<BasicPerson>()
                .RuleFor(c => c.Id, f => f.Random.Int())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.DateOfBirth, f => f.Date.Past(yearsToGoBack).Date)
                .Generate(numberOfTotalRows);

            var database = new Mock<IDatabase>();

            database.Setup(x=>x.GetAll()).Returns(people);

            var repo = new PersonRepository(database.Object);

            Assert.Equal(numberOfRowsToReturn, repo.GetTop(numberOfRowsToReturn).Count());
        }
    }
}
