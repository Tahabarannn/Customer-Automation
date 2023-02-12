using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }


        [StringLength(20)]
        public string Username { get; set; }

        public string Password { get; set; }

        [StringLength(25)]
        public string Skype { get; set; }

        [StringLength(25)]
        public string Telegram { get; set; }

        [StringLength(20)]
        public string ServerIp { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(60)]
        public string GoogleCaptchaToken { get; set; }


        public int IsActiveID { get; set; }
        public virtual IsActive IsActive { get; set; }
        public int AdminID { get; set; }
        public virtual Admin Admin { get; set; }
        public int? ImageID { get; set; }
        public virtual ProfileImage ProfileImage { get; set; }

        public ICollection<Affiliate> Affiliates { get; set; }
        public ICollection<Form> Forms { get; set; }
    }
}
