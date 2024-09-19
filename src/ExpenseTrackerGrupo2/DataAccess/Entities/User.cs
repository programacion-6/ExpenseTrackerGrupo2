namespace ExpenseTrackerGrupo2.DataAccess.Entities;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string AccountName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public required IList<Expense> Expenses { get; set; }
    public required IList<Income> Incomes { get; set; }
    public required IList<Budget> Budgets { get; set; }
    public required IList<Goal> Goals { get; set; }
}
