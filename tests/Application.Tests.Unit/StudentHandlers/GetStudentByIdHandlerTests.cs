namespace Application.Tests.Unit.StudentHandlers;

public class GetStudentByIdHandlerTests
{
    [Fact]
    public async Task GetStudentByIdHandler_With_ValidId_Returns_StudentResponse()
    {
        // Arrange
        var customerId = 1;
        var fakeStudent = new Faker<Student>()
            .RuleFor(c => c.Id, customerId)
            .RuleFor(c => c.FirstName, f => f.Person.FirstName).Generate();

        var mockRepository = Substitute.For<IStudentRepository>();
        mockRepository.GetById(customerId).Returns(fakeStudent);

        var handler = new GetStudentByIdHandler(mockRepository);
        var query = new GetStudentByIdQuery(customerId);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(customerId, result.Id);
        Assert.Equal(result.FirstName, fakeStudent.FirstName);
    }

    [Fact]
    public async Task GetStudentByIdHandler_With_InvalidId_Returns_Null()
    {
        // Arrange
        long customerId = 999;

        var mockRepository = Substitute.For<IStudentRepository>();
        mockRepository.GetById(customerId)
                      .Returns(Task.FromResult<Student>(null));

        var handler = new GetStudentByIdHandler(mockRepository);
        var query = new GetStudentByIdQuery(customerId);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        Assert.Null(result);
    }
}
