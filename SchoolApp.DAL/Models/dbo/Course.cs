namespace SchoolApp.DAL.Models.Dbo;

/// <summary>
/// Entidad: Curso (Course)
/// Schema: dbo
/// Auto-generada con EF Core Scaffold-DbContext
/// </summary>
public class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Credits { get; set; }

    public int? TeacherId { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = [];
}
