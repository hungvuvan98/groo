using DAL.Enums;
using System;
using System.Collections.Generic;
namespace DAL.Entities
{
    public class Import
    {
        public Import()
        {
            ImportDetails = new HashSet<ImportDetail>();
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public DateTime? ImportDate { get; set; }

        public float TotalMoney { get; set; }

        public string CreatedByUserId { get; set; }
        public User User { get; set; }

        public ICollection<ImportDetail> ImportDetails { get; set; }

        public Status Status { get; set; }
    }
}
