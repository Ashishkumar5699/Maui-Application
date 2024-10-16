﻿using System;
using System.Xml.Serialization;
using AutoMapper;

namespace Sonaar.Services.BusinessLayer.Mapper
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Mobile to Domain

            CreateMap<Sonaar.Mobile.Models.QuickSale.PrintBillModel, Sonaar.Domain.Dto.ReportGeneration.PrintBillDto>();


            CreateMap<Sonaar.Mobile.Models.Sale.SaleModel, Sonaar.Domain.Bills.ProductModel>();

            CreateMap<Sonaar.Mobile.Models.Tax.GSTAmountModel, Sonaar.Domain.Bills.GSTAmount>();

            CreateMap<Sonaar.Mobile.Models.Client.Customer,Sonaar.Domain.Dto.CustomerDirectory.ConsumerDTO>();

            #endregion

            #region Domain to Mobile

            CreateMap<Sonaar.Domain.Entities.Contacts.ContactDetails, Sonaar.Mobile.Models.Client.Customer>();

            #endregion
        }
    }
}

