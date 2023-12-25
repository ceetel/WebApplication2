using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class RentalViewModels
    {
        public int Id { get; set; }
        [Required]
        public CustomerModels Customer { get; set; }
        [Required]
        public BookModels Book { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}