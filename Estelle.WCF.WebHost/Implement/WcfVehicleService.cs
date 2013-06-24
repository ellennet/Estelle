using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estelle.WCF.WebHost
{
    public class WcfVehicleService : Contracts.IWcfVehicleService
    {
        public IService.IVehicleService VehicleService { get; set; }        

        public List<Estelle.Models.VehicleInfo> ListAllVehicle()
        {
            return VehicleService.ListAllVehicle();
        }
    }
}