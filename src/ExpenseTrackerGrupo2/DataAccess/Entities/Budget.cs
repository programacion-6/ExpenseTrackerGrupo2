namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

public class Budget
{
    private Guid _id;
    private Guid _userId;
    private decimal _budgetAmount;

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

    public required string Month { get; set; }

    public required decimal BudgetAmount
    {
        get => _budgetAmount;
        set => _budgetAmount = value;
    }
}
