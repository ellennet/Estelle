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
            
            Estelle.Models.VehicleBrand VehicleBrandModel = AopVehicleService.GetVehicleBrandByID(new Guid("3202e290-5440-4bf4-a0f5-7b59938de519"));


            VehicleBrandModel.BrandName="12321";


            AopVehicleService.UpdateVehicleBrand(VehicleBrandModel);


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

        [HttpGet]
        public ActionResult ListAllVehicle(string type)
        {
            List<Estelle.Models.VehicleInfo> VehicleInfoList = new List<Estelle.Models.VehicleInfo>();

            if (type == "1")
            {
                VehicleInfoList = AopVehicleService.ListAllInfo();
            }
            if (type == "2")
            {
                VehicleInfoList = AopVehicleService.ListAllTypeWithGermanyGT18();
            }

            
            
            return Json(VehicleInfoList, JsonRequestBehavior.AllowGet);            
        }

    }
}
