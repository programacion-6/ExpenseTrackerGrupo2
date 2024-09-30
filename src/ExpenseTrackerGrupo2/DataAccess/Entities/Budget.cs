namespace ExpenseTrackerGrupo2.DataAccess.Entities;

public class Budget
{
    public Guid budget_id { get; init; } = Guid.NewGuid();
    public required decimal budget_amount { get; set; }
    public required DateTime month { get; set; }
    public Guid user_id { get; set; }
}
