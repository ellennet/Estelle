using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Estelle.WCF.Contracts
{        
    [ServiceContract]
    public interface IWcfVehicleService
    {
        [OperationContract]
        List<Estelle.Models.VehicleInfo> ListAllInfo();
    }
}
