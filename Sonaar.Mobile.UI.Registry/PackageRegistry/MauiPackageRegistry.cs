using System;
using CommunityToolkit.Maui;
using Sonaar.Services.BusinessLayer.Mapper;
//using AutoMapper;

namespace Sonaar.Mobile.UI.Registry.PackageRegistry
{
	public static class MauiPackageRegistry
	{
        public static MauiAppBuilder RegisterMauiPackage(this MauiAppBuilder mauiAppBuilder)
        {
            //mauiAppBuilder.UseMauiCommunityToolkit();
            //mauiAppBuilder.Services.AddAutoMapper(typeof(MappingProfile));

            return mauiAppBuilder;
        }

    }
}

