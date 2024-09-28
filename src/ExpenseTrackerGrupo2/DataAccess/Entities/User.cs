namespace ExpenseTrackerGrupo2.DataAccess.Entities;

public class User
{
    public Guid user_id { get; init; } = Guid.NewGuid();
    public required string Name{ get; set; }
    public required string Email { get; set; }
    public required string password_hash { get; set; }
    public DateTime CreatedAt { get; set; }
    public IList<Expense>? Expenses { get; set; }
    public IList<Income>? Incomes { get; set; }
    public IList<Budget>? Budgets { get; set; }
    public IList<Goal>? Goals { get; set; }
}
