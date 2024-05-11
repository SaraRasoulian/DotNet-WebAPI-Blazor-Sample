using WebAPI.Tests.Acceptance.Drivers;
using WebAPI.Tests.Acceptance.Dtos;
using TechTalk.SpecFlow;

namespace WebAPI.Tests.Acceptance.StepDefinitions;

[Binding]
public class StudentManagementSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly StudentManagementDriver _driver;
    public StudentManagementSteps(ScenarioContext scenarioContext, StudentManagementDriver driver)
    {
        _scenarioContext = scenarioContext;
        _driver = driver;
    }

    [Given(@"platform has ""(.*)"" students")]
    public void GivenplatformHas0Students(string numberOfStudents)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();
        Assert.Equal(int.Parse(numberOfStudents), studentResponse?.Count);
    }

    [When(@"user creates a student with following data by sending 'Create Student Command' through API")]
    public void WhenUserCreatesAStudent(Table student)
    {
        HttpResponseMessage createResponse = _driver.CreateStudent(student);
        createResponse.EnsureSuccessStatusCode();
    }

    [Then(@"user requests to get all the students and it must return ""(.*)"" student with following data")]
    public void ThenUserGet1Student(string numberOfStudents, Table expectedStudent)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();

        Assert.Equal(int.Parse(numberOfStudents), studentResponse?.Count);

        var expectedStudentResponse = _driver.ParseCreateStudentData(expectedStudent);
        Assert.Equal(expectedStudentResponse.FirstName, studentResponse[0].FirstName);
        Assert.Equal(expectedStudentResponse.LastName, studentResponse[0].LastName);
        Assert.Equal(expectedStudentResponse.Email.Value, studentResponse[0].Email.Value);
        Assert.Equal(expectedStudentResponse.BirthDate, studentResponse[0].BirthDate);
        Assert.Equal(expectedStudentResponse.GitHubUsername, studentResponse[0].GitHubUsername);
    }

    [When(@"user creates another student with following data by sending 'Create Student Command' through API")]
    public void WhenUserCreatesAStudentWithSameInfo(Table student)
    {
        HttpResponseMessage createSameStudentResponse = _driver.CreateStudent(student);
        _scenarioContext.Add("createSameStudentResponse", createSameStudentResponse);
    }

    [Then(@"user must get status code ""(.*)""")]
    public void ThenUserMustGetInternalServerError(string statusCode)
    {
        var createSameStudentResponse = _scenarioContext.Get<HttpResponseMessage?>("createSameStudentResponse");
        Assert.Equal(int.Parse(statusCode), (int)createSameStudentResponse.StatusCode);
    }

    [When(@"user updates student by email ""(.*)"" with following data")]
    public void ThenUserUpdateStudent(string email, Table student)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();
        Assert.Equal(email, studentResponse[0].Email.Value);

        HttpResponseMessage updateResponse = _driver.UpdateStudent(studentResponse[0].Id, student);
        updateResponse.EnsureSuccessStatusCode();
    }

    [Then(@"user requests to get all the students and it must return ""(.*)"" student")]
    public void ThenUserCanRequestToGetStudents(string numberOfStudents, Table expectedStudent)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();

        Assert.Equal(int.Parse(numberOfStudents), studentResponse?.Count);

        var expectedStudentResponse = _driver.ParseCreateStudentData(expectedStudent);
        Assert.Equal(expectedStudentResponse.FirstName, studentResponse[0].FirstName);
        Assert.Equal(expectedStudentResponse.LastName, studentResponse[0].LastName);
        Assert.Equal(expectedStudentResponse.Email.Value, studentResponse[0].Email.Value);
        Assert.Equal(expectedStudentResponse.BirthDate, studentResponse[0].BirthDate);
        Assert.Equal(expectedStudentResponse.GitHubUsername, studentResponse[0].GitHubUsername);
    }

    [When(@"user deletes student by Email of ""(.*)""")]
    public void WhenUserDeleteTheStudent(string email)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();
        Assert.Equal(email, studentResponse[0].Email.Value);

        HttpResponseMessage deleteResponse = _driver.DeleteStudent(studentResponse[0].Id);
        deleteResponse.EnsureSuccessStatusCode();
    }

    [Then(@"user requests to get all students and it must return ""(.*)"" students")]
    public void ThenUserQueryToGetAllStudents(string numberOfStudents)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();
        Assert.Equal(int.Parse(numberOfStudents), studentResponse?.Count);
    }
}