using System;
using System.Collections.Generic;
using System.Text;

namespace UserGhotala.Data.Models
{
    public enum Name {
        Admin,
        User   
    }

    public class Role
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
