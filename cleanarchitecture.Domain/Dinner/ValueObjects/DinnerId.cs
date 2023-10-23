namespace cleanarchitecture.Domain.Dinner.ValueObjects;


using cleanarchitecture.Domain.Common.Models;


public sealed class DinnerId : Valueobject
{
    public Guid Value {get;}

    private DinnerId(Guid value)
    {
        Value = value;
    }

    public static DinnerId createUnique() 
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponent()
    {
       yield return Value;
    }
}