using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    /// <summary>
    /// Flight Entity
    /// </summary>
    public class Flight
    {
        public long? Id { get; set; }
        public Airport Departure { get; set; }
        public Airport Destination { get; set; }
    }
}
