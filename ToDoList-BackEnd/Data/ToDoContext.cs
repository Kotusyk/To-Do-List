using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ToDoList_BackEnd.Model;

namespace ToDoList_BackEnd.ToDoListContext
{
    public class ToDoContext : DbContext
    {
       public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
       {
            Database.EnsureCreated();
       }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(e => e.Title)
                    .HasColumnType("varchar")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.Status)
                    .HasColumnType("bit")
                    .IsRequired();

            });
        }

        public DbSet<Assignment> Assignments { get; set; }
    }
}
