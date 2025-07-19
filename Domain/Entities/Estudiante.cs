namespace StudentApp.Domain.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        public List<EstudianteMateria> EstudianteMaterias { get; set; }
    }
}
