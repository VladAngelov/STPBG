namespace InterviewTask.Web.App.Controllers
{
    using App.Models;
    using BindingModels.Company;
    using InterviewTask.Web.ViewModels.Company;
    using Microsoft.AspNetCore.Mvc;
    using Services.Company;
    using Services.Mapping;
    using Services.Models.Company;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet(Name = "Companies")]
        public async Task<IActionResult> Companies()
        {
            string username = User.Identity.Name;

            List<CompanyViewModel> companies = await this.companyService
                     .GetUserCompaniesAsync(username);

            return View(companies);
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create() 
        {
            return View();
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(CompanyBindingModel companyBindingModel)
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            CompanyServiceModel companyServiceModel = AutoMapper.Mapper
              .Map<CompanyServiceModel>(companyBindingModel);

            await this.companyService.CreateCompanyAsync(userId, companyServiceModel);

            return this.Redirect("/Home/Index");
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            CompanyServiceModel companyServiceModel = (await this.companyService.GetById(id));

            if (companyServiceModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            return this.View(companyServiceModel);
        }

        [HttpPost(Name = "Edit")]
        public async Task<IActionResult> Edit(int id, CompanyServiceModel companyServiceModel)
        {
            await this.companyService.EditCompanyAsync(id, companyServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            CompanyDeleteModel companyDeleteViewModel = (await this.companyService.GetById(id))
                .To<CompanyDeleteModel>();

            if (companyDeleteViewModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/");
            }

            return this.View(companyDeleteViewModel);
        }

        [HttpPost]
        [Route("/Company/Delete/{id}")]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            await this.companyService.DeleteCompanyAsync(id);

            return this.Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
