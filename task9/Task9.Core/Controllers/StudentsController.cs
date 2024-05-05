using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using task9.Models;
using Task9.Core.Services;

namespace Task9.Core.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService service)
        {
            _studentService = service;
        }

        // GET: Students
        public async Task<IActionResult> Index(int id)
        {

            if (id == 0) id = (int)TempData["GroupId"];
            ViewBag.GroupId = id;
            TempData["GroupId"] = id;
            var students = await _studentService.GetStudentsByGroupId(id);
            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.Get(id);
            return View(student);
        }

        public async Task<IActionResult> Create(int groupId)
        {
            ViewData["GroupId"] = new SelectList(new List<int> { groupId });
            TempData["GroupId"] = groupId;
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id,Name,GroupId")] Student student)
        {
            int gId = Convert.ToInt32(TempData["GroupId"]);
            student.GroupId = gId;  
            await _studentService.Add(student);
            return RedirectToAction(nameof(Index), new { id = gId });

        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.Get(id);
            _studentService.Update(student);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GroupId")] Student student)
        {
            int gId = Convert.ToInt32(TempData["GroupId"]);
            student.GroupId = gId;
            await _studentService.Update(student);
            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.Get(id);
            var gId=student.GroupId;    
            _studentService.Delete(student);
            return RedirectToAction(nameof(Index),new { id = gId });
        }
    }
}