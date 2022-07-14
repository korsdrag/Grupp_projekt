using EmployeesProj.Models.Entities;
using EmployeesProj.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeesProj.Views.Employees;

namespace EmployeesProj.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeService service;

        public EmployeesController(EmployeeService service)
        {
            this.service = service;
        }


        [Route("")]
        [Route("/index")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = service.GetEmployeeIndex();
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
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            service.PostCreate(model);
            
            return RedirectToAction(nameof(Index));
        }

        [Route("/addcompany")]
        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }

        [Route("/addcompany")]
        [HttpPost]
        public IActionResult AddCompany(AddCompanyVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            service.PostCompany(model);

            return RedirectToAction(nameof(Index));
        }


        [Route("/delete/{id}")]
        [HttpGet]
        public IActionResult RemoveEmployee(int id)
        {
            service.PostRemoveEmployee(id);
            return RedirectToAction(nameof(Index));
        }

        //[Route("/delete/{id}")]
        //[HttpGet]
        //public IActionResult RemoveCompany(int id)
        //{
        //    service.PostRemoveCompany(id);
        //    return RedirectToAction(nameof(Index));
        //}


        
        [Route("/details/{id}")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = service.GetEmployeeDetails(id);
            return View(model);
        }
        
        [Route("/listcompanies")]
        [HttpGet]
        public IActionResult ListCompanies(int id)
        {
            var model = service.GetCompanyIndex();
            return View(model);
        }

        [Route("/companydetails/{id}")]
        [HttpGet]
        public IActionResult CompanyDetails(int id)
        {
            var model = service.GetCompanyDetails(id);
            return View(model);
        }

    }
}
