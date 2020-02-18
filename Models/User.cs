using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleWebApp.Models
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Initials { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
