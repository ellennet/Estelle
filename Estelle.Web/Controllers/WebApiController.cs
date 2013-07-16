using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Estelle.Web.Controllers
{
    [EnableCors]
    public class WebApiController : ApiController
    {
        public IService.IVehicleService AopVehicleService = SpringNetHelper.GetService.GetAopService<IService.IVehicleService>("AopVehicleService");

        [HttpGet]
        [Queryable]
        public IQueryable<Estelle.Models.VehicleInfo> Get()
        {
            return AopVehicleService.ListAllInfo().AsQueryable();
        }
    }

    /*调用
        $.ajax({
            //url: "http://地址/api/WebApi",
            url: "http://地址/api/WebApi?$filter=BrandName eq 'abc' and Nationality eq 'nn'&$top=1",
            type: 'GET',
            dataType: 'jsonp',
            success: function (data) {                
                alert(data);
            }
        }).fail(
        function (xhr, textStatus, err) {
            alert('Error: ' + err);
        });      
    */
}
