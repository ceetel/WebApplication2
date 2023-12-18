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
        [Display(Name = "用户名")]
        public string Name { get; set; }
        
        // Foreign Key define
        [Display(Name = "账号类型")]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeModels MembershipType { get; set; }

        [Display(Name = "手机号")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}