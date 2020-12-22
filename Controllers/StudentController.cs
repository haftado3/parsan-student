
using Microsoft.AspNetCore.Mvc;
using com_parsan_student.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace com_parsan_student.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly DataContext _context;
        public StudentController(DataContext _context)
        {
            this._context = _context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> getAll()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> get(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult> create(Student std)
        {
            _context.Students.Add(std);
            await _context.SaveChangesAsync();
            return CreatedAtAction("get", new { id = std.Id }, std);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> update(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
            _context.Entry(std).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return std;
            }
            catch
            {
                if (!_context.Students.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                throw;
            }
        }
    }
}