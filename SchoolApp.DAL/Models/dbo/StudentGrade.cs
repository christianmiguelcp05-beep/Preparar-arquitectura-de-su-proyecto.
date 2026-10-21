namespace SchoolApp.DAL.Models.Dbo;

/// <summary>
/// Entidad: StudentGrade (Calificación de Estudiante)
/// Schema: dbo
/// Auto-generada con EF Core Scaffold-DbContext
/// </summary>
public class StudentGrade
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int? CourseId { get; set; }

    public decimal? Grade { get; set; }

    public DateTime GradeDate { get; set; }

    public string? Remarks { get; set; }

    public virtual Student Student { get; set; } = null!;
}
