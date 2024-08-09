using System;
using Sonaar.Domain.Dto;
using Sonaar.Domain.Models.Response;
using Sonaar.Mobile.Models.QuickSale;

namespace Sonaar.Services.BusinessLayer.Print
{
	public interface IPrintProvider
	{
        Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel);
    }
}

