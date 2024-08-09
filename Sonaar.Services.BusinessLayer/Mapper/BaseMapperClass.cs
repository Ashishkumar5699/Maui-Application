using System;
using AutoMapper;
using Sonaar.Domain.Dto;
using Sonaar.Mobile.Models.QuickSale;

namespace Sonaar.Services.BusinessLayer.Mapper
{
	public abstract class BaseMapperClass
	{
        public readonly IMapper mapper;

        public BaseMapperClass()
		{
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PrintBillModel, PrintBillDto>();
                cfg.CreateMap<Sonaar.Mobile.Models.Client.Consumer, Sonaar.Domain.Models.Products.Consumer>();
                cfg.CreateMap<Sonaar.Mobile.Models.Sale.SaleModel, Sonaar.Domain.Bills.ProductModel>();
                cfg.CreateMap<Sonaar.Mobile.Models.Tax.GSTAmountModel, Sonaar.Domain.Bills.GSTAmount>();
                //cfg.CreateMap<Bar, BarDto>();
            });

            //CreateMap<PrintBillModel, PrintBillDto>();

            // only during development, validate your mappings; remove it before release
#if DEBUG
            configuration.AssertConfigurationIsValid();
#endif
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            mapper = configuration.CreateMapper();
        }
	}
}

