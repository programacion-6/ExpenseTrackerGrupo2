using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Users;

public record UserUpdateRequest
(
    string AccountName,
    string Email,
    string Password
)
{ 
    public User ToModel()
    {
        return new User
        {
            Name = AccountName,
            Email = Email,
            password_hash = Password
        };
    }
}
