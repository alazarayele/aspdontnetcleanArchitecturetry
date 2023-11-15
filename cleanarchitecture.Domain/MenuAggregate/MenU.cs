using cleanarchitecture.Domain.Common.Models;
using cleanarchitecture.Domain.Common.ValueObjects;
using cleanarchitecture.Domain.Dinner.ValueObjects;
using cleanarchitecture.Domain.Host.ValueObjects;
using cleanarchitecture.Domain.MenuAggregate.Entities;
using cleanarchitecture.Domain.MenuAggregate.ValueObjects;
using cleanarchitecture.Domain.MenuReview.ValueObjects;

namespace cleanarchitecture.Domain.MenuAggregate;

public sealed class MenU : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();

    private readonly List<DinnerId> _dinnerIds = new();

    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set;}
    public string Description { get; private set;}

    public AverageRating AverageRating { get; private set;}

    public IReadOnlyList<MenuSection> sections => _sections.AsReadOnly();

    public HostId HostId { get; private set; }

    public IReadOnlyList<DinnerId> DinnerIds => (IReadOnlyList<DinnerId>)_dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => (IReadOnlyList<MenuReviewId>)_menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set;}

    public DateTime UpdatedDateTime { get; private set;}

    private MenU(MenuId menuId, string name, string description,
       HostId hostId, DateTime createdDateTime,
       DateTime updatedDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        _sections = sections;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenU Create(
        string name,
        string description,
        string description1,
        HostId hostId
    )
    {
        return new(
            MenuId.createUnique(),
             name, description, 
             hostId, 
             sections ?? new(),
             DateTime.UtcNow,
            DateTime.UtcNow
        );

         
    }

    
}