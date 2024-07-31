using SQLite;

namespace Sonaar.Domain.Approvals
{
    //TODO: Delete this model
    public class PurchaseRequest //: Sonaar.Domain.Approvals.PurchaseRequest
    {
        [PrimaryKey]
        [AutoIncrement]
        public int PurchaseRequestId { get; set; }
    }
}
