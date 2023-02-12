using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProfileImage
    {
        [Key]
        public int ImageID { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Admin> Admins { get; set; }
    }
}
