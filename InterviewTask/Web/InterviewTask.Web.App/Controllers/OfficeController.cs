namespace InterviewTask.Web.App.Controllers
{
    using App.Models;
    using BindingModels.Office;
    using Microsoft.AspNetCore.Mvc;
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
            List<OfficeServiceModel> officesServiceModel = await this.officeService
                .GetMyAllOfficesAsync(id);

            List<OfficeViewModel> offices = officesServiceModel.To<List<OfficeViewModel>>();

            return View(offices);
        }

        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(int id)
        {
            OfficeServiceModel office = await this.officeService.GetByIdAsync(id);

            return View(office.To<OfficeViewModel>());
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost(Name = "Create")]
        public async Task<IActionResult> Create(int id, OfficeBindingModel officeBindingModel)
        {
            OfficeServiceModel officeServiceModel = AutoMapper.Mapper
              .Map<OfficeServiceModel>(officeBindingModel);

            await this.officeService.CreateOfficeAsync(id, officeServiceModel);

            return this.Redirect("/");
        }


        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            OfficeBindingModel officeBindingModel = (await this.officeService
                .GetByIdAsync(id))
                .To<OfficeBindingModel>();
                       
            if (officeBindingModel == null)
            {
                return this.Redirect("/");
            }

            return this.View(officeBindingModel);
        }

        [HttpPost(Name = "Edit")]
        public async Task<IActionResult> Edit(int id, OfficeBindingModel officeBindingModel)
        {
            OfficeServiceModel officeServiceModel = AutoMapper.Mapper
             .Map<OfficeServiceModel>(officeBindingModel);

            await this.officeService.EditOfficeAsync(id, officeServiceModel);

            return this.Redirect("/");
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
