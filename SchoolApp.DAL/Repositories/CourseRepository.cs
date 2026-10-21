using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.Data;
using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Repositories;

/// <summary>
/// Implementación específica del repositorio para Cursos
/// </summary>
public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context) { }

    public async Task<Course?> GetWithEnrollmentsAsync(int courseId)
    {
        return await _dbSet
            .Where(c => c.Id == courseId)
            .Include(c => c.Enrollments)
            .ThenInclude(e => e.Student)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Course>> GetByTeacherAsync(int teacherId)
    {
        return await _dbSet
            .Where(c => c.TeacherId == teacherId)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<int> GetEnrollmentCountAsync(int courseId)
    {
        return await _dbSet
            .Where(c => c.Id == courseId)
            .SelectMany(c => c.Enrollments)
            .CountAsync();
    }
}
