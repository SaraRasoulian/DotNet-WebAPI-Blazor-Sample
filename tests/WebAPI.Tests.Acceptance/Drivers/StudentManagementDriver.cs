using WebAPI.Tests.Acceptance.Hooks;
using WebAPI.Tests.Acceptance.Dtos;
using TechTalk.SpecFlow.Assist;
using System.Globalization;
using System.Net.Http.Json;
using Domain.ValueObjects;
using TechTalk.SpecFlow;

namespace WebAPI.Tests.Acceptance.Drivers;

public class StudentManagementDriver : BaseAcceptanceTest
{
    public StudentManagementDriver(AcceptanceTestWebApplicationFactory factory) : base(factory)
    {
    }

    public List<StudentDto> GetAllStudents()
    {
        var response = _httpClient.GetAsync("/api/students").Result;
        return response.Content.ReadFromJsonAsync<List<StudentDto>>().Result;
    }

    public HttpResponseMessage CreateStudent(Table student)
    {
        var request = ParseCreateStudentData(student);
        return _httpClient.PostAsJsonAsync("/api/students", request).Result;
    }

    public HttpResponseMessage UpdateStudent(long studentId, Table student)
    {
        var request = ParseCreateStudentData(student);
        request.Id = studentId;

        return _httpClient.PutAsJsonAsync("/api/students/" + studentId, request).Result;
    }

    public HttpResponseMessage DeleteStudent(long studentId)
    {
        return _httpClient.DeleteAsync("/api/students/" + studentId).Result;
    }

    public StudentDto ParseCreateStudentData(Table student)
    {
        var request = student.CreateInstance<StudentDto>();
        request.BirthDate = DateOnly.ParseExact(student.Rows[0]["BirthDate"], "yyyy-MM-dd", CultureInfo.InvariantCulture);
        request.Email = new Email(student.Rows[0]["Email"]);
        return request;
    }
}
