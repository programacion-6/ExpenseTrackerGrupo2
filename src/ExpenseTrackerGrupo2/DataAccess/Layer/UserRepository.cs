using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;
namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Layer;

public class UserRepository : IUserRepository
{
    public Task<User> ResetPasswordAsync(int code)
    {
        throw new NotImplementedException();
    }
}