
using cleanarchitecture.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace cleanarchitecture.Application.Menus.Commands.CreateMenu;


public record CreateMenuCommand(
    string HostId,
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<MenU>>;

public record MenuSectionCommand(

    string Name,
    string Description,
    List<MenuItemCommand> Items);

public record MenuItemCommand(
    string Name,
    string Description);    

