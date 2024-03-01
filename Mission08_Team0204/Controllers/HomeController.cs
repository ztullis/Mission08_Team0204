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
            var listOfTasks = _repo.Tasks
                .Where(t => t.IsCompleted == false).ToList();

            return View("Index", listOfTasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.CategoryViewBag = _repo.Categories
                .OrderBy(x => x.CategoryName).ToList();

            var newTask = new Mission08_Team0204.Models.Task();
            return View(newTask);
        }

        [HttpPost]
        public IActionResult AddTask(Mission08_Team0204.Models.Task response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response);
                return RedirectToAction("Index");
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

            ViewBag.CategoryViewBag = _repo.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Mission08_Team0204.Models.Task updatedTask)
        {
            if (ModelState.IsValid)
            {
                _repo.EditTask(updatedTask);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CategoryViewBag = _repo.Categories
                .OrderBy(x => x.CategoryName).ToList();

                return View("AddMovie", updatedTask);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var taskToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View("ConfirmDelete", taskToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Mission08_Team0204.Models.Task taskToDelete)
        {
            _repo.DeleteTask(taskToDelete);

            return RedirectToAction("Index");
        }
    }
}
