using EmployeesProj.Models.Entities;
using EmployeesProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesProj.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeService service;

        public EmployeesController(EmployeeService service)
        {
            this.service = service;
        }

        //IAboutService aboutService;

        //public EmployeesController(IAboutService myService)
        //{
        //    this.aboutService = myService;
        //}

        [Route("")]
        [Route("index")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = service.GetAll();
            return View(model);
        }

        [Route("/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/create")]
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            service.Add(employee);
            
            return RedirectToAction(nameof(Index));
        }

        [Route("/details/{id}")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = service.GetById(id);
            return View(model);
        }


    }
}
