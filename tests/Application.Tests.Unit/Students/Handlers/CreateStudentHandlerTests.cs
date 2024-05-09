using Application.Students.Handlers.CommandHandlers;
using Application.Students.Commands;
using Domain.ValueObjects;
using Domain.Interfaces;
using Domain.Entities;
using NSubstitute;

namespace Application.Tests.Unit.Students.Handlers;

public class CreateStudentHandlerTests
{
    [Fact]
    public async void CreateStudentHandler_Returns_StudentResponse()
    {
        // Arrange
        var fakeRepository = Substitute.For<IStudentRepository>();

        var responseStudent = new Student
        {
            Id = 1,
            FirstName = "Sara",
            LastName = "Rasoulian",
            Email = new Email("sara@gmail.com"),
            BirthDate = new DateOnly(1900, 1, 1),
            GitHubUsername = "sara90",
        };

        fakeRepository.Add(Arg.Any<Student>()).Returns(responseStudent);

        var command = new CreateStudentCommand(
            FirstName: "Sara",
            LastName: "Rasoulian",
            BirthDate: new DateOnly(1900, 1, 1),
            Email: new Email("sara@gmail.com"),
            GitHubUsername: "sara90");

        var handler = new CreateStudentHandler(fakeRepository);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(command.FirstName, result.FirstName);
        Assert.Equal(command.Email.Value, result.Email.Value);
        await fakeRepository.Received(1).SaveChanges();
    }
}
