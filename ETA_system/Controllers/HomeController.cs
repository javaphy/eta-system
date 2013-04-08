using System;
using System.Web.Mvc;
using ETA_system.Models;
using ETA_system.Repositories;

namespace ETA_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<WorkOrder> repository;

        public HomeController()
        {
            repository = new Repository<WorkOrder>();
        }

        public ActionResult Index()
        {
            var workOrder = new WorkOrder
                                {
                                    OrderNumber = "800341482",
                                    CustomerName = "TD Bank",
                                    MachineModel = "MP C4500",
                                    MachineSerialNumber = "S7914CB1027",
                                    Status = "Waiting",
                                    Province = "Ontario",
                                    PlaceOrderTime = Convert.ToDateTime("2013-03-16"),
                                    PrintOrderTime = Convert.ToDateTime("2013-03-22"),
                                    ReceivedInPreflightTime = DateTime.Now,
                                    EstimatedTimeofComplete = DateTime.Now.AddDays(5),
                                    PlannedDeliveryTime = Convert.ToDateTime("2013-04-15"),
                                    ActualPreflightCompleteTime = Convert.ToDateTime("2013-04-09"),
                                    TechName = "Jackie/1226",
                                    Comments = "Checklist / Mac address:00.26.73.52.0a.6a",

                                };
            

            repository.SaveOrUpdate(workOrder);

            return View();
        }
    }
}
