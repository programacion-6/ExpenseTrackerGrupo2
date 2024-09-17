namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

public class Goal
{
    private Guid _id;
    private Guid _userId;
    private decimal _goalAmount;
    private DateTime _deadline;
    private decimal _currentAmount;
    private DateTime _createdAt;

    public required Guid Id
    {
        get => _id;
        set => _id = value;
    }

    public required Guid UserId
    {
        get => _userId;
        set => _userId = value;
    }

    public required decimal GoalAmount
    {
        get => _goalAmount;
        set => _goalAmount = value;
    }

    public required DateTime Deadline
    {
        get => _deadline;
        set => _deadline = value;
    }

    public required decimal CurrentAmount
    {
        get => _currentAmount;
        set => _currentAmount = value;
    }

    public required DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value;
    }
}
