using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestCourse
{
    public class PersonRepository
    {
        readonly IDatabase _database;

        public PersonRepository(IDatabase database)
        {
            _database = database;
        }

        public string GetFullNameById(int id)
        {
            return $"{_database.GetAll().FirstOrDefault(x => x.Id == id)!.FirstName} {_database.GetAll().FirstOrDefault(x => x.Id == id)!.LastName}";
        }

        public List<BasicPerson> GetTop(int numberOfRows)
        {
            return _database.GetAll().OrderBy(x => x.FirstName).Take(numberOfRows).ToList();
        }

        public async Task<List<BasicPerson>> GetAll()
        {
            List<BasicPerson> people = new Faker<BasicPerson>()
                .RuleFor(c => c.Id, f => f.Random.Int())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.DateOfBirth, f => f.Date.Past(5).Date)
                .Generate(3);

            return await Task.FromResult(people);
        }
    }

    public interface IDatabase
    {
        public BasicPerson GetById(int id);
        public IEnumerable<BasicPerson> GetAll();
        public List<BasicPerson> GetTop(int numberOfRows);
    }
}
