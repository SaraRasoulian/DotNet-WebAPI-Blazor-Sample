using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public record Student : EntityBase
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public Email Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string GitHubUsername { get; set; } = null!;
}