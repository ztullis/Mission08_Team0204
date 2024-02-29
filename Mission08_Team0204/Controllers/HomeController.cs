using Microsoft.AspNetCore.Mvc;
using Mission08_Team0204.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Mission08_Team0204.Controllers
{ //Testing
    public class HomeController : Controller
    {
        private ITaskRepository _repo;
        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var listOfTasks = _repo.Tasks;
            //    .Include(m => m.Category);

            return View("Index", listOfTasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.CategoryViewBag = _repo.Categories
                .OrderBy(x => x.CategoryName);

            return View(new Mission08_Team0204.Models.Task());
        }

        [HttpPost]
        public IActionResult AddTask(Mission08_Team0204.Models.Task response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response);
                return View("Index", response);
            }
            else
            {
                ViewBag.CategoryViewBag = _repo.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            //ViewBag.TaskViewBag = _repo.Categories
            //    .OrderBy(x => x.CategoryName);

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Mission08_Team0204.Models.Task updatedTask)
        {
            if (ModelState.IsValid)
            {
                _repo.EditTask(updatedTask);
            }
            else
            {
                //ViewBag.CategoryViewBag = _repo.Categories
                //    .OrderBy(x => x.CategoryName)
                //    .ToList();
            }

            return View("Index", updatedTask);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var taskToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Mission08_Team0204.Models.Task taskToDelete)
        {
            _repo.DeleteTask(taskToDelete);

            return RedirectToAction("Index");
        }
    }
}
