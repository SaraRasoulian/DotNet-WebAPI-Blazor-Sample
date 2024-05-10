using Application.Tests.Integration;

namespace WebAPI.Tests.Integration.ControllersTests;

public class StudentsControllerTests : BaseControllerTest
{
    public StudentsControllerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAll_Returns_OK()
    {
        // Arrange

        // Act
        var response = await _httpClient.GetAsync("/api/students");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
