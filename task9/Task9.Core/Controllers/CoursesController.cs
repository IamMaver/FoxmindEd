using Microsoft.AspNetCore.Mvc;
using task9.Models;
using Task9.Core.Services;

namespace Task9.Core
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService service)
        {
            _courseService = service;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAll();
            return View(courses);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.Get(id);
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
            await _courseService.Add(course);
            return RedirectToAction(nameof(Index));
        }

        // GET: Courses/Edit/5

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.Get(id);
            await _courseService.Update(course);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameCourse,Description")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }
            await _courseService.Update(course);
            return RedirectToAction(nameof(Index));
        }

        // GET: Courses/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {

            var course = await _courseService.Get(id);
            if (course == null)
            {
                return NotFound();
            }
            await _courseService.Delete(course);
            return View();
        }
    }
}