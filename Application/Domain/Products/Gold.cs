using SQLite;

namespace Punjab_Ornaments.Domain.Products
{
    public class Gold : PunjabOrnaments.Common.Models.Products.Gold
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        
        public Approvals.PurchaseRequest PurchaseDetais { get; set; }
    }
}
