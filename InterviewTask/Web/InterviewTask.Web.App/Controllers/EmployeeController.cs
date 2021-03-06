﻿namespace InterviewTask.Web.App.Controllers
{
    using App.Models;
    using BindingModels.Employee;
    using Microsoft.AspNetCore.Mvc;
    using Services.Employee;
    using Services.Mapping;
    using Services.Models.Employee;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using ViewModels.Employee;

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
            List<EmployeeServiceModel> employees = await this.employeeService
                .GetAllEmployeesAsync(id);

            return View(employees.To<List<EmployeeViewModel>>());
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
        public async Task<IActionResult> Edit(string id)
        {
            var companyOffices = await this.employeeService.GetCompanyOfficesAsync(id);

            Dictionary<int, string> officesAddresses = new Dictionary<int, string>();

            for (int i = 0; i < companyOffices.Count; i++)
            {
                officesAddresses.Add(companyOffices[i].Id, 
                    $"{companyOffices[i].Country}, {companyOffices[i].City}, " +
                    $"{companyOffices[i].Street}, {companyOffices[i].StreetNumber}");
            }

            ViewData["AllOffices"] = officesAddresses;

            EmployeeBindingModel employeeServiceModel = (await this.employeeService
                .GetInfoAsync(id)).To<EmployeeBindingModel>();

            if (employeeServiceModel == null)
            {
                return this.Redirect("/Employee/Employees");
            }

            return this.View(employeeServiceModel);
        }

        [HttpPost(Name = "Edit")]
        public async Task<IActionResult> Edit(string id, EmployeeBindingModel employeeBindingModel)
        {
            EmployeeServiceModel employeeServiceModel = AutoMapper.Mapper
             .Map<EmployeeServiceModel>(employeeBindingModel);

            await this.employeeService.EditEmployeeAsync(id, employeeServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(string id)
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
        public async Task<IActionResult> DeleteAsync(string id)
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
