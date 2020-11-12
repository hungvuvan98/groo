using DAL.Enums;
using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Product
    {
        public Product()
        {
            ExportDetails = new HashSet<ExportDetail>();
            ImportDetails = new HashSet<ImportDetail>();
            Warehouses = new HashSet<Warehouse>();
        }

        public string Id { get; set; }

        public string ProviderId { get; set; }
        public Provider Provider { get; set; }

        public string ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public string Name { get; set; }

        public float PriceIn { get; set; }

        public float PriceOut { get; set; }

        public float? PromotionPrice { get; set; }

        public int? Wanrranty { get; set; }

        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string CreatedByUserId { get; set; }

        public string ModifiedByUserId { get; set; }

        public Status Status { get; set; }

        public ICollection<ExportDetail> ExportDetails { get; set; }

        public ICollection<ImportDetail> ImportDetails { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }
    }
}