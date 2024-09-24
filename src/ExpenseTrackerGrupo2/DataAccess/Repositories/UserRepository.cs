using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.Data;
using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Concretes;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) {}

    public Task<User> ResetPassword(int code)
    {
        throw new NotImplementedException();
    }
}
