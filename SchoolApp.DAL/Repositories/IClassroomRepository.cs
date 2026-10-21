using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Repositories;

/// <summary>
/// Interfaz específica para operaciones sobre Aulas
/// </summary>
public interface IClassroomRepository : IRepository<Classroom>
{
    Task<Classroom?> GetWithStudentsAsync(int classroomId);

    Task<Classroom?> GetWithTeacherAsync(int classroomId);

    Task<IEnumerable<Classroom>> GetByTeacherAsync(int teacherId);

    Task<IEnumerable<Classroom>> GetAvailableAsync(int minCapacity);
}
