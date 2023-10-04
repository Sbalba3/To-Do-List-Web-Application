using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using To_Do_List_Web_Application.Models;
using To_Do_List_Web_Application.Repositry;

namespace To_Do_List_Web_Application.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        ITaskRepo taskRepo;
        public TasksController(ITaskRepo _taskRepo)
        {
            taskRepo = _taskRepo;
            
        }
        
        public IActionResult Index()
        {
            
            List<Tasks> tasks = taskRepo.GetAll();

            return View(tasks);
        }
        public IActionResult Details(int id)
        {
            Tasks task = taskRepo.GetById(id);
            return View(task);

        }
        public IActionResult Create() 
        {
            return View();
        
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        
        public IActionResult Create(Tasks task)
        {
           taskRepo.Insert(task);
           taskRepo.Save();
           return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {

            Tasks task = taskRepo.GetById(id);


            return View(task);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
       
        public IActionResult Edit(Tasks task,int id)
        {
            taskRepo.Edit(id, task);
            taskRepo.Save();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Tasks task = taskRepo.GetById(id);
           
                taskRepo.Delete(task.Id);
                taskRepo.Save();
                return Content("sucsses");
        }
        public IActionResult changeState(int id)
        {
            Tasks task = taskRepo.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                task.IsCompleted = !task.IsCompleted;
                taskRepo.Save();
                return Ok();
            }
        }


    }
}
