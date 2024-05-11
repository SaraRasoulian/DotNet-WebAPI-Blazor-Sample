using System.ComponentModel.DataAnnotations;

namespace WebUI.Dtos;

public record StudentDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Special characters are not accepted")]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    [MaxLength(50, ErrorMessage = "First name must be at most 50 characters")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Special characters are not accepted")]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    [MaxLength(50, ErrorMessage = "Last name must be at most 50 characters")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    public Email Email { get; set; } = null!;

    [Required(ErrorMessage = "Birth date is required")]
    public DateOnly BirthDate { get; set; }

    [Required(ErrorMessage = "GitHub username is required")]
    [RegularExpression(@"^[a-zA-Z0-9\-]+$", ErrorMessage = "Special characters are not accepted")]
    [MinLength(3, ErrorMessage = "GitHub username must be at least 3 characters")]
    [MaxLength(40, ErrorMessage = "GitHub username must be at most 40 characters")]
    public string GitHubUsername { get; set; } = null!;
}

public record Email
{
    public string Value { get; set; } = null!;
}