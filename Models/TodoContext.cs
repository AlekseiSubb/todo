using Microsoft.EntityFrameworkCore;

namespace todo.Models
{
    public class TodoContext: DbContext
    {
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }
    }
}