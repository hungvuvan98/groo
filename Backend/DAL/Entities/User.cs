using DAL.Enums;
using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User
    {
        public User()
        {
            Exports = new HashSet<Export>();
            Imports= new HashSet<Import>();
            UserRoles = new HashSet<UserRole>();
            Salaries = new HashSet<Salary>();
        }

        public string Id { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime Birthday { get; set; }

        public Status Status { get; set; }

        public ICollection<Export> Exports { get; set; }

        public ICollection<Import> Imports { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<Salary> Salaries { get; set; }
    }
}