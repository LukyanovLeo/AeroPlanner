using AeroPlanner.Models.Entities;
using Dapper;
using Db;
using AeroPlanner.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AeroPlanner.Models.Requests;

namespace AeroPlanner.Repositories
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private readonly DbClient _dbContext;

        public AppointmentsRepository(DbClient dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Appointment> GetAppointments(GetAppointmentRequest request)
        {
            var query = @"
                SELECT id, client_id, ap_datetime
                FROM public.appointment
                WHERE ap_datetime >= @start
                    AND ap_datetime <= @end
            ";
            var dp = new DynamicParameters();
            dp.Add("@start", request.Start, System.Data.DbType.DateTime);
            dp.Add("@end", request.End, System.Data.DbType.DateTime);

            return _dbContext.Query<Appointment>(query, dp).ToList();
        }

        public List<Appointment> GetAppointments()
        {
            var query = @"
                SELECT id, client_id, ap_datetime
                FROM public.appointment
            ";
            return _dbContext.Query<Appointment>(query).ToList();
        }

        public List<Appointment> GetAppointments(DateTime start)
        {
            var query = @"
                SELECT id, client_id, ap_datetime
                FROM public.appointment
                WHERE ap_datetime >= @start
            ";
            var dp = new DynamicParameters();
            dp.Add("@start", start, System.Data.DbType.DateTime);

            return _dbContext.Query<Appointment>(query, dp).ToList();
        }

        public List<WorkingHours> GetClientWorkingHours(GetClientWorkingHoursRequest request)
        {
            var query = @"
                SELECT day_of_week, start_time, end_time
                FROM public.working_hours
                WHERE client_id = @clientId 
            ";
            var dp = new DynamicParameters();
            dp.Add("@clientId", request.ClientId, System.Data.DbType.Guid);

            return _dbContext.Query<WorkingHours>(query, dp).ToList();
        }


        public Guid AddAppointmentSingle(AddAppointmentSingleRequest request)
        {
            var query = @"
                INSERT INTO public.appointment (client_id, ap_datetime)
                VALUES (@clientId, @apDatetime)
                RETURNING id
            ";
            var dp = new DynamicParameters();
            dp.Add("@clientId", request.ClientId, System.Data.DbType.Guid);
            dp.Add("@apDatetime", DateTime.Now, System.Data.DbType.DateTime);

            return _dbContext.QuerySingle<Guid>(query, dp);
        }
    }
}
