namespace InterviewTask.Web.App.Controllers
{
    using BindingModels.Office;
    using InterviewTask.Services.Company;
    using InterviewTask.Web.ViewModels.Company;
    using Microsoft.AspNetCore.Mvc;
    using Services.Models.Office;
    using Services.Office;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ViewModels.Office;

    public class OfficeController : Controller
    {
        private readonly IOfficeService officeService;
        private readonly ICompanyService companyService;
        
        public OfficeController(IOfficeService officeService
                                , ICompanyService companyService)
        {
            this.officeService = officeService;
            this.companyService = companyService;
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
    }
}
