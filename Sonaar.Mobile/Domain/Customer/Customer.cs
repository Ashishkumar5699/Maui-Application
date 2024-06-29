using SQLite;

namespace Sonaar.Domain.Customer
{
    public class Customer : Sonaar.Common.Models.Products.Consumer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int CustmorId { get; set; }

    }
}

