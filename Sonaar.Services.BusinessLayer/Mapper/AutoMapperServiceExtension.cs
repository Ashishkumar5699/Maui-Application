
namespace Sonaar.Services.BusinessLayer.Mapper
{
    public static class AutoMapperServiceExtension
    {
        public static void ConfigureAutoMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}

