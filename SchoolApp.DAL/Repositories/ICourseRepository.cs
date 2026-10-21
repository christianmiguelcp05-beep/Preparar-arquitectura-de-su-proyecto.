using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Repositories;

/// <summary>
/// Interfaz específica para operaciones sobre Cursos
/// </summary>
public interface ICourseRepository : IRepository<Course>
{
    Task<Course?> GetWithEnrollmentsAsync(int courseId);

    Task<IEnumerable<Course>> GetByTeacherAsync(int teacherId);

    Task<int> GetEnrollmentCountAsync(int courseId);
}
