namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

public class Income
{
    private Guid _id;
    private Guid _userId;
    private decimal _amount;
    private string _source;
    private DateTime _date;
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

    public required decimal Amount
    {
        get => _amount;
        set => _amount = value;
    }

    public required string Source
    {
        get => _source;
        set => _source = value;
    }

    public required DateTime Date
    {
        get => _date;
        set => _date = value;
    }

    public required DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value;
    }
}
