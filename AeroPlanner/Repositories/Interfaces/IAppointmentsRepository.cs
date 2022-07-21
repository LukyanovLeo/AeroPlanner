using AeroPlanner.Models.Entities;
using AeroPlanner.Models.Requests;
using System;
using System.Collections.Generic;

namespace AeroPlanner.Repositories.Interfaces
{
    public interface IAppointmentsRepository
    {
        List<Appointment> GetAppointments(GetAppointmentRequest request);
        List<Appointment> GetAppointments();
        List<Appointment> GetAppointments(DateTime start);
        List<WorkingHours> GetClientWorkingHours(GetClientWorkingHoursRequest request);
        Guid AddAppointmentSingle(AddAppointmentSingleRequest request);
    }
}
