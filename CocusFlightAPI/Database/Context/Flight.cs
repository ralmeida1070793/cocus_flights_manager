using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Context
{
    /// <summary>
    /// Database Entity Flight Entity For Code First
    /// </summary>
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long OriginId { get; set; }
        [Required]
        public long DestinationId { get; set; }
    }
}
