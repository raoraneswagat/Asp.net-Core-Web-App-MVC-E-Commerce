using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Category> Category { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(

            new Category() { Id = 1, Name = "Action", DisplayOrder = 1 },
             new Category() { Id = 2, Name = "SciFi", DisplayOrder = 2 },
              new Category() { Id = 3, Name = "History", DisplayOrder = 3 }


            );
    }


}

