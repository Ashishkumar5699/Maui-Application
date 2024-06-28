using System;
using Sonaar.Common.Models.Response;
using Sonaar.Mobile.Models.Prints;

namespace Sonaar.Mobile.Services.PrintService
{
	public interface IPrintService
	{
        public Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel);
    }
}

