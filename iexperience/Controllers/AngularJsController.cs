using Microsoft.AspNetCore.Mvc;
using iexperience.Entities;
using System;
using System.Data.SQLite;
using System.Data;
using iexperience.Services;
using iexperience.Models;
using System.Collections.Generic;
using System.Web.Http;
using websrc = System.Web.Http;
using System.Web.Http.Description;
using mvchttp = System.Web.Http;

namespace iexperience.Views.AngularJs
{
    public class AngularJsController : Controller
    {

        private readonly ICompanyService _compSvc;

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
            List<Company> companyList = null; int recordsTotal = 10;
            try
            {
                companyList = _compSvc.GetAllCompanies();
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
