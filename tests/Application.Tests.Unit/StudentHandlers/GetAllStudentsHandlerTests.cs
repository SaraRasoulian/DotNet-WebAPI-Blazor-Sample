namespace Application.Tests.Unit.StudentHandlers;

public class GetAllStudentsHandlerTests
{
    [Fact]
    public async Task Handle_Returns_Students()
    {
        // Arrange
        var fakeRepository = Substitute.For<IStudentRepository>();

        byte fakeStudentCount = 4;
        var fakeStudents = new Faker<Student>().Generate(fakeStudentCount);

        fakeRepository.GetAll().Returns(fakeStudents);

        var handler = new GetAllStudentsHandler(fakeRepository);
        var query = new GetAllStudentsQuery();

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<StudentResponse>>(result);
        Assert.Equal(fakeStudentCount, (result as List<StudentResponse>).Count);
    }
}