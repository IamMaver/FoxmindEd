using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using task9.Models;
using Task9.Core.Services;

namespace Task9.Core.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService service)
        {
            _groupService = service;
        }

        // GET: Groups
        public async Task<IActionResult> Index(int id)
        {
            if (id == 0) id = (int)TempData["CourseId"];
            ViewBag.CourseId = id;
            TempData["CourseId"] = id;
            var groups = await _groupService.GetAll4Course(id);
            return View(groups);
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var group = await _groupService.Get(id);
            return View(group);
        }

        public async Task<IActionResult> Create(int courseId)
        {
            ViewData["CourseId"] = new SelectList(new List<int> { courseId });
            TempData["CourseId"] = courseId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,CourseId")] Group group)
        {
            int cId = Convert.ToInt32(TempData["CourseId"]);
            group.CourseId = cId;
            await _groupService.Add(group);
            return RedirectToAction(nameof(Index), new { id = cId });
        }

        // GET: Groups/Edit/5

        public async Task<IActionResult> Edit(int id)
        {
            var group = await _groupService.Get(id);
            await _groupService.Update(group);
            return View(group);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CourseId")] Group group)
        {
            await _groupService.Update(group);
            return RedirectToAction(nameof(Index));
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            int cId = Convert.ToInt32(TempData["CourseId"]);
            var group = await _groupService.Get(id);
            await _groupService.Delete(group);
            return RedirectToAction(nameof(Index), new { id = cId });
        }
    }
}