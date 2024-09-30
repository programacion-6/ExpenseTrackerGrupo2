using ExpenseTrackerGrupo2.DataAccess.Entities;
using FluentValidation;

public class IncomeValidator : AbstractValidator<Income>
{
    public IncomeValidator()
    {
        RuleFor(income => income.Amount)
            .NotEmpty().WithMessage("Amount is required")
            .GreaterThan(0).WithMessage("Amount must be a positive number.");

        RuleFor(income => income.income_date)
            .NotEmpty().WithMessage("Date is required.")
            .Must(DateValidation.Validate).WithMessage("Date must be in a valid format.");

        RuleFor(income => income.Source)
            .NotEmpty().WithMessage("Source is required.")
            .MaximumLength(100);

    }
}