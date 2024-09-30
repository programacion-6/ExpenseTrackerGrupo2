using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;

public record UserResponse
(
    string Name,
    string Email,
    string PasswordHash
)
{
    public static UserResponse FromDomain(User user)
    {
        return new UserResponse
        (
            user.Name,
            user.Email,
            user.password_hash
        );
    }
}
