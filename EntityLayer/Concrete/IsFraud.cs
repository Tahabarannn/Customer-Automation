using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class IsFraud
    {
        [Key]
        public int FraudId { get; set; }

        [StringLength(5)]
        public string Fraud { get; set; }

        public ICollection<Affiliate> Affiliates { get; set; }
    }
}
