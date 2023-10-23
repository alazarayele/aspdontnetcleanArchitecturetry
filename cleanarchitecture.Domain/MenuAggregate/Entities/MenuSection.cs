using cleanarchitecture.Domain.Common.Models;
using cleanarchitecture.Domain.MenuAggregate.ValueObjects;

namespace cleanarchitecture.Domain.MenuAggregate.Entities;


public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name {get;}
    public string Description {get;}

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId,
    string name,
    string description
    ) : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    public static MenuSection Create(
        string name,
        string description
,
        List<MenuItem> menuItems)
    {
        return new(MenuSectionId.createUnique(),
        name,
        description);
    }

 
}