namespace WebUI.Dtos;

public record StudentDto
{
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public Email Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string GitHubUsername { get; set; } = null!;
}

public record Email
{
    public string Value { get; set; } = null!;
}