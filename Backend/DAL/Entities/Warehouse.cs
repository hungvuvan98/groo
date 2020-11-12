using DAL.Enums;

namespace DAL.Entities
{
    public class Warehouse
    {
        public string ProductId { get; set; }
        public string ProviderId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public Status Status { get; set; }
    }
}
