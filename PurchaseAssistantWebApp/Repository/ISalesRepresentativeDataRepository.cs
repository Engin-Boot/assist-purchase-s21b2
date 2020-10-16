using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;
using System.Net;

namespace PurchaseAssistantWebApp.Repository
{
    public interface ISalesRepresentativeDataRepository
    {
        IEnumerable<SalesRepresentative> GetAllSalesRepresentative();

        IEnumerable<SalesRepresentative> GetAllSalesRepresentativeByRegion(string region);

        HttpStatusCode AddNewSalesRepresentative(SalesRepresentative newSalesRepresentativeInfo);

        HttpStatusCode UpdateSalesRepresentative(SalesRepresentative salesRepresentativeInfo);

        HttpStatusCode DeleteSalesRepresentative(long id);

    }
}
