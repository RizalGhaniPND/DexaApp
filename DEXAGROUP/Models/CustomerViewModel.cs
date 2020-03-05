using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEXAGROUP.Models
{
    public class CustomerViewModel
    {
        public Customers Customer { get; set; }
        public ICollection<Customers> ListCustomer { get; set; }
    }
}
