using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.Model;

namespace App.DAL.Data
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
                entity.HasKey(x => x.Id);;

                entity.Property(e => e.Title)
                      .HasColumnType("varchar")
                      .HasMaxLength(150)
                      .IsUnicode(false);

                entity.Property(e => e.Date)
                      .HasColumnType("varchar")
                      .HasMaxLength(150)
                      .IsUnicode(false);

                entity.Property(e => e.Status)
                     .HasColumnType("varchar")
                     .HasMaxLength(150)
                     .IsUnicode(false);


                entity.Property(e => e.Urgently)
                      .HasColumnType("bit");
            });
        }
        public DbSet<Assignment> Assignments { get; set; }


    } 
}

        }
  
