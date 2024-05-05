using Microsoft.AspNetCore.Mvc;
using task9.Models;
using Task9.Core.Services;

namespace Task9.Core
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _context;

        public StudentsController(IStudentService context)
        {
            _context = context;
        }

        // GET: Students
        public Task<IActionResult> Index()
        {
            //  var group =  _groupService.Get(id)
            var students = _context.GetAll();

            return Task.FromResult<IActionResult>(View(students));
        }

        // GET: Students/Details/5

        public async Task<IActionResult> Details(int id)
        {
            var student = _context.Get(id);
            return View(student);
        }
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Students == null)
        //    {
        //        return NotFound();
        //    }

        //    var student = await _context.Students
        //        .Include(s => s.Group)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(student);
        //}

        // GET: Students/Create
        //public IActionResult Create()
        //{
        //    ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id");
        //    return View();
        //}

        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GroupId")] Student student)
        {
            //if (ModelState.IsValid)
            //{
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", student.GroupId);
            _context.Add(student);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            //ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", student.GroupId);
            //return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //if (id == null || _context.Students == null)
            //{
            //    return NotFound();
            //}

            var student = _context.Get(id);
            _context.Update(student);
            return View(student);
        }

        // GET: Students/Delete/5
        public Task<IActionResult> Delete(int id)
        {
            //if (id == null || _context.Students == null)
            //{
            //    return NotFound();
            //}

            var student = _context.Get(id);
            _context.Delete(student);
            return Task.FromResult<IActionResult>(RedirectToAction(nameof(Index)));
        }
    }
}
