using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Affiliate
    {
        [Key]
        public int AffID { get; set; }

        [StringLength(4)]
        public string PartnerID { get; set; }

        [StringLength(100)]
        public string AccountName { get; set; }

        [StringLength(40)]
        public string Contact { get; set; }

        [StringLength(2)]
        public string DailyPostNumber { get; set; }
        [StringLength(4)]
        public string Commission { get; set; }

        public decimal? Price { get; set; }

        [StringLength(34)]
        public string CryptoWallet { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [StringLength(1000)]
        public string SocialMediaLink { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(3)]
        public string PassedDay { get; set; }


        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }

        public int SocialMediaID { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }

        public int StatusID { get; set; }
        public virtual Status Status { get; set; }

  
        public int UserID { get; set; }
        public virtual User User { get; set; }

        public int IsActiveID { get; set; }
        public virtual IsActive IsActive { get; set; }

        public int? FraudID { get; set; }
        public virtual IsFraud IsFraud { get; set; }

        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
