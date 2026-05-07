using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiEscuela.Models
{
    public class EscuelaContext :DbContext
    {
        public EscuelaContext() : base("name=EscuelaConnection") { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Materia> Materias { get; set; }
    }
}