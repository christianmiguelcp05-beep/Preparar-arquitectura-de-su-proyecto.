SchoolApp

Aplicación web de gestión académica desarrollada en ASP.NET Core con Entity Framework Core, organizada en capas (DAL, BL y Web).

Proyecto académico — ITLA (Instituto Tecnológico de Las Américas)

Tabla de contenido
Arquitectura
Tecnologías
Estructura del proyecto
Requisitos previos
Configuración inicial
Capa de datos (DAL)
Flujo de trabajo con Git
Equipo y módulos
Arquitectura

La solución sigue una arquitectura en tres capas:

Proyecto	Responsabilidad
SchoolApp.DAL	Acceso a datos: entidades, DbContext y repositorios (EF Core).
SchoolApp.BL	Lógica de negocio: servicios que consumen los repositorios.
SchoolApp.Web	Presentación: controladores, vistas y configuración de la aplicación.

Flujo de dependencias: Web → BL → DAL

Tecnologías
.NET / ASP.NET Core MVC
Entity Framework Core
SQL Server
EF Core Power Tools (ingeniería inversa de la base de datos)
Visual Studio 2022
Git y GitHub
Estructura del proyecto
SchoolApp
├── SchoolApp.DAL
│   ├── Data              → DbContext
│   ├── Models            → Entidades (subcarpetas por schema)
│   │   ├── <Schema1>
│   │   └── <Schema2>
│   ├── Repositories      → Interfaces e implementaciones de repositorios
│   ├── DependencyInjection.cs
│   └── efpt.config.json  → Configuración de EF Core Power Tools
│
├── SchoolApp.BL
│   ├── Services          → Servicios de negocio
│   └── DependencyInjection.cs
│
└── SchoolApp.Web
    ├── Controllers
    ├── Views
    ├── wwwroot
    ├── appsettings.json
    └── Program.cs
Requisitos previos
Visual Studio 2022 con la carga de trabajo ASP.NET y desarrollo web
SDK de .NET compatible con el proyecto
SQL Server (Express, LocalDB o instancia compartida)
Extensión EF Core Power Tools (Extensions → Manage Extensions)
Git
Configuración inicial
Clonar el repositorio
bash
   git clone https://github.com/<usuario>/SchoolApp.git
   cd SchoolApp
Abrir la solución SchoolApp.sln en Visual Studio.
Configurar la cadena de conexión. No subas contraseñas al repositorio. Usa User Secrets: clic derecho sobre SchoolApp.Web → Manage User Secrets y agrega:
json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=<NOMBRE_BD>;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }

Si usas autenticación SQL, reemplaza Trusted_Connection=True por User Id=<usuario>;Password=<clave>.

Restaurar paquetes y compilar (Ctrl + Shift + B).
Establecer SchoolApp.Web como proyecto de inicio y ejecutar con F5.
Capa de datos (DAL)

Las entidades se generan a partir de la base de datos con EF Core Power Tools:

Clic derecho en SchoolApp.DAL → EF Core Power Tools → Reverse Engineer.
Seleccionar la conexión y marcar todas las tablas (y vistas, si aplica).
Configurar:
Entity Types path: Models
DbContext path: Data
Activar Use schema folders para crear una subcarpeta por cada schema.
Generar y compilar.

La configuración queda guardada en efpt.config.json, por lo que puede regenerarse en cualquier momento.

Importante: cada integrante debe partir de la capa de datos completa para no atrasarse en su módulo.

Flujo de trabajo con Git
Ramas
Rama	Propósito
main	Versión estable / entregable.
develop	Integración del trabajo del equipo (incluye la capa de datos completa).
feature/modulo-<nombre>	Una rama por módulo y por integrante.
Pasos (desde Visual Studio)
Actualizar develop: Git → Pull.
Crear la rama de tu módulo: Git → New Branch, con base en develop (ejemplo: feature/modulo-estudiantes).
Trabajar y hacer commits desde la ventana Git Changes.
Publicar la rama con Push.
Abrir un Pull Request hacia develop en GitHub y solicitar revisión.
Convención de commits
feat(modulo): descripción corta de lo agregado
fix(modulo): descripción corta del error corregido
docs: cambios en documentación
refactor(modulo): mejora interna sin cambiar el comportamiento
Equipo y módulos
Integrante	Módulo	Rama
Nombre 1	Estudiantes	feature/modulo-estudiantes
Nombre 2	Cursos	feature/modulo-cursos
Nombre 3	Seguridad	feature/modulo-seguridad
