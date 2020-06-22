namespace InterviewTask.Web.App.Controllers
{
    using App.Models;
    using BindingModels.Employee;
    using ViewModels.Employee;
    using Microsoft.AspNetCore.Mvc;
    using Services.Employee;
    using Services.Mapping;
    using Services.Models.Employee;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpGet(Name = "Employees")]
        public async Task<IActionResult> Employees(int id) 
        {
            List<EmployeeViewModel> employees = await this.employeeService
                .GetAllEmployeesAsync(id);

            return View(employees);
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(int id, EmployeeBindingModel employeeBindingModel)
        {
            EmployeeServiceModel employeeServiceModel = AutoMapper.Mapper
              .Map<EmployeeServiceModel>(employeeBindingModel);

            await this.employeeService.AddEmployeeAsync(id, employeeServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            EmployeeBindingModel employeeBindingModel = (await this.employeeService
                .GetInfoAsync(id))
                .To<EmployeeBindingModel>();

            if (employeeBindingModel == null)
            {
                return this.Redirect("/Employee/Employees");
            }

            return this.View(employeeBindingModel);
        }

        [HttpPost(Name = "Edit")]
        public async Task<IActionResult> Edit(int id, EmployeeBindingModel employeeBindingModel)
        {
            EmployeeServiceModel employeeServiceModel = AutoMapper.Mapper
             .Map<EmployeeServiceModel>(employeeBindingModel);

            await this.employeeService.EditEmployeeAsync(id, employeeServiceModel);

            return this.Redirect("/Employee/Employees");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            EmployeeDeleteModel employeeDeleteViewModel = (await this.employeeService
                .GetInfoAsync(id))
                .To<EmployeeDeleteModel>();

            if (employeeDeleteViewModel == null)
            {
                return this.Redirect("/");
            }

            return this.View(employeeDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await this.employeeService.RemoveEmployeeAsync(id);

            return this.Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
