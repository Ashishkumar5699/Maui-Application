using SQLite;

namespace Punjab_Ornaments.Models.Approvals
{
    public class PurchaseRequest : PunjabOrnaments.Common.Approvals.PurchaseRequest
    {
        [PrimaryKey]
        [AutoIncrement]
        public int PurchaseRequestId { get; set; }
    }
}
