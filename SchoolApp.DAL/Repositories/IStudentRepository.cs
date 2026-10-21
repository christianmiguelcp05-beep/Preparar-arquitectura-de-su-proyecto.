using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Repositories;

/// <summary>
/// Interfaz específica para operaciones sobre Estudiantes
/// </summary>
public interface IStudentRepository : IRepository<Student>
{
    Task<Student?> GetByEmailAsync(string email);

    Task<IEnumerable<Student>> GetByClassroomAsync(int classroomId);

    Task<IEnumerable<Student>> GetWithEnrollmentsAsync();
}
