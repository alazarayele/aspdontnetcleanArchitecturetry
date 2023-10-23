using cleanarchitecture.Domain.Common.Models;

namespace cleanarchitecture.Domain.MenuAggregate.Entities;


public sealed class MenuItemId : Valueobject
{
    public Guid Value {get;}

    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId createUnique() 
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponent()
    {
       yield return Value;
    }
}