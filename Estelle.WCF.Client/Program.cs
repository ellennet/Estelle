using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;
using Estelle.WCF.Contracts;
using Estelle.Models;

namespace Estelle.WCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pause();
                IApplicationContext ctx = ContextRegistry.GetContext();
                foreach (IWcfVehicleService WcfVehicleService in ctx.GetObjectsOfType(typeof(IWcfVehicleService)).Values)
                {
                    try
                    {
                        List<VehicleInfo> vehicleInfoList = WcfVehicleService.ListAllInfo();

                        vehicleInfoList.ForEach(list =>
                        {
                            string s = list.BrandName + "," + list.Nationality + "," + list.Type + "," + list.EngineDisplacement + "," + list.Turbo;
                            Console.WriteLine(s);
                        });

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Pause();
            }
        }

        public static void Pause()
        {
            Console.Write("--- Press <return> to continue ---");
            Console.ReadLine();
        }
    }
}
