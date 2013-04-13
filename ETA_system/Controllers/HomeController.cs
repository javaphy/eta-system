using System;
using System.Linq;
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
            ViewBag.Rows = repository.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Provinces = provinces;
            return View();
        }

        [HttpPost]
        public ActionResult Add(WorkOrder input)
        {
            input.Status = WorkOrder.StatusTypes.Picking;
            input.ReceivedInPreflightTime = DateTime.Now;
            input.EstimatedTimeOfComplete = DateTime.Now.AddDays(5);

            input.OrderNumber = input.OrderNumber.Trim().ToUpper();

            repository.SaveOrUpdate(input);

            return RedirectToAction("Index");
        }

        public ActionResult Management()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult PendingComplete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PendingComplete(PendingCompleteInput input)
        {
            if(!Update(input))
                Redirect("OrderNumberNotFound");

            return RedirectToAction("Index");
        }

        private bool Update(PendingCompleteInput input)
        {
            input.OrderNumber = input.OrderNumber.Trim().ToUpper();

            var workOrder = repository.Get(x => x.OrderNumber == input.OrderNumber).FirstOrDefault();

            if (workOrder == null)
                return false;

            var status = WorkOrder.StatusTypes.Complete;

            if (input.Submit == "Pending")
                status = WorkOrder.StatusTypes.Pending;
            
            
            workOrder.Status = status;
            workOrder.Comments = input.Comments;
            workOrder.ActualPreflightCompleteTime = DateTime.Now;

            repository.SaveOrUpdate(workOrder);

            return true;
        }

        public class PendingCompleteInput
        {
            public string OrderNumber { get; set; }
            public string Comments { get; set; }
            public string Submit { get; set; }
        }
    }
}
