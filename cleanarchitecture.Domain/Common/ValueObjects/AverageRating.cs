using cleanarchitecture.Domain.Common.Models;
using cleanarchitecture.Domain.Host.ValueObjects;
using cleanarchitecture.Domain.Menu.ValueObjects;

namespace cleanarchitecture.Domain.Common.ValueObjects;

public sealed class AverageRating : Valueobject
{
    private AverageRating(double value,int numRatings)
    {
        value = value;
        numRatings = numRatings;
    }

    public double Value { get; private set;}

    public int NumRatings { get; private set;}

    public static AverageRating CreateNew(double rating = 0, int numRatings = 0)
    {
        return new AverageRating(rating, numRatings);
    }

    public void AddNewRating(AverageRating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
    }

   public void RemoveRating(AverageRating rating)
    {
        Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
    }
    public override IEnumerable<object> GetEqualityComponent()
    {
        yield return Value;
    }

   
}