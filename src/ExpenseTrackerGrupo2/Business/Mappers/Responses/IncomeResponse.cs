using ExpenseTrackerGrupo2.DataAccess.Entities;

namespace ExpenseTrackerGrupo2.Business.Services.Mappers.Responses;

public record IncomeResponse
(
    decimal Amount,
    string Source,
    DateTime IncomeDate
)
{
    public static IncomeResponse FromDomain(Income income)
    {
        return new IncomeResponse
        (
            income.Amount,
            income.Source,
            income.income_date
        );
    }
}
