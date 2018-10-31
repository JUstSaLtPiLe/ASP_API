using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_API2.Models;

namespace Student_API2.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
            if (!_context.Students.Any())
            {
                _context.Students.Add(new Student()
                {
                    Name = "Xuan Hung",
                    RollNumber = "A012"
                });
                _context.Students.Add(new Student()
                {
                    Name = "Xuan Hang",
                    RollNumber = "A013"
                });
                _context.Students.Add(new Student()
                {
                    Name = "Xuan Hinh",
                    RollNumber = "A014"
                });
                _context.Students.Add(new Student()
                {
                    Name = "Xuan Hong",
                    RollNumber = "A015"
                });
                _context.SaveChanges();
            }
        }
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult GetById(long id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Json(student);
        }

        public IActionResult Store(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Update(long id, [FromBody]Student studentChanges)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            student.Name = studentChanges.Name;
            student.RollNumber = studentChanges.RollNumber;
            student.Avatar = studentChanges.Avatar;

            _context.Students.Update(student);
            _context.SaveChanges();
            return Json(student);
        }

        public IActionResult Delete(long id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}