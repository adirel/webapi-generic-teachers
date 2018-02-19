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
using DemoWebAPIPrj.Models;

namespace DemoWebAPIPrj.Controllers
{
    public class MORIMsController : ApiController
    {
        private EntitiesModel db = new EntitiesModel();

        // GET: api/MORIMs
        public IQueryable<MORIM> GetMORIM()
        {
            return db.MORIM;
        }

        // GET: api/MORIMs/5
        [ResponseType(typeof(MORIM))]
        public IHttpActionResult GetMORIM(int id)
        {
            MORIM mORIM = db.MORIM.Find(id);
            if (mORIM == null)
            {
                return NotFound();
            }

            return Ok(mORIM);
        }

        // PUT: api/MORIMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMORIM(int id, MORIM mORIM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mORIM.ZEHUT)
            {
                return BadRequest();
            }

            db.Entry(mORIM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MORIMExists(id))
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

        // POST: api/MORIMs
        [ResponseType(typeof(MORIM))]
        public IHttpActionResult PostMORIM(MORIM mORIM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MORIM.Add(mORIM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MORIMExists(mORIM.ZEHUT))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mORIM.ZEHUT }, mORIM);
        }

        // DELETE: api/MORIMs/5
        [ResponseType(typeof(MORIM))]
        public IHttpActionResult DeleteMORIM(int id)
        {
            MORIM mORIM = db.MORIM.Find(id);
            if (mORIM == null)
            {
                return NotFound();
            }

            db.MORIM.Remove(mORIM);
            db.SaveChanges();

            return Ok(mORIM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MORIMExists(int id)
        {
            return db.MORIM.Count(e => e.ZEHUT == id) > 0;
        }
    }
}