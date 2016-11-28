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
using MySql.Data.MySqlClient;
using System.Configuration;
//using DataAccessLayer;


namespace CareerRoadiesApi.Controllers
{
    
    public class DemoController : ApiController
    {
        //private CREntities db = new CREntities();
        
        //SqlDataAccess obj = new SqlDataAccess();
        public DemoController()
        {
 
        }
       /* public HttpResponseMessage GetTest()
        {
            var  str ="select * from demo";
            var dt = obj.ExecuteDataTable(str);
            if (dt.Rows.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            else
            {
                return null;
            }
        }*/
        
        //public MySqlConnection GetConeection()
        //{
        //    string str = string.Empty;
        //    str = ConfigurationSettings.AppSettings["cofigstring"];
        //    var conn = new MySqlConnection(str);
        //    conn.Open();
        //    return conn;
        //}
        //// GET api/Demo
        //public IQueryable<demo> GetDemoes()
        //{
        //    try
        //    {
        //        return db.demoes;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //// GET api/Demo/5
        //[ResponseType(typeof(demo))]
        //public async Task<IHttpActionResult> GetDemo(int id)
        //{
        //    demo demo = await db.demoes.FindAsync(id);
        //    if (demo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(demo);
        //}

        //// PUT api/Demo/5
        //public async Task<IHttpActionResult> PutDemo(int id, demo demo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != demo.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(demo).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DemoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/Demo
        //[ResponseType(typeof(demo))]
        //public async Task<IHttpActionResult> PostDemo(demo demo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.demoes.Add(demo);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = demo.id }, demo);
        //}

        //// DELETE api/Demo/5
        //[ResponseType(typeof(demo))]
        //public async Task<IHttpActionResult> DeleteDemo(int id)
        //{
        //    demo demo = await db.demoes.FindAsync(id);
        //    if (demo == null)
        //    {
        //        return NotFound();
        //    }

        //    db.demoes.Remove(demo);
        //    await db.SaveChangesAsync();

        //    return Ok(demo);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool DemoExists(int id)
        //{
        //    return db.demoes.Count(e => e.id == id) > 0;
        //}

        //public string ConfigurationSettinges { get; set; }
    }
}