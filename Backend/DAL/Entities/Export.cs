using DAL.Enums;
using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Export
    {
        public Export()
        {
            ExportDetails = new HashSet<ExportDetail>();
        }

        public string Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public DateTime ExportDate { get; set; }

        public Payment PaymentMethod { get; set; }

        public string Description { get; set; }

        public float TotalMoney { get; set; }

        public Status Status { get; set; }

        public string CreatedByUserId { get; set; }
        public User User { get; set; }

        public ICollection<ExportDetail> ExportDetails { get; set; }
    }
}