using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        [StringLength(25)]
        public string Product { get; set; }

        public int IsActiveID { get; set; }
        public virtual IsActive IsActive { get; set; }

        public ICollection<Affiliate> Affiliates { get; set; }
    }
}
