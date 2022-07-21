using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroPlanner.Models.Requests
{
    public class AddAppointmentSingleResponse
    {
        public Guid Id { get; set; }

        public AddAppointmentSingleResponse() { }

        public AddAppointmentSingleResponse(Guid id)
        {
            Id = id;
        }
    }
}
