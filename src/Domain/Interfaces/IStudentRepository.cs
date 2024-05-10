using Domain.ValueObjects;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAll();

    Task<Student?> GetById(long id);

    Task<Student> Add(Student model);

    Student Update(Student model);

    void Delete(Student model);

    Task SaveChanges();

    Task<bool> IsEmailUnique(Email email);

    Task<bool> IsEmailUnique(Email email, long studentId);

    Task<bool> IsGitHubUsernameUnique(string gitHubUsername);

    Task<bool> IsGitHubUsernameUnique(string gitHubUsername, long studentId);
}