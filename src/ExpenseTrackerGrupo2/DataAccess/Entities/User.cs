namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

public class User
{
    private Guid _id;
    private string _name;
    private string _email;
    private string _passwordHash;
    private DateTime _createdAt;

    public required Guid Id
    {
        get => _id;
        set => _id = value;
    }

    public required string Name
    {
        get => _name;
        set => _name = value;
    }

    public required string Email
    {
        get => _email;
        set => _email = value;
    }

    public required string PasswordHash
    {
        get => _passwordHash;
        set => _passwordHash = value;
    }

    public required DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value;
    }
}
