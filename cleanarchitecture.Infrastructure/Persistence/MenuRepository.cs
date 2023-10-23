using cleanarchitecture.Domain.MenuAggregate;

namespace cleanarchitecture.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<MenU> _menus = new();
    public void Add(MenU menu)
    {
       _menus.Add(menu);
    }
}