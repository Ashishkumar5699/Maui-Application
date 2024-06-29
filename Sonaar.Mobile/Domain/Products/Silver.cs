using SQLite;

namespace Sonaar.Domain.Products
{
    public class Silver : Sonaar.Common.Products.Silver
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
