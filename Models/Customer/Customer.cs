using SQLite;

namespace Punjab_Ornaments.Models
{
    public class Customer : PunjabOrnaments.Common.Models.Products.Consumer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int CustmorId { get; set; }

    }
}

