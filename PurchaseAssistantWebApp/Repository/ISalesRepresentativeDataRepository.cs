using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;
using System.Net;

namespace PurchaseAssistantWebApp.Repository
{
    public interface ISalesRepresentativeDataRepository
    {
        IEnumerable<SalesRepresentative> GetAllSalesRepresentative();

        IEnumerable<SalesRepresentative> GetAllSalesRepresentativeByRegion(string region);

        string AddNewSalesRepresentative(SalesRepresentative newSalesRepresentativeInfo);

        string UpdateSalesRepresentative(SalesRepresentative salesRepresentativeInfo);

        string DeleteSalesRepresentative(string id);

    }
}
