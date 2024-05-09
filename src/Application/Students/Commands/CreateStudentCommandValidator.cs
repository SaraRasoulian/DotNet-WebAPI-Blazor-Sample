using Domain.ValueObjects;
using Domain.Interfaces;
using FluentValidation;

namespace Application.Students.Commands;

public sealed class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    private readonly IStudentRepository _studentRepository;
    public CreateStudentCommandValidator(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;

        RuleFor(v => v.FirstName)
           .NotEmpty()
           .NotNull()
           .MaximumLength(50)
           .MinimumLength(2);

        RuleFor(v => v.LastName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50)
            .MinimumLength(2);

        RuleFor(v => v.Email)
                .MustAsync(IsEmailUnique)
                .WithMessage("'{PropertyName}' must be unique.")
                    .WithErrorCode("Unique");

        RuleFor(v => v.BirthDate)
                .LessThan(DateOnly.FromDateTime(DateTime.Now))
            .GreaterThan(DateOnly.FromDateTime(DateTime.Now.AddYears(-150)));

        RuleFor(v => v.GitHubUsername)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(40)
            .MustAsync(IsGitHubUsernameUnique)
                .WithMessage("'{PropertyName}' must be unique.")
                    .WithErrorCode("Unique");
    }

    private async Task<bool> IsEmailUnique(Email email, CancellationToken token)
    {
        return await _studentRepository.IsEmailUnique(email);
    }

    private async Task<bool> IsGitHubUsernameUnique(string gitHubUsername, CancellationToken token)
    {
        return await _studentRepository.IsGitHubUsernameUnique(gitHubUsername);
    }
}