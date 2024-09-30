namespace ExpenseTrackerGrupo2.DataAccess.Entities;

public class Income
{
    public Guid income_id { get; init; } = Guid.NewGuid();
    public required decimal Amount { get; set; }
    public required string Source { get; set; }
    public required DateTime income_date { get; set; }
    private DateTime CreatedAt { get; set; }
    public Guid user_id { get; set; }

}
