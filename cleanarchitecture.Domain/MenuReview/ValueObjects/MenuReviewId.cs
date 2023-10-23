namespace cleanarchitecture.Domain.MenuReview.ValueObjects;


using cleanarchitecture.Domain.Common.Models;


public sealed class MenuReviewId
 : Valueobject
{
    public Guid Value {get;}

    private MenuReviewId
    (Guid value)
    {
        Value = value;
    }

    public static MenuReviewId
     createUnique() 
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponent()
    {
       yield return Value;
    }
}