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

    public string Name { get; }
    public string Description { get; }

    public AverageRating AverageRating { get; }

    public IReadOnlyList<MenuSection> sections => _sections.AsReadOnly();

    public HostId HostId { get; }

    public IReadOnlyList<DinnerId> DinnerIds => (IReadOnlyList<DinnerId>)_dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => (IReadOnlyList<MenuReviewId>)_menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    private MenU(MenuId menuId, string name, string description,
       HostId hostId, DateTime createdDateTime,
       DateTime updatedDateTime) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
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
            MenuId.createUnique(), name, description, hostId, DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}