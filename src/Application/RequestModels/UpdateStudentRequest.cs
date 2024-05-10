using Domain.ValueObjects;

namespace Application.RequestModels;

public record UpdateStudentRequest(long Id, string FirstName, string LastName, Email Email,
    DateOnly BirthDate, string GitHubUsername);