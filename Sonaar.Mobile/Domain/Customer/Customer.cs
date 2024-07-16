using SQLite;

namespace Sonaar.Domain.Customer
{
    public class Customer : Sonaar.Domain.Models.Products.Consumer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int CustmorId { get; set; }

    }
}

