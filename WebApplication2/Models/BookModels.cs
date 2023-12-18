using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class BookModels
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "图书名")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "作者")]
        public string Author { get; set; }
        [Display(Name = "简介")]
        public string Description { get; set; }
    }
}