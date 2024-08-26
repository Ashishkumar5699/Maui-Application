using Sonaar.Domain.Response;
using Sonaar.Mobile.Models.QuickSale;

namespace Sonaar.Services.BusinessLayer.Print
{
    public interface IPrintProvider
	{
        Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel);
    }
}

