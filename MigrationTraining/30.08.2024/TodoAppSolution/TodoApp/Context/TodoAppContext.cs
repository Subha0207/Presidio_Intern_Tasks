using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Context
{
    public class TodoAppContext : DbContext

    {
        public TodoAppContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            modelBuilder.Entity<Todo>().HasKey(t => t.TodoId);
            modelBuilder.Entity<User>()
             .HasMany(t => t.Todos)
             .WithOne(u => u.User)
             .HasForeignKey(u => u.UserId)
             .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
