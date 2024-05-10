using TechTalk.SpecFlow;
using WebAPI.Tests.Acceptance.Drivers;
using WebAPI.Tests.Acceptance.Dtos;

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
        Assert.Equal(studentResponse?.Count, int.Parse(numberOfStudents));
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

        Assert.Equal(studentResponse?.Count, int.Parse(numberOfStudents));

        var expectedStudentResponse = _driver.ParseCreateStudentData(expectedStudent);
        Assert.Equal(studentResponse[0].FirstName, expectedStudentResponse.FirstName);
        Assert.Equal(studentResponse[0].LastName, expectedStudentResponse.LastName);
        Assert.Equal(studentResponse[0].Email.Value, expectedStudentResponse.Email.Value);
        Assert.Equal(studentResponse[0].BirthDate, expectedStudentResponse.BirthDate);
        Assert.Equal(studentResponse[0].GitHubUsername, expectedStudentResponse.GitHubUsername);
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
        Assert.Equal((int)createSameStudentResponse.StatusCode, int.Parse(statusCode));
    }

    [When(@"user updates student by email ""(.*)"" with following data")]
    public void ThenUserUpdateStudent(string email, Table student)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();
        Assert.Equal(studentResponse[0].Email.Value, email);

        HttpResponseMessage updateResponse = _driver.UpdateStudent(studentResponse[0].Id, student);
        updateResponse.EnsureSuccessStatusCode();
    }

    [Then(@"user requests to get all the students and it must return ""(.*)"" student")]
    public void ThenUserCanRequestToGetStudents(string numberOfStudents, Table expectedStudent)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();

        Assert.Equal(studentResponse?.Count, int.Parse(numberOfStudents));

        var expectedStudentResponse = _driver.ParseCreateStudentData(expectedStudent);
        Assert.Equal(studentResponse[0].FirstName, expectedStudentResponse.FirstName);
        Assert.Equal(studentResponse[0].LastName, expectedStudentResponse.LastName);
        Assert.Equal(studentResponse[0].Email.Value, expectedStudentResponse.Email.Value);
        Assert.Equal(studentResponse[0].BirthDate, expectedStudentResponse.BirthDate);
        Assert.Equal(studentResponse[0].GitHubUsername, expectedStudentResponse.GitHubUsername);
    }

    [When(@"user deletes student by Email of ""(.*)""")]
    public void WhenUserDeleteTheStudent(string email)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();
        Assert.Equal(studentResponse[0].Email.Value, email);

        HttpResponseMessage deleteResponse = _driver.DeleteStudent(studentResponse[0].Id);
        deleteResponse.EnsureSuccessStatusCode();
    }

    [Then(@"user requests to get all students and it must return ""(.*)"" students")]
    public void ThenUserQueryToGetAllStudents(string numberOfStudents)
    {
        List<StudentDto> studentResponse = _driver.GetAllStudents();
        Assert.Equal(studentResponse?.Count, int.Parse(numberOfStudents));
    }
}