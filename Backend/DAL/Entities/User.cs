using DAL.Enums;
using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public string Id { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime Birthday { get; set; }

        public Status Status { get; set; }

        public string Role { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}