using System;
using System.Collections.Generic;

using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Database
{
    public class ProductsGetter
    {
        public List<ModelsSpecification> Products { get; private set; }

        public ProductsGetter()
        {

            this.GetAllItems();
            Console.WriteLine(Products.Count);

        }
        private void GetAllItems()
        {
            List<ModelsSpecification> monitoringItems = new List<ModelsSpecification>
            {
                new ModelsSpecification
                {
                    Id = 00001,
                    ProductName = "IntelliVue",
                    ProductKey = "X3",
                    Description =
                        "The Philips IntelliVue X3 is a compact, dual-purpose, transport patient monitor featuring intuitive smartphone-style operation and offering a scalable set of clinical measurements.",
                    Price = "14500",
                    Weight = 65,
                    Portable = true,
                    ScreenSize = 6.1,
                    TouchScreenSupport = true,
                    MonitorResolution = "10*11",
                    BatterySupport = "NO",
                    MultiPatientSupport = "NO",
                    BpCheck = "YES",
                    HeartRateCheck = "YES",
                    EcgCheck = "YES",
                    SpO2Check = "YES",
                    TemperatureCheck = "YES",
                    CardiacOutputCheck = "YES",
                    
                },
                new ModelsSpecification
                {
                    Id = 00002,
                    ProductName = "IntelliVue",
                    ProductKey = "MX40",
                    Description =
                        "The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.",
                    Price = "37000",
                    Weight = 65,
                    Portable = true,
                    ScreenSize = 2.8,
                    TouchScreenSupport = true,
                    MonitorResolution = "10*11",
                    BatterySupport = "YES",
                    MultiPatientSupport = "NO",
                    BpCheck = "YES",
                    HeartRateCheck = "YES",
                    EcgCheck = "NO",
                    SpO2Check = "YES",
                    TemperatureCheck = "YES",
                    CardiacOutputCheck = "NO",

                },
           
            };
            this.Products = monitoringItems;
        }
    }
}
