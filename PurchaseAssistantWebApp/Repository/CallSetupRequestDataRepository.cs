using JetBrains.Annotations;
using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PurchaseAssistantWebApp.Database;

namespace PurchaseAssistantWebApp.Repository
{
    public class CallSetupRequestDataRepository : ICallSetupRequestDataRepository
    {
       // private readonly List<CallSetupRequest> _requestsDb = new List<CallSetupRequest>();
        private readonly AppDbContext _context;
        public CallSetupRequestDataRepository(AppDbContext context)
        {
            _context = context;

        }

        //public CallSetupRequestDataRepository(List<CallSetupRequest> initialRequestDb)
        //{
        //    foreach (CallSetupRequest requestInfo in initialRequestDb)
        //    {
        //        _requestsDb.Add(requestInfo);
        //    }
        //}
        public IEnumerable<CallSetupRequest> GetAllCallSetupRequest()
        {
            //return _requestsDb;
            //InitializeDatabase(_context);
            return _context.PendingRequests.ToList();
        }

        [AssertionMethod]
        private void ValidateField(string name, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name, $"Customer detail required: { name } cannot be null or empty.");
            }
        }

        private void ValidateCallSetupRequestData(CallSetupRequest request)
        {
            ValidateField(nameof(request.RequestId), request.RequestId);
            ValidateField(nameof(request.Email), request.Email);
            ValidateField(nameof(request.Organisation), request.Organisation);
            ValidateField(nameof(request.CoustomerName), request.CoustomerName);
            ValidateField(nameof(request.Region), request.Region);

            if (request.SelectedModels==null || !request.SelectedModels.Any())
            {
                throw new ArgumentNullException(nameof(request.SelectedModels), "Selected models cannot be null or empty. Please select atleast one model to make a request.");
            }
        }

        public string AddNewCallSetupRequest(CallSetupRequest newRequest)
        {
            ValidateCallSetupRequestData(newRequest);

            //foreach (CallSetupRequest request in _requestsDb)
            //{
            //    if (request.RequestId.Equals(newRequest.RequestId))
            //    {
            //        throw new ArgumentException($"A Call Setup Request with {newRequest.RequestId} key already exists.", nameof(newRequest.RequestId));
            //    }
            //}
            if (_context.PendingRequests.Find(newRequest.RequestId) == null)
            {
                _context.PendingRequests.Add(newRequest);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"A Call Setup Request with {newRequest.RequestId} key already exists.", nameof(newRequest.RequestId));
            }

           

            //_requestsDb.Add(newRequest);
            return $"Call Setup Request with id {newRequest.RequestId} added successfully!";
        }

        public string DeleteCallSetupRequest(string id)
        {
            //int totalRequests = _requestsDb.Count;
            //for (var i = 0; i < totalRequests; i++)
            //{
            //    if (_requestsDb[i].RequestId.Equals(id))
            //    {
            //        _requestsDb.RemoveAt(i);

            //        return $"Call Setup Request with id {id} deleted successfully!";
            //    }
            //}
            if (_context.PendingRequests.Find(id) != null)
            {
                //_context.ServedRequests.Add(_context.PendingRequests.Find(id));
                _context.PendingRequests.Remove(GetCallSetupRequest(id));
                _context.SaveChanges();

                return $"Call Setup Request with id {id} deleted successfully!";
            }
            throw new KeyNotFoundException($"Delete operation failed. Call Setup Request with {id} key does not exist.");
        }

        public string UpdateCallSetupRequest(CallSetupRequest request)
        {
            ValidateCallSetupRequestData(request);

            //foreach (CallSetupRequest v in _requestsDb)
            //{
            //    if (v.RequestId.Equals(request.RequestId))
            //    {
            //v.Email = request.Email;
            //v.Organisation = request.Organisation;
            //v.CoustomerName = request.CoustomerName;
            //v.Region = request.Region;
            //v.SelectedModels = new List<string>(request.SelectedModels);

            //        
            //        return $"Call Setup Request with id {request.RequestId} updated successfully!";
            //    }
            //}
            if (GetCallSetupRequest(request.RequestId) != null)
            {
                var oldReq = GetCallSetupRequest(request.RequestId);
                oldReq.Email = request.Email;
                oldReq.Organisation = request.Organisation;
                oldReq.CoustomerName = request.CoustomerName;
                oldReq.Region = request.Region;
                oldReq.SelectedModels = new List<string>(request.SelectedModels);
                _context.SaveChanges();

                return $"Call Setup Request with id {request.RequestId} updated successfully!";
            }
            throw new KeyNotFoundException($"Update operation failed. Call Setup Request with {request.RequestId} key does not exist.");
        }

        public CallSetupRequest GetCallSetupRequest(string id)
        {
            return _context.PendingRequests.Find(id);
        }

        #region DataBase Initial values
        private void InitializeDatabase(AppDbContext context)
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
        #endregion
    }
}
