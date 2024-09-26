using FluentValidation;
using ExpenseTrackerGrupo2.DataAccess.Entities;

public class ExpenseValidator : AbstractValidator<Expense>
{
    public ExpenseValidator()
    {
        RuleFor(expense => expense.Amount)
            .NotEmpty().WithMessage("Amount is required")
            .GreaterThan(0).WithMessage("Amount must be a positive number.");

        RuleFor(expense => expense.Date)
            .NotEmpty().WithMessage("Date is required.")
            .Must(BeAValidDate).WithMessage("Date must be in the format yyyy-mm-dd.");

        RuleFor(expense => expense.Category)
            .NotEmpty().WithMessage("Category is required.")
            .MaximumLength(100);

        RuleFor(expense => expense.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(255);

    }

    private bool BeAValidDate(DateTime date)
    {
        return date != default(DateTime);
    }
}
