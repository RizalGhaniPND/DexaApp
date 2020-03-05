using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DEXAGROUP.Models
{
    public class Outlets
    {
        public Outlets()
        {
            Customers = new HashSet<Customers>();
        }

        [Key]
        [Display(Name = "Outlet ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OutletID { get; set; }

        [Required]
        [Display(Name = "Outlet Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string OutletName { get; set; }

        public ICollection<Customers> Customers { get; set; }
    }
}
