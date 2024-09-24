using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Users;

public record UserCreateRequest
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
            AccountName = AccountName,
            Email = Email,
            Password = Password
        };
    }
}
