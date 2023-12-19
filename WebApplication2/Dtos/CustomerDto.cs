using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        // Foreign Key define
        public byte MembershipTypeId { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}