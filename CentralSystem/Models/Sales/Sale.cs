using SQLiteNetExtensions.Attributes;

namespace CentralSystem.Models
{
    public class Sale : BaseModel
    {
        public decimal Total { get; set; }
        public bool Paid { get; set; }
        [OneToOne]
        public User User { get; set; }
        [OneToOne]
        public Customer Customer { get; set; }
        [OneToMany]
        public List<SaleItem> Items { get; set; }
    }
}