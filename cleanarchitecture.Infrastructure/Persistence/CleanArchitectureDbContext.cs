using cleanarchitecture.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace cleanarchitecture.Infrastructure.Persistence;

public class CleanArchitectureDbContext : DbContext
{
     public CleanArchitectureDbContext(DbContextOptions<CleanArchitectureDbContext> options)
     : base(options)
     {

     }

     public DbSet<MenU> Menus {get;set;} = null!;


     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          modelBuilder
               .ApplyConfiguraionsFromAssembly(typeof(CleanArchitectureDbContext).Assembly);
          base.OnModelCreating(modelBuilder);
     }

}