using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task9.Models;
using Task9.Core.Services;

namespace Task9.Core
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _context;

        public CoursesController(ICourseService context)
        {
            _context = context;
        }

        // GET: Courses
        public Task<IActionResult> Index()
        {
            var courses = _context.GetAll();
            return Task.FromResult<IActionResult>(View(courses));
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var course = _context.Get(id);
            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameCourse,Description")] Course course)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(course);
                return RedirectToAction(nameof(Index));
            //}
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var course = _context.Get(id);
            _context.Update(course);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var course = _context.Get(id);
            if (course == null)
            {
                return NotFound();
            }
            _context.Delete(course);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
