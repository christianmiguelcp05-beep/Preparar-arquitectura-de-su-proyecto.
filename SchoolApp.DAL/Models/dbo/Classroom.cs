namespace SchoolApp.DAL.Models.Dbo;

/// <summary>
/// Entidad: Classroom (Aula)
/// Schema: dbo
/// Auto-generada con EF Core Scaffold-DbContext
/// </summary>
public class Classroom
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public string? Location { get; set; }

    public int? TeacherId { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public virtual ICollection<Student> Students { get; set; } = [];
}
