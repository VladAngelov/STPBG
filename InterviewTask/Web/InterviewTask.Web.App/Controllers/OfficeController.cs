using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTask.Services.Office;
using InterviewTask.Web.ViewModels.Office;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask.Web.App.Controllers
{
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
        public async Task<IActionResult> Offices(int companyId)
        {
            List<OfficeViewModel> offices = await this.officeService
                .GetMyAllOfficesAsync(companyId);

            return View(offices);
        }
    }
}
