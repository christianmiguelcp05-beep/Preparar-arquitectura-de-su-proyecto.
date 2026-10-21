namespace SchoolApp.DAL.Models.Dbo;

/// <summary>
/// Entidad: Enrollment (Inscripción de Estudiante en Curso)
/// Schema: dbo
/// Auto-generada con EF Core Scaffold-DbContext
/// </summary>
public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public decimal? Grade { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
