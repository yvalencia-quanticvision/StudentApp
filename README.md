
# StudentApp - Gestión de Estudiantes y Materias

Aplicación ASP.NET Core MVC que permite gestionar estudiantes, materias e inscripciones de materias con validaciones personalizadas. Utiliza Entity Framework Core, arquitectura por capas y pruebas unitarias.

## 🚀 Tecnologías usadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Arquitectura por capas (Domain, Infrastructure, View o web)
- Pruebas unitarias con xUnit
- Inyección de dependencias
- Razor Pages

## 📁 Estructura del proyecto

- `StudentApp.Domain`: Contiene las entidades del dominio (`Estudiante`, `Materia`, `EstudianteMateria`).
- `StudentApp.Infrastructure`: Contexto de EF Core y configuración de base de datos.
- `StudentApp`: Proyecto Web MVC (Controladores, Vistas).
- `StudentApp.Tests`: Proyecto de pruebas unitarias con xUnit.

## 🧑‍🎓 Funcionalidades principales

- CRUD de Estudiantes.
- CRUD de Materias.
- Inscripción de Estudiantes a Materias:
  - No permite duplicar inscripciones.
  - Máximo de 3 materias con más de 4 créditos por estudiante.
  - Fecha de inscripción se asigna automáticamente.

## ⚙️ Cómo ejecutar

1. Clona el repositorio.
2. Configura la cadena de conexión en `appsettings.json`.
3. Ejecuta las migraciones o crea la base de datos manualmente.
4. Ejecuta la aplicación (`F5` o desde `dotnet run`).
5. La aplicación arranca directamente en el listado de estudiantes.

## 🧪 Pruebas unitarias Solo se puedo agregar 1

- El proyecto incluye pruebas para el controlador `EstudianteMateriasController`.
- Para ejecutarlas:
  - Abre el Explorador de pruebas (Ctrl + E, T).
  - Ejecuta todas las pruebas (Ctrl + R, A).

## 🎯 Página inicial

- La vista principal es el listado de estudiantes.
- Desde allí puedes:
  - Editar o eliminar estudiantes.
  - Ir al listado de materias.
  - Asignar materias a estudiantes.

## 📦 Extras

- Las vistas usan Razor con SelectList para los combos.
- Validación en cliente y servidor.
- Diseño limpio y funcional.

---

> Proyecto creado siguiendo buenas prácticas de ASP.NET Core y principios SOLID.

Diagrama BD 
<img width="1036" height="388" alt="Captura de pantalla 2025-07-19 132530" src="https://github.com/user-attachments/assets/65fb62c2-8bce-4b5d-b22b-09e131e87c17" />

IMG pagina principal Estudiantes

<img width="1193" height="475" alt="image" src="https://github.com/user-attachments/assets/65cdbd80-9431-4c4d-8686-9735cc4d65b9" />

IMG Materias
<img width="1005" height="414" alt="image" src="https://github.com/user-attachments/assets/0beb60bb-9dd4-43f8-9d98-0746ecd106e4" />

IMG inscripciones 
<img width="1224" height="468" alt="image" src="https://github.com/user-attachments/assets/b034515c-ff3f-4988-b041-bcea1cfc3c48" />

IMG Asignar Materias
<img width="1083" height="388" alt="image" src="https://github.com/user-attachments/assets/e14b6614-b081-4acc-9497-e816747357d3" />





