namespace Application.Tests.Unit.StudentHandlersTests;

public class DeleteStudentHandlerTests
{
    [Fact]
    public async Task DeleteStudentHandler_With_Valid_StudentId_Deletes_Student()
    {
        // Arrange
        var studentId = 1;
        var mockRepository = Substitute.For<IStudentRepository>();
        var student = new Student { Id = studentId };

        mockRepository.GetById(studentId).Returns(student);

        var handler = new DeleteStudentHandler(mockRepository);
        var command = new DeleteStudentCommand(studentId);

        // Act
        await handler.Handle(command, default);

        // Assert
        mockRepository.Received(1).Delete(Arg.Any<Student>());
        await mockRepository.Received(1).SaveChanges();
    }
}
