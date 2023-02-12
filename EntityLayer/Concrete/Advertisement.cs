using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Advertisement
    {
        [Key]
        public int AdID { get; set; }
        public bool Post { get; set; }

        public DateTime Date { get; set; }

        public int AffID { get; set; }
        public virtual Affiliate Affiliate { get; set; }
    }
}
