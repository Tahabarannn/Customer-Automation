using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FormStatus
    {
        [Key]
        public int FormStatusID { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        public ICollection<Form> Forms { get; set; }
    }
}
