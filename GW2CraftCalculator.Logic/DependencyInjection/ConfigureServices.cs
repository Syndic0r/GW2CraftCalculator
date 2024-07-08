using AutoMapper;
using GW2CraftCalculator.Interfaces.Logic;
using GW2CraftCalculator.Logic.Factories;
using GW2CraftCalculator.Models.Data;
using Gw2Sharp.WebApi.V2.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Item = GW2CraftCalculator.Models.Data.Item;
using Gw2Item = Gw2Sharp.WebApi.V2.Models.Item;
using Currency = GW2CraftCalculator.Models.Enums.Currency;
using GW2CraftCalculator.Models.ViewModels;
using GW2CraftCalculator.Interfaces.Logic;

namespace GW2CraftCalculator.Logic.DependencyInjection;

public static class ConfigureServices
{
    public static HostApplicationBuilder AddLogicServices(this HostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IGw2ClientFactory, Gw2ClientFactory>();
        builder.Services.AddSingleton<ILogicProcessor, LogicProcessor>();
        builder.Services.AddSingleton(CreateMapper);
        return builder;
    }

    private static IItemMapper CreateMapper(IServiceProvider serviceProvider)
    {
        return new ItemMapper()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemView>()
                .Include<VendorItem, ItemView>()
                .Include<VendorItemSalvageKit, SalvageKitItemView>()
                .Include<VendorItemSalvageKitInfinite, SalvageKitInfiniteItemView>();

                cfg.CreateMap<VendorItem, ItemView>()
                .ForMember(dest => dest.Cost, opt => opt.Ignore());

                cfg.CreateMap<VendorItemSalvageKit, SalvageKitItemView>()
                .ForMember(dest => dest.Cost, opt => opt.Ignore())
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(_ => 1));

                cfg.CreateMap<VendorItemSalvageKitInfinite, SalvageKitInfiniteItemView>()
                .ForMember(dest => dest.Cost, opt => opt.Ignore())
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(_ => 1));

                cfg.CreateMap<SalvageRecipeOutput, ItemView>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.OutputAmount));

                cfg.CreateMap<MysticForgeRecipeOutputAmount, ItemView>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

                cfg.CreateMap<MysticForgeRecipeInputAmount, ItemView>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

                cfg.CreateMap<Item, SalvageItemView>();

                cfg.CreateMap<VendorCost, ItemCostView>()
                .Include<VendorCost, ItemVendorCostView>();

                cfg.CreateMap<VendorCost, ItemVendorCostView>();

                cfg.CreateMap<VendorItem, ItemVendorCostView>();

                cfg.CreateMap<CommercePrice, ItemCostView>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.CurrencyType, opt => opt.MapFrom(_ => Currency.Coin));

                cfg.CreateMap<Gw2Item, ItemView>()
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rarity, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore());
            }).CreateMapper()
        };
    }
}
