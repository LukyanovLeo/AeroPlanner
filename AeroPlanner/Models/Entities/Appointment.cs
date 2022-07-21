using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroPlanner.Models.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime ApDatetime { get; set; }
    }
}
