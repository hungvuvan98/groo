using DAL.Enums;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatedDate { get; set; }

        public string ModifiedDate { get; set; }

        public ICollection<Product> Products { get; set; }

        public Status Status { get; set; }
    }
}
