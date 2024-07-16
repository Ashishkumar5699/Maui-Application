using System;
using Sonaar.Domain.Models.Response;
using Sonaar.Mobile.Models.Prints;

namespace Sonaar.Services.BusinessLayer.Print
{
	public interface IPrintProvider
	{
        Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel);
    }
}

