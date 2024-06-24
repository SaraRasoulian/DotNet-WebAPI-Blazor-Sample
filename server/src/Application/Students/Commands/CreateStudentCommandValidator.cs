using Domain.ValueObjects;
using Domain.Interfaces;
using FluentValidation;
using Application.Consts;

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
           .MaximumLength(StudentConsts.NameMaxLength)
           .MinimumLength(StudentConsts.NameMinLength);

        RuleFor(v => v.LastName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(StudentConsts.NameMaxLength)
            .MinimumLength(StudentConsts.NameMinLength);

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
            .MaximumLength(StudentConsts.UsernameMaxLength)
            .MinimumLength(StudentConsts.UsernameMinLength)
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