using System;
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
using WebApiEF;
using WebApiEF.Models;

namespace WebApiEF.Controllers
{
    public class MajorsController : ApiController
    {
        private EducationContext db = new EducationContext();

        // GET: api/Majors
        public IQueryable<Major> GetMajors()
        {
            return db.Majors;
        }

        // GET: api/Majors/5
        [ResponseType(typeof(Major))]
        public async Task<IHttpActionResult> GetMajor(int id)
        {
            Major major = await db.Majors.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }

            return Ok(major);
        }

        // PUT: api/Majors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMajor(int id, Major major)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != major.Id)
            {
                return BadRequest();
            }

            db.Entry(major).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MajorExists(id))
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

        // POST: api/Majors
        [ResponseType(typeof(Major))]
        public async Task<IHttpActionResult> PostMajor(Major major)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Majors.Add(major);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = major.Id }, major);
        }

        // DELETE: api/Majors/5
        [ResponseType(typeof(Major))]
        public async Task<IHttpActionResult> DeleteMajor(int id)
        {
            Major major = await db.Majors.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }

            db.Majors.Remove(major);
            await db.SaveChangesAsync();

            return Ok(major);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MajorExists(int id)
        {
            return db.Majors.Count(e => e.Id == id) > 0;
        }
    }
}