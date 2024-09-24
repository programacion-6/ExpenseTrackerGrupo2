using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Concretes;
public interface IUserRepository : IBaseRepository<User>
{
    Task<User> ResetPassword(int code);
}
