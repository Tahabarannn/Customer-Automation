using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class IsActive
    {
        [Key]
        public int IsActiveID { get; set; }

        [StringLength(10)]
        public string Active { get; set; }

        public ICollection<Affiliate> Affiliates { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<Form> Forms { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }
        public ICollection<Status> Statuses { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
