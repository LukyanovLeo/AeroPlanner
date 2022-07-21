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
    public class UsersRepository : IUsersRepository
    {
        private readonly DbClient _dbContext;

        public UsersRepository(DbClient dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid AddNewUser(AddNewUserRequest request)
        {
            var query = @"
                INSERT INTO public.user (name, surname, patronymic, registration_date, scope)
                VALUES (@name, @surname, @patronymic, @registrationDate, @scope)
                RETURNING id
            ";
            var dp = new DynamicParameters();
            dp.Add("@name", request.Name, System.Data.DbType.String);
            dp.Add("@surname", request.Surname, System.Data.DbType.String);
            dp.Add("@patronymic", request.Patronymic, System.Data.DbType.String);
            dp.Add("@registrationDate", DateTime.Now, System.Data.DbType.DateTime);
            dp.Add("@scope", request.Scope, System.Data.DbType.Object);

            return _dbContext.QuerySingle<Guid>(query, dp);
        }
    }
}
