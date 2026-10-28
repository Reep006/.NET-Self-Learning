
using Microsoft.AspNetCore.Mvc;
using StudentCourseRegistration.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentCourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> students = new()
        {
            new Student
            {
                Id = 1,
                Name = "Aarav Patel",
                Email = "aarav@example.com",
                Course = "Computer Engineering",
                Semester = 5
            },
            new Student
            {
                Id = 2,
                Name = "Diya Shah",
                Email = "diya@example.com",
                Course = "Information Technology",
                Semester = 5
            }
        };

        private static int nextId = 3;

        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            student.Id = nextId++;
            students.Add(student);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            Student? student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
