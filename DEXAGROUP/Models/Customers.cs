using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DEXAGROUP.Models
{
    public class Customers
    {
        [Key]
        [Required(ErrorMessage = "{0} Can't be null !")]
        [Display(Name = "Customer ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CustomerID { get; set; }

        [Required(ErrorMessage = "{0} Can't be null !")]
        [Display(Name = "Customer Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string CustomerName { get; set; }

        [Display(Name = "Address")]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Address { get; set; }

        [Display(Name = "Code")]
        [StringLength(5, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Code { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Outlet")]
        [Required(ErrorMessage = "{0} Can't be null !")]
        [ForeignKey("Outlets")]
        public long? OutletId { get; set; }

        public Outlets Outlet { get; set; }
    }
}
