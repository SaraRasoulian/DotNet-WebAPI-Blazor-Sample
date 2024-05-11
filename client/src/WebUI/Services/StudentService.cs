using System.Net.Http.Json;
using WebUI.Dtos;

namespace WebUI.Services;

public class StudentService
{
    private const string URL = ApiUrls.BaseURL + "/api/students";
    private readonly HttpClient _httpClient;

    public StudentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<StudentDto[]> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<StudentDto[]>(URL);
    }

    public async Task<StudentDto> Get(string studentId)
    {
        return await _httpClient.GetFromJsonAsync<StudentDto>($"{URL}/{studentId}");
    }

    public async Task<HttpResponseMessage> Add(StudentDto student)
    {
        return await _httpClient.PostAsJsonAsync(URL, student);
    }

    public async Task<HttpResponseMessage> Edit(string studentId, StudentDto StudentDto)
    {
        return await _httpClient.PutAsJsonAsync($"{URL}/{studentId}", StudentDto);
    }

    public async Task<HttpResponseMessage> Delete(string studentId)
    {
        return await _httpClient.DeleteAsync($"{URL}/{studentId}");
    }
}
