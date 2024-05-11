using Domain.ValueObjects;

namespace Application.RequestModels;

public record CreateStudentRequest(string FirstName, string LastName, Email Email, DateOnly BirthDate, string GitHubUsername);