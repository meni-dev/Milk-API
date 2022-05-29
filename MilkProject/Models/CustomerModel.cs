using System.ComponentModel.DataAnnotations;

namespace MilkProject.Web.Models
{
    public class CustomerModel
    {

        public string CustomerCode { get; set; }
        [MaxLength(256)]
        [Required]
        public string CustomerName { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [MaxLength(256)]
        [Required]
        public string Village { get; set; }

        [MaxLength(256)]
        public string StreetName { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
