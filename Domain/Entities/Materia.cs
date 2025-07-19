namespace StudentApp.Domain.Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EstudianteMateria>EstudianteMaterias { get; set; }

    }
}
