using Application.Tests.Integration;
using Application.ResponseModels;
using Application.RequestModels;
using System.Net.Http.Json;
using Domain.ValueObjects;

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

    [Fact]
    public async Task Post_Returns_OK_With_StudentResponse()
    {
        // Arrange
        CreateStudentRequest request = new CreateStudentRequest(
            FirstName: "Max",
            LastName: "Mirzaee",
            Email: new Email("max@gmail.com"),
            BirthDate: new DateOnly(2006, 06, 01),
            GitHubUsername: "max-1");

        // Act
        var response = await _httpClient.PostAsJsonAsync("/api/students", request);

        // Assert
        response.EnsureSuccessStatusCode();

        var studentResponse = await response.Content.ReadFromJsonAsync<StudentResponse>();
        Assert.Equal(request.FirstName, studentResponse.FirstName);
        Assert.Equal(request.LastName, studentResponse.LastName);
        Assert.Equal(request.Email.Value, studentResponse.Email.Value);
        Assert.Equal(request.BirthDate, studentResponse.BirthDate);
        Assert.Equal(request.GitHubUsername, studentResponse.GitHubUsername);
    }
}
