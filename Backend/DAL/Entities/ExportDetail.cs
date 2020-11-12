namespace DAL.Entities
{
    public class ExportDetail
    {
        public string ExportId { get; set; }
        public Export Export { get; set; }

        public string ProductId { get; set; }
        public string ProviderId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}