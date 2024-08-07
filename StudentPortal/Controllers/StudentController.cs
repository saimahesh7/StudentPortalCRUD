using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models.Entities;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var studentList = dbContext.Students.ToList();
            return View(studentList);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult UpdateStudent(Guid? id)
        {
            if (id == null)
            {
                return NotFound("Student Id is null");
            }
            var student = dbContext.Students.FirstOrDefault(x => x.StudentId == id);
            if (student == null)
            {
                return NotFound($"Student Not found with the id {id} you provided");
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            if (student == null)
            {
                return NotFound("The Student With Given Id is not found to update");
            }

            dbContext.Students.Update(student);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult RemoveStudent(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var student=dbContext.Students.FirstOrDefault(s => s.StudentId == id);

            return View(student);
        }

        [HttpPost]
        public IActionResult RemoveStudent(Student student)
        {
            if (student == null)
            {
                return NotFound("The Student With Given Id is not found to update");
            }

            dbContext.Students.Remove(student);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
