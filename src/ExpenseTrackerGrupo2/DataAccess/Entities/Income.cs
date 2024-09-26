namespace ExpenseTrackerGrupo2.DataAccess.Entities;

public class Income
{
    public Guid IncomeId { get; set; } = Guid.NewGuid();
    public required decimal Amount { get; set; }
    public required string Source { get; set; }
    public required DateTime IncomeDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
}
