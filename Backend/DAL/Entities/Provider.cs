using DAL.Enums;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Provider
    {
        public Provider()
        {
            Products = new HashSet<Product>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Status Status { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}