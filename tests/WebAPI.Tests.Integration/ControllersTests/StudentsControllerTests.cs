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
        
    [Fact]
    public async void Put_Returns_Ok_With_StudentResponse()
    {
        // Arrange
        // Create a new student
        CreateStudentRequest createRequest = new CreateStudentRequest(
            FirstName: "Diana",
            LastName: "Moradi",
            Email: new Email("diana@gmail.com"),
            BirthDate: new DateOnly(2000, 1, 1),
            GitHubUsername: "diana"
        );

        var postResponse = await _httpClient.PostAsJsonAsync("/api/students", createRequest);
        var addedStudent = await postResponse.Content.ReadFromJsonAsync<StudentResponse>();

        UpdateStudentRequest updateRequest = new UpdateStudentRequest(
            Id: addedStudent.Id,
            FirstName: "Diana",
            LastName: "Rasouli",
            Email: new Email("dia@gmail.com"),
            BirthDate: new DateOnly(1900, 1, 1),
            GitHubUsername: "diana-900");

        // Act
        var updateResponse = await _httpClient.PutAsJsonAsync("/api/students/" + addedStudent.Id, updateRequest);

        // Assert
        updateResponse.EnsureSuccessStatusCode();
        postResponse.EnsureSuccessStatusCode();

        var updatedStudent = await updateResponse.Content.ReadFromJsonAsync<StudentResponse>();

        Assert.Equal(updateRequest.FirstName, updatedStudent.FirstName);
        Assert.Equal(updateRequest.LastName, updatedStudent.LastName);
        Assert.Equal(updateRequest.Email.Value, updatedStudent.Email.Value);
        Assert.Equal(updateRequest.BirthDate, updatedStudent.BirthDate);
        Assert.Equal(updateRequest.GitHubUsername, updatedStudent.GitHubUsername);
    }

    [Fact]
    public async Task Delete_With_Valid_StudentId_Returns_OK()
    {
        // Arrange
        // Create a new student
        CreateStudentRequest request = new CreateStudentRequest(
            FirstName: "Arsh",
            LastName: "Mirzaee",
            Email: new Email("arsh@gmail.com"),
            BirthDate: new DateOnly(1984, 06, 01),
            GitHubUsername: "arsh84");

        var postResponse = await _httpClient.PostAsJsonAsync("/api/students", request);
        StudentResponse addedStudent = await postResponse.Content.ReadFromJsonAsync<StudentResponse>();

        // Act
        var deleteResponse = await _httpClient.DeleteAsync("/api/students/" + addedStudent.Id);

        // Assert
        postResponse.EnsureSuccessStatusCode();
        deleteResponse.EnsureSuccessStatusCode();
    }
}
