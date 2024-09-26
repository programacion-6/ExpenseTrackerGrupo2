namespace ExpenseTrackerGrupo2.DataAccess.Entities;

public class Expense
{
    public Guid expense_id { get; set; } = Guid.NewGuid();
    public required decimal Amount { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required DateTime expense_date {get; set;}
    public DateTime CreatedAt;
    public Guid user_id { get; set; }
}
