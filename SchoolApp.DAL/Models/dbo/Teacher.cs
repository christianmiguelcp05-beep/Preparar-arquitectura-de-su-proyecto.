namespace SchoolApp.DAL.Models.Dbo;

/// <summary>
/// Entidad: Profesor (Teacher)
/// Schema: dbo
/// Auto-generada con EF Core Scaffold-DbContext
/// </summary>
public class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Specialization { get; set; }

    public DateTime HireDate { get; set; }

    public virtual ICollection<Classroom> Classrooms { get; set; } = [];

    public virtual ICollection<Course> Courses { get; set; } = [];
}
