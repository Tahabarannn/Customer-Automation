using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AdminRole
    {
        [Key]
        public int AdminRoleID { get; set; }

        [StringLength(12)]
        public string AdminRoleName { get; set; }

        public ICollection<Admin> Admins { get; set; }
    }
}
