using Microsoft.AspNetCore.Mvc;
using StudentApp.Domain.Entities;
using StudentApp.Infrastructure.Persistence;

namespace StudentApp.Controllers
{
    public class MateriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Materias
        public IActionResult Index()
        {
            var materias = _context.Materias.ToList();
            return View(materias);
        }

        // GET: Materias/Details/5
        public IActionResult Details(int id)
        {
            var materia = _context.Materias.Find(id);
            if (materia == null) return NotFound();
            return View(materia);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Materias.Add(materia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }

        // GET: Materias/Edit/5
        public IActionResult Edit(int id)
        {
            var materia = _context.Materias.Find(id);
            if (materia == null) return NotFound();
            return View(materia);
        }

        // POST: Materias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Materia materia)
        {
            if (id != materia.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Materias.Update(materia);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }

        // GET: Materias/Delete/5
        public IActionResult Delete(int id)
        {
            var materia = _context.Materias.Find(id);
            if (materia == null) return NotFound();
            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var materia = _context.Materias.Find(id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
