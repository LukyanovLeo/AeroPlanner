using AeroPlanner.Repositories.Interfaces;

namespace AeroPlanner.Contexts
{
    public interface IDbContext
    {
        IAppointmentsRepository AppointmentsRepository { get; }
        IUsersRepository UsersRepository { get; }
    }
}
