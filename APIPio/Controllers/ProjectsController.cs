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
using APIPio.Models;
using System.Web.Http.Cors;

namespace APIPio.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ProjectsController : ApiController
    {
        private ApplicationDbContext _db;


        public ProjectsController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        // GET: api/Projects
        public IQueryable<Project> Gettasks()
        {
            return _db.projects.Where(x => x.IsActive == true);
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> GetProject(int id)
        {
            Project project = await _db.projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

            _db.Entry(project).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> PostProject(Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            project.IsActive = true;
            _db.projects.Add(project);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public async Task<IHttpActionResult> DeleteProject(int id)
        {
            Project project = await _db.projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _db.projects.Remove(project);
            await _db.SaveChangesAsync();

            return Ok(project);
        }

        [Route("api/Projects/SetFlag/{id}")]
        public async Task<IHttpActionResult> SetFlag(int id)
        {
            Project project = await _db.projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _db.projects.Find(id).IsActive = !_db.projects.Find(id).IsActive;
            await _db.SaveChangesAsync();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return _db.projects.Count(e => e.Id == id) > 0;
        }
    }
}