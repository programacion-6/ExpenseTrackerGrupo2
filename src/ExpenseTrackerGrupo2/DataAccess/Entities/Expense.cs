namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

public class Expense
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required decimal Amount { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required DateTime Date;
    public DateTime CreatedAt;
    public Guid UserId { get; set; }

}
