using ApiEscuela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiEscuela.Controllers
{
    public class EstudiantesController : ApiController
    {
        public EscuelaContext db = new EscuelaContext();

        // GET: api/Estudiantes
        public IHttpActionResult Get()
            => Ok(db.Estudiantes.ToList());
        

        // GET: Parametrizado
        public IHttpActionResult Get(int id)
        {
            var estudiante = db.Estudiantes.Find(id);
            return estudiante == null ? (IHttpActionResult)NotFound() : Ok(estudiante);
        }


        //POST

        public IHttpActionResult Post(Estudiante estudiante)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            db.Estudiantes.Add(estudiante);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = estudiante.EstudianteId }, estudiante);
        }

        //PUT
        public IHttpActionResult Put(int id, Estudiante estudiante)
        {
            var estudianteInDb = db.Estudiantes.Find(id);
            if (estudianteInDb ==null) return NotFound();
            estudianteInDb.Nombre = estudiante.Nombre;
            estudianteInDb.Edad = estudiante.Edad;
            db.SaveChanges();
            return Ok(estudianteInDb);
        }

        //DELETE
        public IHttpActionResult Delete(int id)
        {
            var estudianteInDb = db.Estudiantes.Find(id);
            if (estudianteInDb == null) return NotFound();
            db.Estudiantes.Remove(estudianteInDb);
            db.SaveChanges();
            return Ok("Estudiante Eliminado");
        }
    }
}