using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class CustomerModels
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "UserName")]
        public string Name { get; set; }
        // Foreign Key define
        [Display(Name = "MembershipType")]
        public byte MembershipTypeId { get; set; }
        public MembershipTypeModels MembershipType { get; set; }
        [Display(Name = "Birthdate")]
        public DateTime? Birthdate { get; set; }
    }
}