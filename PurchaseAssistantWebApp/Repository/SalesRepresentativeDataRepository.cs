using Microsoft.AspNetCore.Mvc;
using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PurchaseAssistantWebApp.Repository
{
    public class SalesRepresentativeDataRepository : ISalesRepresentativeDataRepository
    {
        private readonly List<SalesRepresentative> salesRepresentativesDb = new List<SalesRepresentative>();

        public SalesRepresentativeDataRepository()
        {

        }
        public HttpStatusCode AddNewSalesRepresentative(SalesRepresentative newSalesRepresentativeInfo)
        {
            for (var i = 0; i < salesRepresentativesDb.Count; i++)
            {
                if (salesRepresentativesDb[i].Id == newSalesRepresentativeInfo.Id)
                {
                    return HttpStatusCode.BadRequest;
                }
            }
            salesRepresentativesDb.Add(newSalesRepresentativeInfo);
            return HttpStatusCode.OK;
        }

        public HttpStatusCode DeleteSalesRepresentative(long id)
        {
            int totalSalesRepresentatives = salesRepresentativesDb.Count;
            for (var i = 0; i < totalSalesRepresentatives; i++)
            {
                if (salesRepresentativesDb[i].Id == id)
                {
                    salesRepresentativesDb.RemoveAt(i);
                    return HttpStatusCode.OK;
                }
            }
            return HttpStatusCode.NotFound;
        }

        public IEnumerable<SalesRepresentative> GetAllSalesRepresentative()
        {
            return salesRepresentativesDb;
        }

        public IEnumerable<SalesRepresentative> GetAllSalesRepresentativeByRegion(string region)
        {
            return salesRepresentativesDb.Where(salesRepresentative => salesRepresentative.DepartmentRegion.Equals(region));
        }

        public HttpStatusCode UpdateSalesRepresentative(SalesRepresentative salesRepresentativeInfo)
        {
            for (var i = 0; i < salesRepresentativesDb.Count; i++)
            {
                if (salesRepresentativesDb[i].Id == salesRepresentativeInfo.Id)
                {
                    salesRepresentativesDb[i].DepartmentRegion = salesRepresentativeInfo.DepartmentRegion;
                    salesRepresentativesDb[i].Email = salesRepresentativeInfo.Email;
                    salesRepresentativesDb[i].Name = salesRepresentativeInfo.Name;
                    return HttpStatusCode.OK;
                }
            }

            return HttpStatusCode.NotFound;
        }
    }
}
