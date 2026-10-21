# Instrucciones para Generar Entidades con EF Core

## PASO 1: Abrir Package Manager Console en Visual Studio

1. Ve a **Tools → NuGet Package Manager → Package Manager Console**
2. Asegúrate de que en el dropdown "Default project" esté seleccionado **SchoolApp.DAL**

## PASO 2: Ejecutar Scaffold-DbContext

Ejecuta el siguiente comando en la Package Manager Console:

```powershell
Scaffold-DbContext "Server=<TU_SERVIDOR>;Database=motor;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context AppDbContext -Force
```

**Reemplaza `<TU_SERVIDOR>` con:**
- `localhost\SQLEXPRESS` (instalación local standard)
- `localhost` (SQL Server Express localdb)
- Tu servidor específico si es diferente

### Ejemplo completo:
```powershell
Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=motor;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context AppDbContext -Force
```

## PASO 3: Organizar por Schema

Una vez generadas las entidades:

1. En **SchoolApp.DAL/Models**, verás las entidades generadas
2. Organiza las entidades en subcarpetas por schema (ej: `dbo`, `hr`, `sales`, etc.)
   - Ejemplo: `Models/dbo/Student.cs`, `Models/dbo/Course.cs`
3. Actualiza los namespaces en cada archivo:
   - Cambia `namespace SchoolApp.DAL.Models;` 
   - A `namespace SchoolApp.DAL.Models.Dbo;`

## PASO 4: Regenerar el DbContext con las nuevas rutas

```powershell
Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=motor;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Data -Context AppDbContext -Force -MigrationsDir Migrations
```

## PASO 5: Crear Repositorios Específicos (Opcional pero Recomendado)

Para cada entidad principal, crea un repositorio específico:

```csharp
// Archivo: SchoolApp.DAL/Repositories/IStudentRepository.cs
namespace SchoolApp.DAL.Repositories;

public interface IStudentRepository : IRepository<Student>
{
	Task<Student?> GetByEmailAsync(string email);
	Task<IEnumerable<Student>> GetByGradeAsync(int grade);
}

// Archivo: SchoolApp.DAL/Repositories/StudentRepository.cs
using SchoolApp.DAL.Data;
using SchoolApp.DAL.Models.Dbo;

namespace SchoolApp.DAL.Repositories;

public class StudentRepository : Repository<Student>, IStudentRepository
{
	public StudentRepository(AppDbContext context) : base(context) { }

	public async Task<Student?> GetByEmailAsync(string email)
	{
		return await _dbSet.FirstOrDefaultAsync(s => s.Email == email);
	}

	public async Task<IEnumerable<Student>> GetByGradeAsync(int grade)
	{
		return await _dbSet.Where(s => s.Grade == grade).ToListAsync();
	}
}
```

## PASO 6: Registrar Repositorios en DependencyInjection.cs

Abre `SchoolApp.DAL/DependencyInjection.cs` y descomenta/agrega:

```csharp
// Registrar repositorios específicos cuando se generen
services.AddScoped<IStudentRepository, StudentRepository>();
services.AddScoped<ITeacherRepository, TeacherRepository>();
// etc. según tus entidades
```

## PASO 7: Configurar appsettings.json en SchoolApp.Web

En el archivo `SchoolApp.Web/appsettings.json`, agrega la cadena de conexión:

```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=motor;Integrated Security=true;"
  },
  "Logging": {
	"LogLevel": {
	  "Default": "Information"
	}
  }
}
```

## Troubleshooting

### Error: "Cannot resolve symbol 'Scaffold-DbContext'"
- Asegúrate de haber instalado EntityFrameworkCore.Tools
- Cierra y reabre Visual Studio

### Error: "No database provider has been configured for this DbContext"
- Verifica la cadena de conexión
- Asegúrate de que el servidor SQL está ejecutándose

### Error: "Cannot connect to database"
- Verifica el nombre del servidor (localhost vs 127.0.0.1)
- Comprueba que SQL Server está activo
- Verifica credenciales si usas autenticación SQL

---

**Próximo paso:** Una vez completado el scaffolding, ejecuta el Step 4 en Visual Studio.
