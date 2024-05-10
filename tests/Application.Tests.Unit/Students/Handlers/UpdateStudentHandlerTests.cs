using Application.Students.Handlers.CommandHandlers;
using Application.Students.Commands;
using Domain.ValueObjects;
using Domain.Interfaces;
using Domain.Entities;
using NSubstitute;

namespace Application.Tests.Unit.Students.Handlers;

public class UpdateStudentHandlerTests
{
    [Fact]
    public async Task Handle_ValidUpdate_ReturnsStudentResponse()
    {
        // Arrange
        var customerId = 1;
        var updateCommand = new UpdateStudentCommand(
            Id: customerId,
            FirstName: "Sara",
            LastName: "Rasoulian",
            BirthDate: new DateOnly(1900, 1, 1),
            Email: new Email("sara@gmail.com"),
            GitHubUsername: "sara90");

        var existingStudent = new Student
        {
            Id = customerId,
            FirstName = "Sara",
            LastName = "Rasoulian",
            Email = new Email("sara@gmail.com"),
            BirthDate = new DateOnly(1900, 1, 1),
            GitHubUsername = "sara90",
        };

        var mockRepository = Substitute.For<IStudentRepository>();
        mockRepository.GetById(customerId).Returns(existingStudent);

        var handler = new UpdateStudentHandler(mockRepository);

        // Act
        await handler.Handle(updateCommand, default);

        // Assert
        mockRepository.Received(1).Update(Arg.Any<Student>());
        await mockRepository.Received(1).SaveChanges();
    }
}
