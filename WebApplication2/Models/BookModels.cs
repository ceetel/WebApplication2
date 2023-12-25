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
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "作者")]
        [StringLength(255)]
        public string Author { get; set; }

        [Required]
        [Display(Name = "简介")]
        [StringLength(2047)]
        public string Description { get; set; }
        
        //仓库总数
        public int NumberInStock { get; set; }
        
        //可用数
        public int NumberAvailable { get; set; }
    }
}