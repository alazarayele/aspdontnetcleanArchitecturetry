using cleanarchitecture.Application.Menus.Commands.CreateMenu;
using cleanarchitecture.Contracts.Menus;
using MapsterMapper;
using MediatR;

namespace cleanarchitecture.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;

    private readonly ISender _mediator;


public MenusController(IMapper mapper, ISender mediator)
    {
      _mapper = mapper;
      _mediator = mediator;
    }
[HttpPost]
public async Task<IActionResult> CreateMenu(
    CreateMenuRequest request,
    string hostId)
    {
      var command = _mapper.Map<CreateMenuCommand>((request,hostId));
     
      var createMenuResult =await _mediator.Send(command);
     
      return createMenuResult.Match(
        menu => Ok(_mapper.Map<MenuResponse>(menu)),
        errors => Problem(errors)
      );  
    }
}