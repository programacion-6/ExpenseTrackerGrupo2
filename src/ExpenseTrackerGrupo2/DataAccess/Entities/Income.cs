namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

public class Income
{
    private Guid Id { get; init; } = Guid.NewGuid();
    public required decimal Amount { get; set; }
    public required string Source { get; set; }
    public required DateTime Date { get; set; }
    private DateTime CreatedAt { get; set; }
    private Guid UserId { get; set; }

}
