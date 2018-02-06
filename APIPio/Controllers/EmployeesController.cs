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
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _db;


        public EmployeesController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        // GET: api/Employees
        public IEnumerable<Employee> Getemployees()
        {
            return _db.employees.Where(x => x.IsActive == true).ToList();
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            Employee employee = await _db.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            _db.Entry(employee).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            employee.IsActive = true;
            _db.employees.Add(employee);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            Employee employee = await _db.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _db.employees.Remove(employee);
            await _db.SaveChangesAsync();

            return Ok(employee);
        }

        [Route("api/Employees/SetFlag/{id}")]
        public async Task<IHttpActionResult> SetFlag(int id)
        {
            Employee employee = await _db.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _db.employees.Find(id).IsActive = !_db.employees.Find(id).IsActive;
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

        private bool EmployeeExists(int id)
        {
            return _db.employees.Count(e => e.Id == id) > 0;
        }
    }
}