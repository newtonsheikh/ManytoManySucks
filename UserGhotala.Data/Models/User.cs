using System;
using System.Collections.Generic;
using System.Text;

namespace UserGhotala.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UPN { get; set; }
        public string DisplayName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
