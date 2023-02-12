using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        public int IsActiveID { get; set; }
        public virtual IsActive IsActive { get; set; }

        public ICollection<Affiliate> Affiliates { get; set; }

    }
}
