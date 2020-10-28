namespace DAL.Entities
{
    public class OrderDetail
    {
        public string Id { get; set; }
        public Order Order { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }
    }
}