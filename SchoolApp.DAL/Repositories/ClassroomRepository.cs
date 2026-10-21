using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.Data;
using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Repositories;

/// <summary>
/// Implementación específica del repositorio para Aulas
/// </summary>
public class ClassroomRepository : Repository<Classroom>, IClassroomRepository
{
    public ClassroomRepository(AppDbContext context) : base(context) { }

    public async Task<Classroom?> GetWithStudentsAsync(int classroomId)
    {
        return await _dbSet
            .Where(c => c.Id == classroomId)
            .Include(c => c.Students)
            .FirstOrDefaultAsync();
    }

    public async Task<Classroom?> GetWithTeacherAsync(int classroomId)
    {
        return await _dbSet
            .Where(c => c.Id == classroomId)
            .Include(c => c.Teacher)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Classroom>> GetByTeacherAsync(int teacherId)
    {
        return await _dbSet
            .Where(c => c.TeacherId == teacherId)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public async Task<IEnumerable<Classroom>> GetAvailableAsync(int minCapacity)
    {
        return await _dbSet
            .Where(c => c.Capacity >= minCapacity)
            .OrderBy(c => c.Capacity)
            .ToListAsync();
    }
}
