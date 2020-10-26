using Microsoft.EntityFrameworkCore;
using System;
using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;
using DbContext = PurchaseAssistantWebApp.Database.AppDbContext;

namespace PurchaseAssistantBackend.Test
{
    public class InMemoryContext : IDisposable
    {
        protected readonly DbContext Context;

        protected InMemoryContext()
        {
            var option = new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase(
                databaseName: Guid.NewGuid().ToString()).Options;
            Context = new DbContext(option);
            Context.Database.EnsureCreated();
            InitializeDatabase(Context);

        }

        private void InitializeDatabase(DbContext context)
        {
            #region Users

            var user1 = new User { UserName = "user1", Password = "123", Email = "user1@gmail.com", Organisation = "xyz" };
            var user2 = new User { UserName = "user2", Password = "234", Email = "user2@gmail.com", Organisation = "xyz" };
            var user3 = new User { UserName = "user3", Password = "345", Email = "user3@gmail.com", Organisation = "xyz" };

            #endregion

            #region SalesRepresentatives
            var salesPerson1 = new SalesRepresentative { Id = "SR001", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "India" };
            var salesPerson2 = new SalesRepresentative { Id = "SR002", Name = "Sam", Email = "samuel@gmail.com", DepartmentRegion = "Switzerland" };
            #endregion

            #region PendingRequests
            var pendingReq1 = new CallSetupRequest
            {
                RequestId = "REQ001",
                CoustomerName = "James",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                Region = "Italy",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };

            var pendingReq2 = new CallSetupRequest
            {
                RequestId = "REQ002",
                CoustomerName = "Sara",
                Organisation = "ABC Hospital",
                Email = "sara@abc.com",
                Region = "India",
                SelectedModels = new List<string> { "IntelliVue X3" }
            };
            #endregion

            #region ServedRequests


            #endregion

            #region Models

            var IntelliVue = new ModelsSpecification
            {
                Id = 1,
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
                HeartRateCheck = "NO",
                EcgCheck = "YES",
                SpO2Check = "YES",
                TemperatureCheck = "YES",
                CardiacOutputCheck = "YES"
            };
            var Intelli = new ModelsSpecification
            {
                Id = 2,
                ProductName = "Intelli",
                ProductKey = "MX40",
                Description =
                      "The IntelliVue MX40 patient wearable monitor gives you technology, intelligent design, and innovative features you expect from Philips – in a device light enough and small enough to be comfortably worn by ambulatory patients.",
                Price = "37000",
                Weight = 65,
                Portable = true,
                ScreenSize = 2.8,
                TouchScreenSupport = true,
                MonitorResolution = "10*15",
                BatterySupport = "YES",
                MultiPatientSupport = "NO",
                BpCheck = "YES",
                HeartRateCheck = "YES",
                EcgCheck = "NO",
                SpO2Check = "YES",
                TemperatureCheck = "YES",
                CardiacOutputCheck = "NO"
            };

            #endregion

            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.SaveChanges();
            context.SalesRepresentatives.Add(salesPerson1);
            context.SalesRepresentatives.Add(salesPerson2);
            context.SaveChanges();
            context.PendingRequests.Add(pendingReq1);
            context.PendingRequests.Add(pendingReq2);
            context.SaveChanges();
            context.Models.Add(IntelliVue);
            context.Models.Add(Intelli);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
