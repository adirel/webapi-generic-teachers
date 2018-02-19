using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using DemoWebAPIPrj.Models;

namespace DemoWebAPIPrj.Controllers
{
    public class MISROT_LEMORIMController : ApiController
    {
        private EntitiesModel db = new EntitiesModel();

        // GET: api/MISROT_LEMORIM
        public IQueryable<MISROT_LEMORIM> GetMISROT_LEMORIM()
        {
            return db.MISROT_LEMORIM;
        }

        // GET: api/MISROT_LEMORIM/5
        [ResponseType(typeof(MISROT_LEMORIM))]
        public IHttpActionResult GetMISROT_LEMORIM(long id)
        {
            MISROT_LEMORIM mISROT_LEMORIM = db.MISROT_LEMORIM.Find(id);
            if (mISROT_LEMORIM == null)
            {
                return NotFound();
            }

            return Ok(mISROT_LEMORIM);
        }

        // PUT: api/MISROT_LEMORIM/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMISROT_LEMORIM(long id, MISROT_LEMORIM mISROT_LEMORIM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mISROT_LEMORIM.SEQ_NUM)
            {
                return BadRequest();
            }

            db.Entry(mISROT_LEMORIM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MISROT_LEMORIMExists(id))
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

        // POST: api/MISROT_LEMORIM
        [ResponseType(typeof(MISROT_LEMORIM))]
        public IHttpActionResult PostMISROT_LEMORIM(MISROT_LEMORIM mISROT_LEMORIM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MISROT_LEMORIM.Add(mISROT_LEMORIM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MISROT_LEMORIMExists(mISROT_LEMORIM.SEQ_NUM))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mISROT_LEMORIM.SEQ_NUM }, mISROT_LEMORIM);
        }

        // DELETE: api/MISROT_LEMORIM/5
        [ResponseType(typeof(MISROT_LEMORIM))]
        public IHttpActionResult DeleteMISROT_LEMORIM(long id)
        {
            MISROT_LEMORIM mISROT_LEMORIM = db.MISROT_LEMORIM.Find(id);
            if (mISROT_LEMORIM == null)
            {
                return NotFound();
            }

            db.MISROT_LEMORIM.Remove(mISROT_LEMORIM);
            db.SaveChanges();

            return Ok(mISROT_LEMORIM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MISROT_LEMORIMExists(long id)
        {
            return db.MISROT_LEMORIM.Count(e => e.SEQ_NUM == id) > 0;
        }
    }
}