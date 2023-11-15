using cleanarchitecture.Domain.Common.Models;

namespace cleanarchitecture.Domain.MenuAggregate.ValueObjects;


public sealed class MenuId : Valueobject
{
    public Guid Value { get; }

    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId createUnique()
    {
        return new(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }
    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }
}