using cleanarchitecture.Application.Menus.Commands.CreateMenu;
using cleanarchitecture.Contracts.Menus;
using cleanarchitecture.Domain.MenuAggregate;
using Mapster;
using MenuSection  = cleanarchitecture.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = cleanarchitecture.Domain.MenuAggregate.Entities.MenuItem; 
namespace cleanarchitecture.Api.Common.Mapping;


public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
        .Map(dest => dest.HostId, src => src.HostId)
        .Map(dest => dest, src => src.Request);

        config.NewConfig<MenU,MenuResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(dest => dest.AverageRating,src => src.AverageRating.Value)
        .Map(dest => dest.HostId, src => src.HostId.Value)
        .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
        .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(menuId => menuId.Value))
   ;

           config.NewConfig<MenuSection,MenuSectionResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);
    
          config.NewConfig<MenuItem,MenuItemResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

       
       
    }
}
