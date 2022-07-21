using AeroPlanner.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroPlanner.Models.Responses
{
    public class GetAppointmentsResponse
    {
        public List<Appointment> Appointments { get; set; }

        public GetAppointmentsResponse() { }

        public GetAppointmentsResponse(List<Appointment> appointments)
        {
            Appointments = appointments;
        }
    }
}
