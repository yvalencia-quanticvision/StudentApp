using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Domain.Entities;
using StudentApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace StudentApp.Controllers
{
    public class EstudianteMateriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudianteMateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstudianteMaterias
        public IActionResult Index()
        {
            var inscripciones = _context.EstudianteMaterias
                .Include(em => em.Estudiante)
                .Include(em => em.Materia)
                .ToList();

            return View(inscripciones);
        }

        // GET: EstudianteMaterias/Create
        public IActionResult Create()
        {
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre");
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Name");
            return View();
        }

        // POST: EstudianteMaterias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EstudianteMateria estudianteMateria)
        {
            // Verificar si ya está inscrito en esa materia
            bool yaInscrito = _context.EstudianteMaterias.Any(em =>
                em.EstudianteId == estudianteMateria.EstudianteId &&
                em.MateriaId == estudianteMateria.MateriaId);

            if (yaInscrito)
            {
                ModelState.AddModelError("", "El estudiante ya está inscrito en esta materia.");
            }

            // Obtener materias actuales del estudiante con más de 4 créditos
            var materiasAltosCreditos = _context.EstudianteMaterias
                .Include(em => em.Materia)
                .Where(em => em.EstudianteId == estudianteMateria.EstudianteId &&
                             em.Materia.Creditos > 4)
                .ToList();

            if (_context.Materias.Find(estudianteMateria.MateriaId)?.Creditos > 4 &&
                materiasAltosCreditos.Count >= 3)
            {
                ModelState.AddModelError("", "El estudiante no puede inscribir más de 3 materias con más de 4 créditos.");
            }

            if (ModelState.IsValid)
            {
                estudianteMateria.FechaInscripcion = DateTime.Now;
                _context.EstudianteMaterias.Add(estudianteMateria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Nombre", estudianteMateria.EstudianteId);
            ViewData["MateriaId"] = new SelectList(_context.Materias, "Id", "Name", estudianteMateria.MateriaId);
            return View(estudianteMateria);
        }

        // GET: EstudianteMaterias/Delete/5
        public IActionResult Delete(int estudianteId, int materiaId)
        {
            var inscripcion = _context.EstudianteMaterias
                .Include(em => em.Estudiante)
                .Include(em => em.Materia)
                .FirstOrDefault(em => em.EstudianteId == estudianteId && em.MateriaId == materiaId);

            if (inscripcion == null) return NotFound();

            return View(inscripcion);
        }

        // POST: EstudianteMaterias/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int estudianteId, int materiaId)
        {
            var inscripcion = _context.EstudianteMaterias
                .FirstOrDefault(em => em.EstudianteId == estudianteId && em.MateriaId == materiaId);

            if (inscripcion != null)
            {
                _context.EstudianteMaterias.Remove(inscripcion);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
