using Microsoft.EntityFrameworkCore;
using StudentApp.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StudentApp.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Materia> Materias => Set<Materia>();
    public DbSet<EstudianteMateria> EstudianteMaterias => Set<EstudianteMateria>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstudianteMateria>()
            .HasKey(em => new { em.EstudianteId, em.MateriaId });

        modelBuilder.Entity<EstudianteMateria>()
            .HasOne(em => em.Estudiante)
            .WithMany(e => e.EstudianteMaterias)
            .HasForeignKey(em => em.EstudianteId);

        modelBuilder.Entity<EstudianteMateria>()
            .HasOne(em => em.Materia)
            .WithMany(m => m.EstudianteMaterias)
            .HasForeignKey(em => em.MateriaId);
    }
}
