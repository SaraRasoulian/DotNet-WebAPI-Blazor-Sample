using Application.Students.Commands;
using Application.Students.Queries;
using Domain.ValueObjects;

namespace Application.Tests.Integration.StudentHandlersTests;

public class StudentHandlersTests : BaseIntegrationTest
{
    public StudentHandlersTests(IntegrationTestWebApplicationFactory factory) : base(factory) { }

    [Fact]
    public async void GetAllStudentsHandler_Returns_StudentResponse()
    {
        // Arrange
        var query = new GetAllStudentsQuery();

        // Act
        var result = await _sender.Send(query);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async void CreateStudentCommand_Returns_StudentResponse()
    {
        // Arrange
        var command = new CreateStudentCommand(
            FirstName: "Danial",
            LastName: "Moradi",
            Email: new Email("danial@gmail.com"),
            BirthDate: new DateOnly(2000, 3, 2),
            GitHubUsername: "dani");

        // Act
        var result = await _sender.Send(command);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(command.FirstName, result.FirstName);
        Assert.Equal(command.Email, result.Email);
    }
}
