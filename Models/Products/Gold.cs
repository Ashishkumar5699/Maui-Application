using SQLite;

namespace Punjab_Ornaments.Models
{
    public class Gold : PunjabOrnaments.Common.Models.Products.Gold
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        
        public Approvals.PurchaseRequest PurchaseDetais { get; set; }
    }
}
