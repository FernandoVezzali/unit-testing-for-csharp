using System;
using System.Collections.Generic;
using Bogus;
using Xunit;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Extensions;
using Moq;

namespace UnitTestCourse.Test
{
    public class FluentAssertionsTest
    {
        [Fact]
        public void ShouldReturnAmount100()
        {
            // Arrange
            var transaction = new Transaction(Guid.NewGuid().ToString(), DateTime.Now, 100);

            // Assert
            //Assert.Equal(200, transaction.Amount);
            transaction.Amount.Should().Be(200);
        }

        [Fact]
        public void ShouldHaveCorrectPropertyValues()
        {
            // Act
            var person = new ImmutablePerson(1, "John", "Smith", "johngmail.com", DateTime.Now);

            // Assert
            person.FirstName.Should().StartWith("J");
            person.LastName.Should().EndWith("h");
            person.Email.Should().Match("*@*", because: "any valid e-mail should at least contain @");
        }

        [Fact]
        public void ShouldReturnCorrectDateOfBirth()
        {
            // Act
            var person = new ImmutablePerson(1, "John", "Smith", "johngmail.com", new DateTime(2000, 1, 2));

            // Assert
            person.DateOfBirth.Should().Be(2.January(2000));
        }

        [Fact]
        public void ShouldHandleException()
        {
            // Arrange
            var transaction = new Transaction(Guid.NewGuid().ToString(), DateTime.Now, 100);

            // Assert
            //Assert.Throws<DivideByZeroException>(() => transaction.Divide(1));
            Action action = () => transaction.Divide(1);
            action.Should().Throw<DivideByZeroException>();
        }

        [Fact]
        public void ShouldReturnCorrectAmountOfRows()
        {
            // Arrange
            var listOfPeople = new Faker<BasicPerson>()
                .RuleFor(c => c.Id, f => f.Random.Int())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.DateOfBirth, f => f.Date.Past(1))
                .Generate(100);

            var database = new Mock<IDatabase>();
            database.Setup(x=>x.GetAll()).Returns(listOfPeople);

            var repository = new PersonRepository(database.Object);
            var people = repository.GetTop(10);

            people.Should().NotBeNullOrEmpty();
            people.Should().HaveCount(9);
            people.Should().OnlyHaveUniqueItems();
            people.Should().BeInAscendingOrder(x => x.FirstName);
            people.Should().NotBeOfType<List<BasicPerson>>();

        }

        [Fact]
        public void ShouldReturnCorrectAmountOfRowsWithScope()
        {
            // Arrange
            var listOfPeople = new Faker<BasicPerson>()
                .RuleFor(c => c.Id, f => f.Random.Int())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.DateOfBirth, f => f.Date.Past(1))
                .Generate(100);

            var database = new Mock<IDatabase>();
            database.Setup(x => x.GetAll()).Returns(listOfPeople);

            var repository = new PersonRepository(database.Object);
            List<BasicPerson> people = repository.GetTop(10);

            using (new AssertionScope())
            {
                people.Should().NotBeNullOrEmpty();
                people.Should().HaveCount(9);
                people.Should().OnlyHaveUniqueItems();
                people.Should().BeInAscendingOrder(x => x.FirstName);
                people.Should().NotBeOfType<List<BasicPerson>>();
            }
        }
    }
}
