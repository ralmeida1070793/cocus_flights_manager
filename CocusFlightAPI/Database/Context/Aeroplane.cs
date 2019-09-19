using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Context
{
    /// <summary>
    /// Database Entity Aeroplane Entity For Code First
    /// </summary>
    public class Aeroplane
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public long Capacity { get; set; }

        [Required]
        public double TakeoffEffortPerOccupiedSeat { get; set; }

        [Required]
        public double FuelConsumptionPerSeat { get; set; }

        [Required]
        public double MilesToCruisingAltitude { get; set; }
    }
}
