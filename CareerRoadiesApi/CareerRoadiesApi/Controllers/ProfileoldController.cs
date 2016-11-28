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
using CareerRoadiesApi.Models;

namespace CareerRoadiesApi.Controllers
{
    public class ProfileOldController : ApiController
    {
        private CREntities db = new CREntities();


        [HttpGet]
        // GET api/Profile
        public IQueryable<userprofile> Getprofiles()
        {
            return db.userprofiles;
        }

        // GET api/Profile/5
        [ResponseType(typeof(userprofile))]
        public async Task<IHttpActionResult> Getprofile(int id)
        {
            userprofile profile = await db.userprofiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT api/Profile/5
        [HttpPost]
        public async Task<IHttpActionResult> Putprofile(int id, userprofile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.ID)
            {
                return BadRequest();
            }

            db.Entry(profile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!profileExists(id))
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

        // POST api/Profile
        [ResponseType(typeof(userprofile))]
        [HttpPost]
        public async Task<IHttpActionResult> saveprofile(userprofile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.userprofiles.Add(profile);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (profileExists(profile.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = profile.ID }, profile);
        }

        // DELETE api/Profile/5
        [ResponseType(typeof(userprofile))]
        public async Task<IHttpActionResult> Deleteprofile(int id)
        {
            userprofile profile = await db.userprofiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            db.userprofiles.Remove(profile);
            await db.SaveChangesAsync();

            return Ok(profile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool profileExists(int id)
        {
            return db.userprofiles.Count(e => e.ID == id) > 0;
        }
    }
}