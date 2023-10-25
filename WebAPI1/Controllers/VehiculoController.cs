using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI1.Database;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    public class VehiculoController : ApiController
    {
        private PrimaryDbContext db = new PrimaryDbContext();

        // GET: api/Vehiculo
        public IQueryable<Vehiculo> GetVehiculos()
        {
            return db.Vehiculos.Include(v => v.Vendedor);
        }


        // GET: api/Vehiculo/5
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult GetVehiculo(long id)
        {
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
        }

        // PUT: api/Vehiculo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehiculo(long id, Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehiculo.IdVehiculo)
            {
                return BadRequest();
            }

            db.Entry(vehiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vehiculo
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult PostVehiculo(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehiculos.Add(vehiculo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehiculo.IdVehiculo }, vehiculo);
        }

        // DELETE: api/Vehiculo/5
        [ResponseType(typeof(Vehiculo))]
        public IHttpActionResult DeleteVehiculo(long id)
        {
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            db.Vehiculos.Remove(vehiculo);
            db.SaveChanges();

            return Ok(vehiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehiculoExists(long id)
        {
            return db.Vehiculos.Count(e => e.IdVehiculo == id) > 0;
        }
    }
}