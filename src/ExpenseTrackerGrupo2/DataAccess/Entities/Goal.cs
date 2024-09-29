namespace ExpenseTrackerGrupo2.DataAccess.Entities;

public class Goal
{
    public Guid goal_id { get; init; } = Guid.NewGuid();
    public required decimal goal_amount { get; set; }
    public required DateTime Deadline { get; set; }
    public required decimal current_amount { get; set; }
    public DateTime CreatedAt;
    public Guid user_id {get; set;}
}
