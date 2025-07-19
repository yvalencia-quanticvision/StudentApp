namespace StudentApp.Domain.Entities
{
    public class Materia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Codigo { get; set; }

        public string Creditos { get; set; }

        public List<EstudianteMateria> EstudianteMaterias { get; set; } = new List<EstudianteMateria>();

    }
}
