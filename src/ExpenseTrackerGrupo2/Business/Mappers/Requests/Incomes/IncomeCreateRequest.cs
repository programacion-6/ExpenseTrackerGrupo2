using System.Dynamic;

using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Incomes;

public record IncomeCreateRequest
(
    decimal Amount,
    string Source, 
    DateTime Date,
    Guid User
)
{ 
    public Income ToModel()
    {
        return new Income
        {
            Amount = Amount,
            Source = Source,
            income_date = Date,
            user_id = User
        };
    }
}
