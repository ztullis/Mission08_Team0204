using Microsoft.AspNetCore.Mvc;
//using Mission08_Team0204.Models;
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
            var allTasks = _repo.GetAllTasks();

            return View(allTasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.CategoryViewBag = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new Task());
        }

        [HttpPost]
        public IActionResult AddTask(Task response)
        {
            if ModelState.IsValid)
            {
                _repo.AddTask(response);
            }
            else
            {
                ViewBag.CategoryViewBag = _repo.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.GetTask(id);

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task updatedTask)
        {
            if ModelState.IsValid)
            {
                _repo.EditTask(updatedTask);
            }
            else
            {
                ViewBag.CategoryViewBag = _repo.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
            }

            return View("Index", updatedTask);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var taskToDelete = _repo.GetTask(id);

            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Task taskToDelete)
        {
            _repo.DeleteTask(taskToDelete);

            return RedirectToAction("Index");
        }
    }
}
