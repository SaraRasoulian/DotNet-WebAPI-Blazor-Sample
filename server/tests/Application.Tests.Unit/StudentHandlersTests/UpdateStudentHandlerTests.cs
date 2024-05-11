namespace Application.Tests.Unit.StudentHandlersTests;

public class UpdateStudentHandlerTests
{
    [Fact]
    public async Task UpdateStudentHandler_Returns_StudentResponse()
    {
        // Arrange
        var studentId = 1;
        var updateCommand = new UpdateStudentCommand(
            Id: studentId,
            FirstName: "Sara",
            LastName: "Rasoulian",
            BirthDate: new DateOnly(1900, 1, 1),
            Email: new Email("sara@gmail.com"),
            GitHubUsername: "sara90");

        var existingStudent = new Student
        {
            Id = studentId,
            FirstName = "Sara",
            LastName = "Rasoulian",
            Email = new Email("sara@gmail.com"),
            BirthDate = new DateOnly(1900, 1, 1),
            GitHubUsername = "sara90",
        };

        var mockRepository = Substitute.For<IStudentRepository>();
        mockRepository.GetById(studentId).Returns(existingStudent);

        var handler = new UpdateStudentHandler(mockRepository);

        // Act
        await handler.Handle(updateCommand, default);

        // Assert
        mockRepository.Received(1).Update(Arg.Any<Student>());
        await mockRepository.Received(1).SaveChanges();
    }
}
