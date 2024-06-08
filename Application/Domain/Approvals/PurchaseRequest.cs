using SQLite;

namespace Punjab_Ornaments.Domain.Approvals
{
    public class PurchaseRequest : PunjabOrnaments.Common.Approvals.PurchaseRequest
    {
        [PrimaryKey]
        [AutoIncrement]
        public int PurchaseRequestId { get; set; }
    }
}
