using DAL.Enums;
using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public DateTime CreatedDate { get; set; }

        public Payment PaymentMethod { get; set; }

        public Status Status { get; set; }

        public string CreatedByUserId { get; set; }
        public User Users { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}