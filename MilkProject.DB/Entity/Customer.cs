using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilkProject.DB.Entity
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerCode { get; set; }

        [MaxLength(256)]
        [Required]
        public string CustomerName { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(256)]
        [Required]
        public string Village { get; set; }

        [MaxLength(256)]
        public string StreetName { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
