using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppMvcDemo.Models;
using WebAppMvcDemo.Services;

namespace WebAppMvcDemo.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly EmployeeService _employeeService = new EmployeeService();

        // GET: EmpleadosController
        public async Task<ActionResult> Index()
        {
            try
            {
                var employees = await _employeeService.GetEmpleadosAsync();

                return View(employees);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadosController/Edit/
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmpleadoByIdAsync(id);

                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(employee);

                await _employeeService.UpdateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(employee);

                await _employeeService.CreateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
