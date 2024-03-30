using Punjab_Ornaments.Models;
using Punjab_Ornaments.Models.Approvals;
using Punjab_Ornaments.Models.Auth;
using Punjab_Ornaments.Models.Products.Details;
using Punjab_Ornaments.Resources.Constant;
using PunjabOrnaments.Common.Models.Response;
using SQLite;

namespace Punjab_Ornaments.Infrastructure.Database
{
    public partial class SQLiteDataService : IDataService
    {
        #region initialization
        private static readonly Lazy<SQLiteAsyncConnection> LazyInitializer = new(() =>
        {
            return new SQLiteAsyncConnection(DatabaseConstant.DatabasePath, DatabaseConstant.Flags);
        });
        private static SQLiteAsyncConnection Database => LazyInitializer.Value;

        public void Initialize()
        {
            var database = new SQLiteConnection(DatabaseConstant.DatabasePath);
            CreateTables(database);
        }
        private static void CreateTables(SQLiteConnection database)
        {
            database.CreateTable<Customer>();
            database.CreateTable<Gold>();
            database.CreateTable<Models.Auth.LoginUser>();
            //database.CreateTable<Purchase>();
            //database.CreateTable<MetelType>();
            database.CreateTable<Discriptions>();
        }
        #endregion

        public Task<int> AddBrand(Discriptions brand)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddGoldinStock(Gold gold)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddMetalType(Discriptions metelType)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddPurchase(PurchaseRequest Purchaseitem)
        {
            throw new NotImplementedException();
        }

        public Task<int> ApprovedPurchase(int purchaseid, int isapproved)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteBrand(Discriptions brand)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteGoldFromStock(Gold gold)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteMetalType(Discriptions metelType)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeletePurchase(PurchaseRequest Purchaseitem)
        {
            throw new NotImplementedException();
        }

        public Task<List<Discriptions>> GetAllBrand()
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetAllCompletePurchaseRequests()
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetAllCompletePurchases()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<List<Gold>> GetAllGoldStock()
        {
            throw new NotImplementedException();
        }

        public Task<List<Discriptions>> GetAllMetalType()
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetAllPendingPurchaseRequests()
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetAllPendingPurchases()
        {
            throw new NotImplementedException();
        }

        public Task<List<Discriptions>> GetBrandByMetalType(string metalType)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomerByPhone(int phone)
        {
            throw new NotImplementedException();
        }

        public Task<List<Gold>> GetGoldStockById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetPurchaseById(int purchaseid)
        {
            throw new NotImplementedException();
        }

        public Task<List<PurchaseRequest>> GetTodaysPurchase()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCustpmer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateGoldinStock(Gold gold)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePurchase(PurchaseRequest Purchaseitem)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResult<LoginUser>> LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
    //    #region Gold
    //    public async Task<int> AddGoldinStock(Gold gold) => await Database.InsertAsync(gold);
    //    public async Task<int> UpdateGoldinStock(Gold gold) => await Database.UpdateAsync(gold);
    //    public async Task<int> DeleteGoldFromStock(Gold gold) => await Database.DeleteAsync(gold);
    //    public async Task<List<Gold>> GetAllGoldStock() => await Database.QueryAsync<Gold>("SELECT * FROM Gold");
    //    public async Task<List<Gold>> GetGoldStockById(int id) => await Database.QueryAsync<Gold>($"SELECT * FROM Gold WHERE Id = '{id}'");
    //    #endregion

    //    #region Approval Section
    //    public async Task<List<Purchase>> GetAllPendingPurchaseRequests() => await Database.QueryAsync<Purchase>($"SELECT * FROM Purchase WHERE IsApproved={null}");

    //    public async Task<List<Purchase>> GetAllCompletePurchaseRequests() => await Database.QueryAsync<Purchase>($"SELECT * FROM Purchase WHERE IsApproved!={null}");
    //    #endregion

    //    #region Customer
    //    public async Task<int> AddCustomer(Customer custmor) => await Database.InsertAsync(custmor);
    //    public async Task<int> UpdateCustpmer(Customer custmor) => await Database.UpdateAsync(custmor);
    //    public async Task<int> DeleteCustomer(Customer custmor) => await Database.DeleteAsync(custmor);
    //    public async Task<List<Customer>> GetAllCustomers() => await Database.QueryAsync<Customer>("SELECT * FROM Customer");
    //    public async Task<List<Customer>> GetCustomerByPhone(int phoneNumber) => await Database.QueryAsync<Customer>($"SELECT * FROM Customer WHERE CustmorPhoneNumber = '{phoneNumber}'");
    //    #endregion

    //    #region Approve Purchase
    //    public async Task<int> AddPurchase(Models.Approvals.PurchaseRequest Purchaseitem) => await Database.InsertAsync(Purchaseitem);
    //    public async Task<int> UpdatePurchase(Models.Approvals.PurchaseRequest Purchaseitem) => await Database.UpdateAsync(Purchaseitem);
    //    public async Task<int> DeletePurchase(Models.Approvals.PurchaseRequest Purchaseitem) => await Database.DeleteAsync(Purchaseitem);
    //    public async Task<List<Models.Approvals.PurchaseRequest>> GetAllPendingPurchases() => await Database.QueryAsync<Models.Approvals.PurchaseRequest>("SELECT * FROM Purchase");
    //    public async Task<List<Models.Approvals.PurchaseRequest>> GetAllCompletePurchases() => await Database.QueryAsync<Models.Approvals.PurchaseRequest>("SELECT * FROM Purchase WHERE IsApproved = 1");
    //    public async Task<List<Models.Approvals.PurchaseRequest>> GetTodaysPurchase() => await Database.QueryAsync<Models.Approvals.PurchaseRequest>($"SELECT * FROM Customer WHERE PurchaseDate = '{DateTime.Today.Date}'");
    //    public async Task<List<Models.Approvals.PurchaseRequest>> GetPurchaseById(int purchaseRequestId) => await Database.QueryAsync<Models.Approvals.PurchaseRequest>($"SELECT * FROM Purchase WHERE PurchaseRequestId = '{purchaseRequestId}' ");
    //    public async Task<int> ApprovedPurchase(int purchaseRequestId, int isapproved) => await Database.ExecuteAsync($"UPDATE Purchase SET IsApproved = {isapproved} WHERE PurchaseRequestId = '{purchaseRequestId}'");
    //    #endregion

    //    #region MetalTypes
    //    //public async Task<int> AddMetalType(MetelType metelType) => await Database.InsertAsync(metelType);

    //    //public async Task<int> DeleteMetalType(MetelType metelType) => await Database.DeleteAsync(metelType);

    //    //public async Task<List<MetelType>> GetAllMetalType() => await Database.QueryAsync<MetelType>("SELECT * FROM MetelType");
    //    #endregion

    //    #region Brands
    //    public async Task<int> AddBrand(Discriptions brand) => await Database.InsertAsync(brand);

    //    public async Task<int> DeleteBrand(Discriptions brand) => await Database.DeleteAsync(brand);

    //    public async Task<List<Discriptions>> GetAllBrand() => await Database.QueryAsync<Discriptions>("SELECT * FROM Brand");

    //    public async Task<List<Discriptions>> GetBrandByMetalType(string metalType) => await Database.QueryAsync<Discriptions>($"SELECT * FROM Brand WHERE MetalType = '{metalType}'");

    //    Task<List<PurchaseRequest>> IDataService.GetAllPendingPurchaseRequests()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task<List<PurchaseRequest>> IDataService.GetAllCompletePurchaseRequests()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    #endregion
    //}