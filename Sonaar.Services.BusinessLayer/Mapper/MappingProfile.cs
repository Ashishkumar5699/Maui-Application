using System;
using AutoMapper;
using Sonaar.Domain.Dto;
using Sonaar.Mobile.Models.QuickSale;

namespace Sonaar.Services.BusinessLayer.Mapper
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<PrintBillModel, PrintBillDto>());
            CreateMap<PrintBillModel, PrintBillDto>();
            CreateMap<Sonaar.Mobile.Models.Client.Consumer, Sonaar.Domain.Models.Products.Consumer>();
            CreateMap<Sonaar.Mobile.Models.Sale.SaleModel, Sonaar.Domain.Bills.ProductModel>();
            CreateMap<Sonaar.Mobile.Models.Tax.GSTAmountModel, Sonaar.Domain.Bills.GSTAmount>();
        }
	}
}

