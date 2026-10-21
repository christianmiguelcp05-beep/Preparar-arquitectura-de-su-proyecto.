using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.DAL.Data;
using SchoolApp.DAL.Repositories;

namespace SchoolApp.DAL;

/// <summary>
/// Extensión para registrar dependencias de la capa DAL
/// Se registra el DbContext, repositorios genéricos y específicos
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configurar DbContext con SQL Server
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada.");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString,
                sqlServerOptions => sqlServerOptions
                    .MigrationsAssembly("SchoolApp.DAL")));

        // Registrar repositorio genérico
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Registrar repositorios específicos
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();

        return services;
    }
}
