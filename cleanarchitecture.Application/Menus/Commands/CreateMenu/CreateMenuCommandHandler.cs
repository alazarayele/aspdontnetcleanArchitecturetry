using cleanarchitecture.Application.Menus.Commands.CreateMenu;
using cleanarchitecture.Domain.Host.ValueObjects;
using cleanarchitecture.Domain.MenuAggregate;
using cleanarchitecture.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace cleanarchitecture.Application.Menu.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<MenU>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository  = menuRepository;
    }
    public async Task<ErrorOr<MenU>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {

        await Task.CompletedTask;
        var menu = MenU.Create(
               
                name:request.Name,
                hostId:HostId.Create(request.HostId),
               description1:request.Description,
                 
                request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    
                    section.Items.ConvertAll(item => MenuItem.Create(
                        item.Name,
                        item.Description
                    ))))
                    );
      _menuRepository.Add(menu);
        return menu;
    }
}