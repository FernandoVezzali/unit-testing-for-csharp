using System;

namespace UnitTestCourse
{
    public class ImmutablePerson
    {
        public ImmutablePerson(int id, string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime DateOfBirth { get; }
    }
}
