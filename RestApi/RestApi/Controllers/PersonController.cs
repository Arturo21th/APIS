using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Datos.Model;

namespace RestApi.Controllers
{
    public class PersonController : ApiController
    {
         UsuariosEntities db = new UsuariosEntities();
   
        [HttpGet]
        public IEnumerable<Usuario1> Get()
        {
            var listado = db.Usuario1.ToList();
            return listado;
        }

        [HttpGet]
        public Usuario1 Get(int id)
        {
            var Usuario1 = db.Usuario1.FirstOrDefault(x => x.id==id);
            return Usuario1;
        }

     
        [HttpPost]
        public IHttpActionResult Post([FromBody] Usuario1 u )
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

              db.Usuario1.Add(u);

              db.SaveChanges();
            
            return Ok(u);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Usuario1 u)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var personaExistente = db.Usuario1.Count(x => x.id == id) > 0;

            if (personaExistente)
            {
                db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else return NotFound();

            return Ok(u);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var Usuariopresente = db.Usuario1.Find(id);

            if (Usuariopresente != null)
            {
                db.Usuario1.Remove(Usuariopresente);
                db.SaveChanges();
            }
            else return NotFound();

            return Ok(Usuariopresente);
        }

    }
}
