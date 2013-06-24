using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estelle.Web.Controllers
{
    public class HomeController : Controller
    {
        public IService.IVehicleService VehicleService { get; set; }
        public IService.IVehicleService AopVehicleService = Service.GetService.GetAopService<IService.IVehicleService>("AopVehicleService");

        public ActionResult Index()
        {
            ViewBag.Message = "所有型号信息";            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult VehicleInfo()
        {
            ViewBag.Message = "品牌及型号信息";



            return View("VehicleInfo");
        }


        [HttpGet]
        public ActionResult ListAllVehicle()
        {
            List<Estelle.Models.VehicleInfo> VehicleInfoList = VehicleService.ListAllVehicle();

            return Json(VehicleInfoList, JsonRequestBehavior.AllowGet);            
        }

    }
}
