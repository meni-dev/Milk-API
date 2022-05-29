using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MilkProject.DB.Entity
{
    public class DailyMilkSupply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int MorningUnitInMilliLiter { get; set; }

        public int EveningUnitInMilliLiter { get; set; }

        [Required]
        public int BaseRatePerLitre { get; set; }

        [Required]
        public DateTime MorningEntryTime { get; set; }

        public DateTime? EveningEntryTime { get; set; }

    }
}
