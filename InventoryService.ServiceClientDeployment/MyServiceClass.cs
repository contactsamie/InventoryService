﻿using Microsoft.Owin.Hosting;
using System.Configuration;

namespace InventoryService.ServiceClientDeployment
{
    public class MyServiceClass
    {
        public void Start()
        {
            var address = ConfigurationManager.AppSettings["ServerEndPoint"];
            // Start OWIN host
            using (WebApp.Start<Startup>(url: address))
            {
                System.Console.WriteLine("Server started ...");
                System.Console.ReadKey();
            }
        }

        public void Stop()
        {
        }
    }
}