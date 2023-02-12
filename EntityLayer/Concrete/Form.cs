using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Form
    {
        [Key]
        public int FormID { get; set; }

        public DateTime? FormDate { get; set; }

        [StringLength(100)]
        public string AffMail { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(1000)]
        public string SocialMediaLink { get; set; }

        [StringLength(1000)]
        public string WorkType { get; set; }

        [StringLength(100)]
        public string Price { get; set; }

        [StringLength(1000)]
        public string Explanation { get; set; }

        [StringLength(100)]
        public string Reference { get; set; }

        [StringLength(50)]
        public string SocialMedia { get; set; }


        public int? UserID { get; set; }
        public virtual User User { get; set; }

        public int? AdminID { get; set; }
        public virtual Admin Admin { get; set; }

        public int IsActiveID { get; set; }
        public virtual IsActive IsActive { get; set; }

        public int? FormStatusID { get; set; }
        public virtual FormStatus FormStatus { get; set; }

    }
}
