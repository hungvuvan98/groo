namespace DAL.Entities
{
    public class ImportDetail
    {
        public string ImportId { get; set; }
        public Import Import { get;set; }

        public string ProviderId { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
