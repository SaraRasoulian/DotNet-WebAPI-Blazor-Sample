namespace Application.Tests.Unit.StudentHandlersTests;

public class GetStudentByIdHandlerTests
{
    [Fact]
    public async Task GetStudentByIdHandler_With_ValidId_Returns_StudentResponse()
    {
        // Arrange
        var studentId = 1;
        var fakeStudent = new Faker<Student>()
            .RuleFor(c => c.Id, studentId)
            .RuleFor(c => c.FirstName, f => f.Person.FirstName).Generate();

        var mockRepository = Substitute.For<IStudentRepository>();
        mockRepository.GetById(studentId).Returns(fakeStudent);

        var handler = new GetStudentByIdHandler(mockRepository);
        var query = new GetStudentByIdQuery(studentId);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(studentId, result.Id);
        Assert.Equal(result.FirstName, fakeStudent.FirstName);
    }

    [Fact]
    public async Task GetStudentByIdHandler_With_InvalidId_Returns_Null()
    {
        // Arrange
        long studentId = 999;

        var mockRepository = Substitute.For<IStudentRepository>();
        mockRepository.GetById(studentId)
                      .Returns(Task.FromResult<Student>(null));

        var handler = new GetStudentByIdHandler(mockRepository);
        var query = new GetStudentByIdQuery(studentId);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        Assert.Null(result);
    }
}
