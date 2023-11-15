using cleanarchitecture.Domain.MenuAggregate;

namespace cleanarchitecture.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
  private readonly CleanArchitectureDbContext _dbContext;
   
   
   public MenuRepository(CleanArchitectureDbContext dbContext)
   {
        _dbContext = dbContext;
   }
    public void Add(MenU menu)
    {
       _dbContext.Add(menu);
       _dbContext.SaveChanges();
    }
}