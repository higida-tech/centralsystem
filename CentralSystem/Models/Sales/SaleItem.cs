using SQLiteNetExtensions.Attributes;

namespace CentralSystem.Models
{
    public class SaleItem : BaseModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [OneToOne]
        public Stock Stock { get; set; }
    }
}