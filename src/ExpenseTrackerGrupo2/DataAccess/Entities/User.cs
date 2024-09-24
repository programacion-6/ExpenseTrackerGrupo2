namespace ExpenseTrackerGrupo2.DataAccess.Entities;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string AccountName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public IList<Expense>? Expenses { get; set; }
    public IList<Income>? Incomes { get; set; }
    public IList<Budget>? Budgets { get; set; }
    public IList<Goal>? Goals { get; set; }
}
