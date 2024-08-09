using AutoMapper;
using Sonaar.Domain.Dto;
using Sonaar.Domain.Models.Response;
using Sonaar.Mobile.Models.QuickSale;
using Sonaar.Mobile.RestBridge.RestService;
using Sonaar.Mobile.RestBridge.Urls;

namespace Sonaar.Services.BusinessLayer.Print
{
    public class PrintProvider: IPrintProvider//BaseMapperClass, IPrintProvider
    {
        private readonly IRestService _restService;
        private readonly IMapper _mapper;

        public PrintProvider(IRestService restService, IMapper mapper)
        {
            _restService = restService;
            _mapper = mapper;
        }

        public async Task<ResponseResult<byte[]>> GenerateQuotation(PrintBillModel printBillModel)
        {
            printBillModel.FirmDetail = new Domain.Models.Company.FirmDetail
            {
                FirmName = "FirmName",
                FirmAddress = "FirmAddress",
                FirmGSTNumber = "FirmGSTNumber",
                FirmPhoneNumber = "FirmPhoneNumber",
            };

            var printBillDto = _mapper.Map<PrintBillDto>(printBillModel);
            //var printBillDto = new object();
            //var data = new MemoryStream().ToArray();
            var response = new ResponseResult<byte[]>
            {
                HasErrors = true,
                IsSystemError = true,
            };

            response = await _restService.PostAsync(ApiConstant.GenerateQuote, printBillDto, response);
            response.Message ??= "Opening Pdf";
            return response;
        }
    }

    //public static class Extension
    //{
    //    public static PrintBillDto ToPrintBillDto(this PrintBillModel printBillModel)
    //    {
    //        return new PrintBillDto
    //        {
    //            Consumer = new Domain.Models.Products.Consumer
    //            {
    //                CustmorPrifix = CustmorDetail.CustmorPrifix,
    //                CustmorFirstName = CustmorDetail.CustmorFirstName,
    //                CustmorLastName = CustmorDetail.CustmorLastName,
    //                CustmorPhoneNumber = CustmorDetail.CustmorPhoneNumber,
    //                CustmorAddress1 = CustmorDetail.CustmorAddress1,
    //                CustmorAddress2 = CustmorDetail.CustmorAddress2,
    //                CustmorLandMark = CustmorDetail.CustmorLandMark,
    //                CustmorCity = CustmorDetail.CustmorCity,
    //                CustmorState = CustmorDetail.CustmorState,
    //                CustmorPinCode = CustmorDetail.CustmorPinCode
    //            },

    //            DateofBill = DateTime.Today,
    //            BillType = Domain.Enum.BillType.Quotation,
    //            ProductList = new List<Domain.Bills.ProductModel>(),
    //            GSTAmount = new Domain.Bills.GSTAmount(),
    //            FirmDetail = new Domain.Models.Company.FirmDetail
    //            {
    //                FirmName = "FirmName",
    //                FirmAddress = "FirmAddress",
    //                FirmGSTNumber = "FirmGSTNumber",
    //                FirmPhoneNumber = "FirmPhoneNumber",
    //            },

    //        };
    //    }

    //    public static Domain.Models.Products.Consumer ToConsumer(this )
    //}
}

