using Application.ResponseModels;
using Domain.ValueObjects;
using MediatR;

namespace Application.Students.Commands;

public record CreateStudentCommand(string FirstName, string LastName, Email Email, DateOnly BirthDate,
    string GitHubUsername) : IRequest<StudentResponse>;
