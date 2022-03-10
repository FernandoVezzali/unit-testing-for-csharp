using System.Collections.Generic;
using System.Linq;

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
    }

    public interface IDatabase
    {
        public BasicPerson GetById(int id);
        public IEnumerable<BasicPerson> GetAll();
        public List<BasicPerson> GetTop(int numberOfRows);
    }
}
