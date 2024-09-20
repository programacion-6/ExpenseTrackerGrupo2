namespace ExpenseTrackerGrupo2.DataAccess.Entities;

public class Budget
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required decimal BudgetAmount { get; set; }
    public required DateTime Month { get; set; }
    public Guid UserId { get; set; }
}
