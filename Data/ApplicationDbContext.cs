using System;
using api_app.models;
using Microsoft.EntityFrameworkCore;

namespace api_app.Data
{
	public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> user { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User {Id=1, UserName="abbas"},
                    new User { Id = 2, UserName = "ali" },
                    new User { Id = 3, UserName = "ahmed" },
                    new User { Id = 4, UserName = "mohammed" },
                    new User { Id = 5, UserName = "kadem" },
                    new User { Id = 6, UserName = "hussain" }

                );
        }
    }
}

