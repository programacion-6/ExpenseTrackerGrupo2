using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Requests.Incomes;

public record IncomeUpdateRequest
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
            Amount = Amount,
            Source = Source,
            IncomeDate = Date
        };
    }
}
