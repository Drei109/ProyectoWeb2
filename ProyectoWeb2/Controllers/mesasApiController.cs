﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoWeb2.Models;

namespace ProyectoWeb2.Controllers
{
    public class mesasApiController : ApiController
    {
        private RrestauranteModel db = new RrestauranteModel();

        // GET: api/mesasApi
        public List<mesaRestauranteDTO> Getmesa()
        {
            var mesa = (from m in db.mesa
                join r in db.restaurante on m.restaurante_id_fk equals r.restaurante_id
                select new mesaRestauranteDTO()
                {
                    mesa_id = m.mesa_id,
                    nombreRestaurante = r.nombre,
                    restaurante_id = r.restaurante_id
                }).ToList();
            return mesa;
        }

        // GET: api/mesasApi/5
        [ResponseType(typeof(mesaRestauranteDTO))]
        public async Task<IHttpActionResult> Getmesa(int id)
        {
            var mesa = (from m in db.mesa
                join r in db.restaurante on m.restaurante_id_fk equals r.restaurante_id
                where m.mesa_id == id
                select new mesaRestauranteDTO()
                {
                    mesa_id = m.mesa_id,
                    nombreRestaurante = r.nombre,
                    restaurante_id = r.restaurante_id
                }).SingleOrDefault();
            return Ok(mesa);
        }

        // PUT: api/mesasApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmesa(int id, mesa mesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mesa.mesa_id)
            {
                return BadRequest();
            }

            db.Entry(mesa).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mesaExists(id))
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

        // POST: api/mesasApi
<<<<<<< HEAD
        [ResponseType(typeof(mesa))]
=======
        [ResponseType(typeof(List<mesa>))]
>>>>>>> f867b1ba152e56f668904db0f186a95288920d30
        public async Task<IHttpActionResult> Postmesa(List<mesa> mesa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var m in mesa)
            {
                db.mesa.Add(m);
                await db.SaveChangesAsync();
            }

<<<<<<< HEAD
            return CreatedAtRoute("DefaultApi", new {id = mesa[1].mesa_id}, mesa);
=======
            return CreatedAtRoute("DefaultApi", new {id = mesa[0].mesa_id}, mesa);
>>>>>>> f867b1ba152e56f668904db0f186a95288920d30
        }

        // DELETE: api/mesasApi/5
        [ResponseType(typeof(mesa))]
        public async Task<IHttpActionResult> Deletemesa(int id)
        {
            mesa mesa = await db.mesa.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            db.mesa.Remove(mesa);
            await db.SaveChangesAsync();

            return Ok(mesa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool mesaExists(int id)
        {
            return db.mesa.Count(e => e.mesa_id == id) > 0;
        }
    }
}