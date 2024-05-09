using Application.Students.Queries;

namespace Application.Tests.Integration.Students;

public class StudentHandlersTests : BaseIntegrationTest
{
    public StudentHandlersTests(IntegrationTestWebApplicationFactory factory) : base(factory) { }

    [Fact]
    public async void GetAllCustomerHandler_Returns_CustomerResponse()
    {
        // Arrange
        var query = new GetAllStudentsQuery();

        // Act
        var result = await _sender.Send(query);

        // Assert
        Assert.NotNull(result);
    }
}
