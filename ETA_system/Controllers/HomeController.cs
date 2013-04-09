using System;
using System.Web.Mvc;
using ETA_system.Models;
using ETA_system.Repositories;

namespace ETA_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<WorkOrder> repository;

        private readonly string[] provinces = new[]
                {
                    "Ontario", "Quebec", "British Columbia", "Alberta",
                    "Nova Scotia", "Saskatchewan", "Manitoba", "New Brunswick", "Prince Edward Island",
                    "Newfoundland and Labrador"
                };

        public HomeController()
        {
            repository = new Repository<WorkOrder>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Provinces = provinces;
            return View();
        }

        [HttpPost]
        public ActionResult Add(WorkOrder input)
        {
            input.ReceivedInPreflightTime = DateTime.Now;
            input.EstimatedTimeofComplete = DateTime.Now.AddDays(5);

            repository.SaveOrUpdate(input);

            return RedirectToAction("Index");
        }
    }
}
