using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }

        [StringLength(50)]
        public string AdminPassword { get; set; }

        [StringLength(50)]
        public string AdminSkype{ get; set; }

        [StringLength(50)]
        public string AdminTelegram { get; set; }

        [StringLength(20)]
        public string ServerIp { get; set; }

        [StringLength(60)]
        public string GoogleCaptchaToken { get; set; }


        public int IsActiveID { get; set; }
        public virtual IsActive IsActive { get; set; }

        public int AdminRoleID { get; set; }
        public virtual AdminRole AdminRole { get; set; }

        public int? ImageID { get; set; }
        public virtual ProfileImage ProfileImage { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
