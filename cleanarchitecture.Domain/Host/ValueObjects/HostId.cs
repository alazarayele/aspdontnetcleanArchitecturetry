namespace cleanarchitecture.Domain.Host.ValueObjects;


using cleanarchitecture.Domain.Common.Models;


public sealed class HostId : Valueobject
{
    public Guid Value {get;}

    private HostId(Guid value)
    {
        Value = value;
    }

    public static HostId Create(HostId value) 
    {

        
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponent()
    {
       yield return Value;
    }
}