using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CustomerFormViewModels
    {
        public IEnumerable<MembershipTypeModels> MembershipTypes { get; set; }
        public CustomerModels Customer { get; set; }
    }
}