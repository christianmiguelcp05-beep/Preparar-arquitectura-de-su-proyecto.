namespace SchoolApp.DAL.Models.Dbo;

/// <summary>
/// Entidad: Estudiante
/// Schema: dbo
/// Auto-generada con EF Core Scaffold-DbContext
/// </summary>
public class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public int? ClassroomId { get; set; }

    public virtual Classroom? Classroom { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = [];

    public virtual ICollection<StudentGrade> StudentGrades { get; set; } = [];
}
