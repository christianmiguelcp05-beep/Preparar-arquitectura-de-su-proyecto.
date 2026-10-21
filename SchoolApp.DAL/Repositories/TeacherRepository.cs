using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.Data;
using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Repositories;

/// <summary>
/// Implementación específica del repositorio para Profesores
/// </summary>
public class TeacherRepository : Repository<Teacher>, ITeacherRepository
{
    public TeacherRepository(AppDbContext context) : base(context) { }

    public async Task<Teacher?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(t => t.Email == email);
    }

    public async Task<IEnumerable<Teacher>> GetWithCoursesAsync()
    {
        return await _dbSet
            .Include(t => t.Courses)
            .ToListAsync();
    }

    public async Task<IEnumerable<Teacher>> GetWithClassroomsAsync()
    {
        return await _dbSet
            .Include(t => t.Classrooms)
            .ToListAsync();
    }
}
