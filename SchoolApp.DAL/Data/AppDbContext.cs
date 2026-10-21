using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Data;

/// <summary>
/// DbContext principal de la aplicación SchoolApp
/// Auto-generado/actualizado con EF Core Scaffold-DbContext
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // DbSets para entidades del schema dbo
    public DbSet<Student> Students { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Classroom> Classrooms { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }

    public DbSet<StudentGrade> StudentGrades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar tabla Students
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students", "dbo");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.HasOne(e => e.Classroom).WithMany(c => c.Students).HasForeignKey(e => e.ClassroomId);
        });

        // Configurar tabla Teachers
        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teachers", "dbo");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Specialization).HasMaxLength(100);
        });

        // Configurar tabla Courses
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Courses", "dbo");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.HasOne(e => e.Teacher).WithMany(t => t.Courses).HasForeignKey(e => e.TeacherId);
        });

        // Configurar tabla Classrooms
        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.ToTable("Classrooms", "dbo");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.HasOne(e => e.Teacher).WithMany(t => t.Classrooms).HasForeignKey(e => e.TeacherId);
        });

        // Configurar tabla Enrollments
        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollments", "dbo");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Grade).HasPrecision(5, 2);
            entity.HasOne(e => e.Student).WithMany(s => s.Enrollments).HasForeignKey(e => e.StudentId);
            entity.HasOne(e => e.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseId);
        });

        // Configurar tabla StudentGrades
        modelBuilder.Entity<StudentGrade>(entity =>
        {
            entity.ToTable("StudentGrades", "dbo");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Grade).HasPrecision(5, 2);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.HasOne(e => e.Student).WithMany(s => s.StudentGrades).HasForeignKey(e => e.StudentId);
        });
    }
}
