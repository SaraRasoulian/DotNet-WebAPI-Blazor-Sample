using Domain.ValueObjects;

namespace Application.ResponseModels;

public record StudentResponse(long Id, string FirstName, string LastName, Email Email, DateOnly BirthDate, string GitHubUsername);