using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Model.products
{
    public class ProductResponseModel
    {

        public string Id { get; set; }

        public string ProviderId { get; set; }
        public string ProviderName { get; set; }

        public string ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }

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

        public int Quantity { get; set; }

        public Status Status { get; set; }

    }
}
