using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Role
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

        public string Status { get; set; }
    }
}
