using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
using Sonaar.Services.BusinessLayer.Print;

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

