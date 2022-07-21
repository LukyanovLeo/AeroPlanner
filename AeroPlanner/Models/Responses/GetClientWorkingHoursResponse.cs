using AeroPlanner.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroPlanner.Models.Responses
{
    public class GetClientWorkingHoursResponse
    {
        public List<WorkingHours> WorkingHours { get; set; }

        public GetClientWorkingHoursResponse() { }

        public GetClientWorkingHoursResponse(List<WorkingHours> workingHours)
        {
            WorkingHours = workingHours;
        }
    }
}
