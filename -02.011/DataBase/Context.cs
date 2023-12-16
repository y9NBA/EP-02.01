using _02._011.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._011.DataBase
{
    internal class Context : DbContext
    {
        private Context() { 
            Database.EnsureCreated();
        }

        public static Context Instance { get; } = new();

        public DbSet<TasksNotes> TaskNotes { get; set; }
        public DbSet<Types> Types { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=DBook.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TasksNotes>().ToTable("TaskNote");
            modelBuilder.Entity<Types>()
                .ToTable("TaskNoteType")
                .HasData(new List<Types> 
                { 
                    new Types() { ID = 1, Name = "Note" }, 
                    new Types() { ID = 2, Name = "Task" } 
                });
        }
    }
}
