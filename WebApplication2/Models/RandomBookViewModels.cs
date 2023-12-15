using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RandomBookViewModels
    {
        public BookModels Book {  get; set; }
        public List<CustomerModels> Custormers { get; set; }
    }
}