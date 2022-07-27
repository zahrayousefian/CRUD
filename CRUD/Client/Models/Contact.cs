using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(500)]
        [Required]
        public String Address { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
    }
}
