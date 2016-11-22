using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBlogSitesi.Models.ORM.Entity
{
    public class AdminUser :BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [StringLength(30)]
        public string  EMail { get; set; }
        [Required]
        [StringLength(32)]
        public string Password { get; set; }
    }
}