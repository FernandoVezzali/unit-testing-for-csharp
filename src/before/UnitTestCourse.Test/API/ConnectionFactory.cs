using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace UnitTestCourse.Test
{
    public class ConnectionFactory 
    {
        public TodoContext CreateContextForSQLite()
        {
            using SqliteConnection connection = new SqliteConnection("DataSource=:memory:");

            connection.Open();

            var option = new DbContextOptionsBuilder<TodoContext>().UseSqlite(connection).Options;

            var context = new TodoContext(option);

            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }
    }
}
