using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Salary
    {
        public string UserId { get; set; }
        public User User { get; set; }
        
        public float ToTalMoney { get; set; }

        public float? Bonus { get; set; }

    }
}
