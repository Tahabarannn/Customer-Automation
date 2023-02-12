using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaID { get; set; }

        [StringLength(30)]
        public string SocialMediaPlatform { get; set; }

        public int IsActiveID { get; set; }
        public virtual IsActive IsActive { get; set; }

        public ICollection<Affiliate> Affiliates { get; set; }
        public ICollection<Form> Forms { get; set; }
    }
}
