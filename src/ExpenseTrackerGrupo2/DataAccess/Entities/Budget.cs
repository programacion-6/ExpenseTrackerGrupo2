using ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities.Interfaces;

namespace ExpenseTrackerGrupo2.src.ExpenseTrackerGrupo2.DataAccess.Entities;

public class Budget : IEntity
{
    private Guid _id;
    private Guid _userId;
    private string _month;
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

    public required string Month
    {
        get => _month;
        set => _month = value;
    }

    public required decimal BudgetAmount
    {
        get => _budgetAmount;
        set => _budgetAmount = value;
    }
}
