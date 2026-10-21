using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Repositories;

/// <summary>
/// Interfaz específica para operaciones sobre Profesores
/// </summary>
public interface ITeacherRepository : IRepository<Teacher>
{
    Task<Teacher?> GetByEmailAsync(string email);

    Task<IEnumerable<Teacher>> GetWithCoursesAsync();

    Task<IEnumerable<Teacher>> GetWithClassroomsAsync();
}
