using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;

namespace Mvc4SpringNetDemo.WCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pause();

                IApplicationContext ctx = ContextRegistry.GetContext();
                foreach (Contracts.IWcfVehicleService WcfVehicleService in ctx.GetObjectsOfType(typeof(Contracts.IWcfVehicleService)).Values)
                {
                    try
                    {
                        List<Models.VehicleInfo> vehicleInfoList = WcfVehicleService.ListAllVehicle();

                        vehicleInfoList.ForEach(list =>
                        {
                            Console.WriteLine(string.Format("{0} {1} {2} {3} {4} {5}"), list.BrandName, list.Nationality, list.Type, list.EngineDisplacement, list.Turbo);
                        });

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine();
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
