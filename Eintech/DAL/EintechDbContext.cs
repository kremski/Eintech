using System;
using Eintech.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Eintech.DAL
{
    public class EintechDbContext : DbContext
    {
        private DbContextOptions<EintechDbContext> options;
        public EintechDbContext(DbContextOptions<EintechDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Group>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Person>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Person>()
                .HasOne(e => e.Group)
                .WithMany(x => x.People)
                .HasForeignKey(e => e.GroupId)
                .IsRequired();


            modelBuilder.Entity<Group>()
                .HasData(
                    new Group { Id = 1, Name = "One" },
                    new Group { Id = 2, Name = "Two" }
                    );
            modelBuilder.Entity<Person>()
                .HasData(
                    new Person { Id = 1, Name = "Doc", DateAdded = new DateTime(2001, 1, 1), GroupId = 1 },
                    new Person { Id = 2, Name = "Grumpy", DateAdded = new DateTime(2002, 2, 2), GroupId = 2 },
                    new Person { Id = 3, Name = "Happy", DateAdded = new DateTime(2003, 3, 3), GroupId = 1 },
                    new Person { Id = 4, Name = "Sleepy", DateAdded = new DateTime(2004, 4, 4), GroupId = 2 },
                    new Person { Id = 5, Name = "Bashful", DateAdded = new DateTime(2005, 5, 5), GroupId = 1 }
                    );
        }
    }
}
