using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow.AddHours(7);
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow.AddHours(7);
    }
}
