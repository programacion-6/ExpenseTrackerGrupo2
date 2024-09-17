namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

public class User
{
    private Guid _id;
    private DateTime _createdAt;

    public required Guid Id
    {
        get => _id;
        set => _id = value;
    }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public required DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value;
    }
}
