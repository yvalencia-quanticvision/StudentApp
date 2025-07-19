using Microsoft.AspNetCore.Mvc;
using StudentApp.Domain.Entities;
using StudentApp.Infrastructure.Persistence;

namespace StudentApp.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estudiantes
        public IActionResult Index()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }

        // GET: Estudiantes/Details/5
        public IActionResult Details(int id)
        {
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public IActionResult Edit(int id)
        {
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Estudiantes.Update(estudiante);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public IActionResult Delete(int id)
        {
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante == null) return NotFound();
            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
