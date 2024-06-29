using System;
using Sonaar.Common.Models.Response;
using Sonaar.Mobile.Models.Prints;

namespace Sonaar.Services.BusinessLayer.Print
{
	public interface IPrintProvider
	{
        Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel);
    }
}

