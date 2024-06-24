using SQLite;

namespace Sonaar.Domain.Products
{
    public class Gold : Sonaar.Common.Models.Products.Gold
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        
        public Approvals.PurchaseRequest PurchaseDetais { get; set; }
    }
}
