using cleanarchitecture.Domain.Common.Models;
using cleanarchitecture.Domain.Menu.ValueObjects;

namespace cleanarchitecture.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    
    public string Name {get;}
    public string Description {get;}

    public float AverageRating {get;}
}