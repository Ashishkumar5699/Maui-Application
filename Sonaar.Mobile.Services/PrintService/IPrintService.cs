using System;
using Sonaar.Domain.Dto;
using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.QuickSale;

namespace Sonaar.Mobile.Services.PrintService
{
	public interface IPrintService
	{
        public Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel);
    }
}

