using SQLite;

namespace Punjab_Ornaments.Models.Products
{
    public class Silver : PunjabOrnaments.Common.Products.Silver
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
