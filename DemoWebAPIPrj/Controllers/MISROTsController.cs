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
    public class MISROTsController : ApiController
    {
        private EntitiesModel db = new EntitiesModel();

        // GET: api/MISROTs
        public IQueryable<MISROT> GetMISROT()
        {
            return db.MISROT;
        }

        // GET: api/MISROTs/5
        [ResponseType(typeof(MISROT))]
        public IHttpActionResult GetMISROT(int id)
        {
            MISROT mISROT = db.MISROT.Find(id);
            if (mISROT == null)
            {
                return NotFound();
            }

            return Ok(mISROT);
        }

        // PUT: api/MISROTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMISROT(int id, MISROT mISROT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mISROT.KOD_MISRA)
            {
                return BadRequest();
            }

            db.Entry(mISROT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MISROTExists(id))
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

        // POST: api/MISROTs
        [ResponseType(typeof(MISROT))]
        public IHttpActionResult PostMISROT(MISROT mISROT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MISROT.Add(mISROT);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MISROTExists(mISROT.KOD_MISRA))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mISROT.KOD_MISRA }, mISROT);
        }

        // DELETE: api/MISROTs/5
        [ResponseType(typeof(MISROT))]
        public IHttpActionResult DeleteMISROT(int id)
        {
            MISROT mISROT = db.MISROT.Find(id);
            if (mISROT == null)
            {
                return NotFound();
            }

            db.MISROT.Remove(mISROT);
            db.SaveChanges();

            return Ok(mISROT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MISROTExists(int id)
        {
            return db.MISROT.Count(e => e.KOD_MISRA == id) > 0;
        }
    }
}