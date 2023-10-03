namespace cleanarchitecture.Domain.Common.Models;


public abstract class Valueobject : IEquatable<Valueobject>
{
    public abstract IEnumerable<object>GetEqualityComponent();
    public override bool Equals(object? obj)
    {
    if(obj is null || obj.GetType() != GetType())
    {
        return false;
    }
      var valueobject = (Valueobject)obj;

      return GetEqualityComponent().SequenceEqual(valueobject.GetEqualityComponent());
    }

    public static bool operator == (Valueobject left,Valueobject right)
    {
        return Equals(left, right);
    }
    public static bool operator != (Valueobject left,Valueobject right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponent()
        .Select(x => x?.GetHashCode() ?? 0)
        .Aggregate((x,y) => x^y);
    }

    public bool Equals(Valueobject? other)
    {
        return  Equals((object?)other);
    }
}
// public class Price : Valueobject
// {
//    public decimal Amount {get; private set;}
//    public string Currency {get; private set;}

//    public Price(decimal amount,string currency)
//    {
//     Amount = amount;
//     Currency = currency;
//    }

 
//     public override IEnumerable<object> GetEqualityComponent()
//     {
//          yield return Amount;
//         yield return Currency;
//     }
// }