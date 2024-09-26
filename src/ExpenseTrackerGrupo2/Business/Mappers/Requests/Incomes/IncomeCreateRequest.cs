using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Incomes;

public record IncomeCreateRequest
(
    decimal Amount,
    string Source, 
    DateTime Date
)
{ 
    public Income ToModel()
    {
        return new Income
        {
            IncomeId = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            Amount = Amount,
            Source = Source,
            IncomeDate = Date
        };
    }
}
