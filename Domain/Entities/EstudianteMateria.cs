
using System.ComponentModel.DataAnnotations;

namespace StudentApp.Domain.Entities
{
    public class EstudianteMateria
    {
        [Required]
        public int EstudianteId { get; set; }
        public Estudiante? Estudiante { get; set; }
        
        [Required]
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }
        public DateTime FechaInscripcion { get; internal set; }
    }
}
