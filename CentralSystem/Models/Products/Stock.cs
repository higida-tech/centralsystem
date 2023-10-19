namespace CentralSystem.Models
{
    public class Stock : BaseModel
    {
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public Product Product { get; set; }
    }
}
