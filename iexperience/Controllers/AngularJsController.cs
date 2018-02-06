using Microsoft.AspNetCore.Mvc;
using iexperience.Entities;
using System;
using iexperience.Services;
using System.Collections.Generic;
using System.Web.Http.Description;
using mvchttp = System.Web.Http;
using System.Linq;

namespace iexperience.Views.AngularJs
{
    public class AngularJsController : Controller
    {

        readonly ICompanyService _compSvc;

        // All interfaces needs to be registered in the Startup.cs for dependency injection
        public AngularJsController(ICompanyService compSvc)
        {
            _compSvc = compSvc;
        }

        // GET: /<controller>/
        public IActionResult MyPage()
        {
            return View();
        }

        [mvchttp.HttpGet, ResponseType(typeof(Company))]
        public JsonResult GetAllCompanies()
        {
            List<Company> companyList = null; int recordsTotal = 0;
            try
            {
                companyList = _compSvc.GetAllCompanies().ToList();
                recordsTotal = companyList.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new
            {
                recordsTotal,
                companyList
            });
        }
    }
}
