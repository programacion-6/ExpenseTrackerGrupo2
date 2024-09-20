using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Users;

public record UserUpdateRequest
(
    string Name,
    string Email,
    string PasswordHash
)
{ 
    public User ToModel()
    {
        return new User
        {
            Name = Name,
            Email = Email,
            PasswordHash = PasswordHash
        };
    }
}
