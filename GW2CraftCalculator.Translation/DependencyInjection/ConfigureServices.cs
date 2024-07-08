using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Interfaces.Translation;
using GW2CraftCalculator.Models.Enums;
using GW2CraftCalculator.Translation.Converters;
using GW2CraftCalculator.Utils.Converters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GW2CraftCalculator.Translation.DependencyInjection;
public static class ConfigureServices
{
    public static HostApplicationBuilder AddTranslationServices(this HostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ILanguageConverter, LanguageConverter>();
        builder.Services.AddSingleton<ITranslationsProcessor, TranslationsProcessor>();
        builder.Services.AddSingleton<ITranslationCodeConverter, TranslationCodeConverter>();
        builder.Services.AddSingleton<IItemGroupConverter, ItemGroupConverter>();
        builder.Services.AddSingleton<IItemTypeConverter, ItemTypeConverter>();
        builder.Services.AddSingleton<IRarityConverter, RarityConverter>();
        builder.Services.AddSingleton(CreateMapper);
        return builder;
    }
    private static IEnumMapper CreateMapper(IServiceProvider serviceProvider)
    {
        return new EnumMapper()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemGroup, TranslationCode>().ConvertUsingEnumMapping(opt => opt.MapByName());
                cfg.CreateMap<ItemType, TranslationCode>().ConvertUsingEnumMapping(opt => opt.MapByName());
                cfg.CreateMap<Rarity, TranslationCode>().ConvertUsingEnumMapping(opt => opt.MapByName());
            }).CreateMapper()
        };
    }
}
