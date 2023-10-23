using cleanarchitecture.Domain.MenuAggregate;

namespace cleanarchitecture.Application.Persistence;

public interface IMenuRepository
{

    void Add(MenU menu);
}