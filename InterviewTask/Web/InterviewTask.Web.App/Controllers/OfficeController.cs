namespace InterviewTask.Web.App.Controllers
{
    using BindingModels.Office;
    using InterviewTask.Web.App.Models;
    using Microsoft.AspNetCore.Mvc;
    using Services.Company;
    using Services.Mapping;
    using Services.Models.Office;
    using Services.Office;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using ViewModels.Office;

    public class OfficeController : Controller
    {
        private readonly IOfficeService officeService;
        
        public OfficeController(IOfficeService officeService)
        {
            this.officeService = officeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(Name = "Offices")]
        public async Task<IActionResult> Offices(int id)
        {
            List<OfficeViewModel> offices = await this.officeService
                .GetMyAllOfficesAsync(id);

            return View(offices);
        }

        [HttpPost(Name = "Offices")]
        public async Task<IActionResult> OfficesAsync(int companyId)
        {
            List<OfficeViewModel> offices = await this.officeService
                .GetMyAllOfficesAsync(companyId);

            return View(offices);
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(int companyId, OfficeBindingModel officeBindingModel)
        {
            OfficeServiceModel officeServiceModel = AutoMapper.Mapper
              .Map<OfficeServiceModel>(officeBindingModel);

            await this.officeService.CreateOfficeAsync(companyId, officeServiceModel);

            return this.Redirect("/Office/Offices");
        }


        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            OfficeBindingModel officeBindingModel = (await this.officeService.GetByIdAsync(id)).To<OfficeBindingModel>();
                       
            if (officeBindingModel == null)
            {
                // TODO: Error Handling
                return this.Redirect("/Office/Offices");
            }

            return this.View(officeBindingModel);
        }

        [HttpPost(Name = "Edit")]
        public async Task<IActionResult> Edit(int id, OfficeBindingModel officeBindingModel)
        {
            OfficeServiceModel officeServiceModel = AutoMapper.Mapper
             .Map<OfficeServiceModel>(officeBindingModel);

            await this.officeService.EditOfficeAsync(id, officeServiceModel);

            return this.Redirect("/Office/Offices");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            OfficeDeleteModel officeDeleteViewModel = (await this.officeService.GetByIdAsync(id))
                .To<OfficeDeleteModel>();

            if (officeDeleteViewModel == null)
            {
                return this.Redirect("/");
            }

            return this.View(officeDeleteViewModel);
        }

        [HttpPost]
       // [Route("/Company/Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await this.officeService.DeleteOfficeAsync(id);

            return this.Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
