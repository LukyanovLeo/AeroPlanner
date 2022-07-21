using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using AeroPlanner.Contexts;
using Microsoft.AspNetCore.Authorization;
using AeroPlanner.Models.Responses;
using AeroPlanner.Models.Requests;

namespace AeroPlanner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IDbContext _dbContext;

        public AppointmentController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("getAppointments")]
        public GetAppointmentsResponse GetAppointments([FromBody] GetAppointmentRequest request)
        {
            return new GetAppointmentsResponse(_dbContext.AppointmentsRepository.GetAppointments(request).ToList());
        }

        [HttpPost("getClientWorkingHours")]
        public GetClientWorkingHoursResponse GetClientWorkingHours([FromBody] GetClientWorkingHoursRequest request)
        {
            return new GetClientWorkingHoursResponse(_dbContext.AppointmentsRepository.GetClientWorkingHours(request).ToList());
        }


        [HttpPost("addAppointmentSingle")]
        public AddAppointmentSingleResponse AddAppointmentSingle([FromBody] AddAppointmentSingleRequest request)
        {
            return new AddAppointmentSingleResponse(_dbContext.AppointmentsRepository.AddAppointmentSingle(request));
        }
    }
}
