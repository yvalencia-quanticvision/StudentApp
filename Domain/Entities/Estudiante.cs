namespace StudentApp.Domain.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Documento { get; set; }

        public string Correo {  get; set; }

        public List<EstudianteMateria> EstudianteMaterias { get; set; } = new List<EstudianteMateria>();
    }
}
