using Employee_API.Data;
using Employee_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDto em)
        {   

            Employee e  =  new Employee();
            e.Firstname = em.Firstname; 
            e.Lastname = em.Lastname; 
            e.Email = em.Email;
            e.Pincode = em.Pincode;
            e.DateOfBirth = em.DateOfBirth;
            e.City = em.City;
            e.CurrentAddress= em.CurrentAddress;
            e.CurrentCTC = em.CurrentCTC;   
            e.DocumentNumber = em.DocumentNumber;
            e.EmploymentType = em.EmploymentType;
            e.AlternateNumber = em.AlternateNumber;
            e.CompanyName = em.CompanyName; 
            e.JoiningDate = em.JoiningDate;
            e.DocumentType = em.DocumentType;
            e.Nationality = em.Nationality;
            e.State = em.State; 
            e.MobileNumber = em.MobileNumber;
            e.PermanentAddress = em.PermanentAddress;
        
            _context.Employee.Add(e);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = e.EmpId }, e);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmpId == id);
        }
    }
}
