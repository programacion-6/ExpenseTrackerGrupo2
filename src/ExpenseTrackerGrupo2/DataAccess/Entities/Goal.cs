namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

public class Goal
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required decimal GoalAmount { get; set; }
    public required DateTime Deadline { get; set; }
    public required decimal CurrentAmount { get; set; }
    public DateTime CreatedAt;
    public Guid UserId;
}
