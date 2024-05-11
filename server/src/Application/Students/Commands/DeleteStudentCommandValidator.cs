using FluentValidation;

namespace Application.Students.Commands;

public sealed class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentCommandValidator()
    {
        RuleFor(v => v.StudentId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}