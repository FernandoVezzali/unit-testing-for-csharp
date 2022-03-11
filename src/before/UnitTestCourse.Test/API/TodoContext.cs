using Microsoft.EntityFrameworkCore;

namespace UnitTestCourse.Test
{
    public partial class TodoContext : DbContext
    {
        public TodoContext() { }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options) { }

        public virtual DbSet<Todo> Todos { get; set; }
    }
}
