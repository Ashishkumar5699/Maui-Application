using SQLite;

namespace Sonaar.Domain.Approvals
{
    public class PurchaseRequest : Sonaar.Common.Approvals.PurchaseRequest
    {
        [PrimaryKey]
        [AutoIncrement]
        public int PurchaseRequestId { get; set; }
    }
}
