using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task3Api.Model;

namespace Task3Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseDbContext db;

        public CourseController(CourseDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult get()
        {
            var coursrs = db.Courses;
            if (coursrs == null) return NotFound();
            return Ok(coursrs);
            
        }
        [HttpDelete("{id}")]
        public IActionResult deleteCourse(int id) 
        {
            courses cors=db.Courses.Where(x=>x.ID==id).First();
            if (cors == null) return NotFound();
            return Ok(cors);
        }
        [HttpPut("{id:int}")]
        public IActionResult put(int id,courses course)
        {
            if (course == null) return NotFound();
            if(id!=course.ID)return BadRequest("Cheek Id");
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return NoContent();
            }
            return BadRequest(ModelState.Values);
            
        }
        [HttpPost]
        public IActionResult post(courses course)
        {
            if (course == null) return NotFound();
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return CreatedAtAction("getById", new {id=course.ID},course);
            }
            return BadRequest(ModelState.Values);
        }
        [HttpGet ("getById/{id:int}")]
        public IActionResult getById( int id)
        {
            courses cors = db.Courses.Where(x => x.ID == id).FirstOrDefault();
            if (cors == null) return NotFound();
            return Ok(cors);
        }
        [HttpGet("{name}")]
        public IActionResult couseByName(string name)
        {
            courses cors = db.Courses.Where(x => x.Crs_name == name).FirstOrDefault();
            if (cors == null) return NotFound();
            return Ok(cors);
        }
    }
}
