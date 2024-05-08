using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagementDBContext _dbContext;
        public StudentRepository(StudentManagementDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student?> GetById(long id)
        {
            return await _dbContext.Students.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Student> Add(Student model)
        {
            var result = await _dbContext.Students.AddAsync(model);
            return result.Entity;
        }

        public Student Update(Student model)
        {
            var result = _dbContext.Students.Update(model);
            return result.Entity;
        }

        public void Delete(Student model)
        {
            _dbContext.Students.Remove(model);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsEmailUnique(Email email)
        {
            return !await _dbContext.Students.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> IsEmailUnique(Email email, long studentId)
        {
            return !await _dbContext.Students.AnyAsync(c => c.Email == email && c.Id != studentId);
        }

        public async Task<bool> IsGitHubUsernameUnique(string gitHubUsername)
        {
            return !await _dbContext.Students.AnyAsync(c => c.GitHubUsername.ToLower() == gitHubUsername.ToLower());
        }

        public async Task<bool> IsGitHubUsernameUnique(string gitHubUsername, long studentId)
        {
            return !await _dbContext.Students.AnyAsync(c => c.GitHubUsername.ToLower() == gitHubUsername.ToLower() && c.Id != studentId);
        }
    }
}
