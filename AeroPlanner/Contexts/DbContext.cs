using Db;
using Microsoft.Extensions.Options;
using AeroPlanner.Models.Settings;
using AeroPlanner.Repositories;
using AeroPlanner.Repositories.Interfaces;

namespace AeroPlanner.Contexts
{
    public class DbContext : IDbContext
    {
        private readonly DbClient _dbContext;
        private IAppointmentsRepository _appointmentsRepository;
        private IUsersRepository _usersRepository;

        public DbContext(IOptions<AppSettings> appSettings)
        {
            _dbContext = new DbClient(appSettings.Value.ConnectionString);
        }

        public IAppointmentsRepository AppointmentsRepository
        {
            get
            {
                return _appointmentsRepository = _appointmentsRepository ?? new AppointmentsRepository(_dbContext);
            }
        }


        public IUsersRepository UsersRepository
        {
            get
            {
                return _usersRepository = _usersRepository ?? new UsersRepository(_dbContext);
            }
        }
    }
}
