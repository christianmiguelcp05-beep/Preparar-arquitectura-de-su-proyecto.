using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Repositories;

/// <summary>
/// Interfaz específica para operaciones sobre Inscripciones
/// </summary>
public interface IEnrollmentRepository : IRepository<Enrollment>
{
    Task<Enrollment?> GetWithStudentAndCourseAsync(int enrollmentId);

    Task<IEnumerable<Enrollment>> GetByStudentAsync(int studentId);

    Task<IEnumerable<Enrollment>> GetByCourseAsync(int courseId);

    Task<bool> IsStudentEnrolledAsync(int studentId, int courseId);

    Task<decimal?> GetAverageGradeAsync(int studentId);
}
