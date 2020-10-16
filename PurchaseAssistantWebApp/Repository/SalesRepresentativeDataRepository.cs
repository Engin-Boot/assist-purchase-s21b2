using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PurchaseAssistantWebApp.Repository
{
    public class SalesRepresentativeDataRepository : ISalesRepresentativeDataRepository
    {
        private readonly List<SalesRepresentative> _salesRepresentativesDb = new List<SalesRepresentative>();

        public SalesRepresentativeDataRepository()
        {

        }
        public HttpStatusCode AddNewSalesRepresentative(SalesRepresentative newSalesRepresentativeInfo)
        {
            for (var i = 0; i < _salesRepresentativesDb.Count; i++)
            {
                if (_salesRepresentativesDb[i].Id == newSalesRepresentativeInfo.Id)
                {
                    return HttpStatusCode.BadRequest;
                }
            }
            _salesRepresentativesDb.Add(newSalesRepresentativeInfo);
            return HttpStatusCode.OK;
        }

        public HttpStatusCode DeleteSalesRepresentative(long id)
        {
            int totalSalesRepresentatives = _salesRepresentativesDb.Count;
            for (var i = 0; i < totalSalesRepresentatives; i++)
            {
                if (_salesRepresentativesDb[i].Id == id)
                {
                    _salesRepresentativesDb.RemoveAt(i);
                    return HttpStatusCode.OK;
                }
            }
            return HttpStatusCode.NotFound;
        }

        public IEnumerable<SalesRepresentative> GetAllSalesRepresentative()
        {
            return _salesRepresentativesDb;
        }

        public IEnumerable<SalesRepresentative> GetAllSalesRepresentativeByRegion(string region)
        {
            return _salesRepresentativesDb.Where(salesRepresentative => salesRepresentative.DepartmentRegion.Equals(region));
        }

        public HttpStatusCode UpdateSalesRepresentative(SalesRepresentative salesRepresentativeInfo)
        {
            for (var i = 0; i < _salesRepresentativesDb.Count; i++)
            {
                if (_salesRepresentativesDb[i].Id == salesRepresentativeInfo.Id)
                {
                    _salesRepresentativesDb[i].DepartmentRegion = salesRepresentativeInfo.DepartmentRegion;
                    _salesRepresentativesDb[i].Email = salesRepresentativeInfo.Email;
                    _salesRepresentativesDb[i].Name = salesRepresentativeInfo.Name;
                    return HttpStatusCode.OK;
                }
            }

            return HttpStatusCode.NotFound;
        }
    }
}
