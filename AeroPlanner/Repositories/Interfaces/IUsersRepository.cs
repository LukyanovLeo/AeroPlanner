using AeroPlanner.Models.Entities;
using AeroPlanner.Models.Requests;
using System;
using System.Collections.Generic;

namespace AeroPlanner.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Guid AddNewUser(AddNewUserRequest request);

        //void AppointDayOfWeekRepeatedly(List<DayOfWeek> daysOfWeek, DateTime time);
    }
}
