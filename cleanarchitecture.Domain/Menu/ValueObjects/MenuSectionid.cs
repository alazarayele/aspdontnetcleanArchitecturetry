using cleanarchitecture.Domain.Common.Models;

namespace cleanarchitecture.Domain.Menu.ValueObjects;


public sealed class MenuSectionId : Valueobject
{
    public Guid Value {get;}

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId createUnique() 
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponent()
    {
       yield return Value;
    }
}