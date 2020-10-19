using JetBrains.Annotations;
using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseAssistantWebApp.Repository
{
    public class SalesRepresentativeDataRepository : ISalesRepresentativeDataRepository
    {
        private readonly List<SalesRepresentative> _salesRepresentativesDb = new List<SalesRepresentative>();

        public SalesRepresentativeDataRepository()
        {
            _salesRepresentativesDb.Add(new SalesRepresentative { Id = "SR001", Name = "Tripti", Email = "sainitripti5@gmail.com", DepartmentRegion = "India" });
        }
        public SalesRepresentativeDataRepository(List<SalesRepresentative> initialSalesRepresentativesDb)
        {
            foreach(SalesRepresentative salesRepresentativeInfo in initialSalesRepresentativesDb)
            {
                _salesRepresentativesDb.Add(salesRepresentativeInfo);
            }
        }

        [AssertionMethod]
        private void ValidateField(string name, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name, "Sales Representative details required: " + name + " cannot be null or empty.");
            }
        }

        [AssertionMethod]
        private void ValidateSalesRepresentativetData(SalesRepresentative salesRepresentative)
        {
            ValidateField("id", salesRepresentative.Id);
            ValidateField("email", salesRepresentative.Email);
            ValidateField("name", salesRepresentative.Name);
            ValidateField("departmentRegion", salesRepresentative.DepartmentRegion);    
        }

        public IEnumerable<SalesRepresentative> GetAllSalesRepresentative()
        {
            return _salesRepresentativesDb;
        }

        public IEnumerable<SalesRepresentative> GetAllSalesRepresentativeByRegion(string region)
        {
            return _salesRepresentativesDb.Where(salesRepresentative => salesRepresentative.DepartmentRegion.Equals(region));
        }

        public string AddNewSalesRepresentative(SalesRepresentative newSalesRepresentativeInfo)
        {
            ValidateSalesRepresentativetData(newSalesRepresentativeInfo);

            foreach (SalesRepresentative salesRepresentative in _salesRepresentativesDb)
            {
                if (salesRepresentative.Id.Equals(newSalesRepresentativeInfo.Id))
                {
                    throw new ArgumentException("A Sales Representative with " + newSalesRepresentativeInfo.Id + " id already exists.", nameof(newSalesRepresentativeInfo.Id));
                }
            }
            _salesRepresentativesDb.Add(newSalesRepresentativeInfo);
            return $"Sales representative with id {newSalesRepresentativeInfo.Id} added successfully!";
        }

        public string UpdateSalesRepresentative(SalesRepresentative salesRepresentativeInfo)
        {
            ValidateSalesRepresentativetData(salesRepresentativeInfo);

            foreach (SalesRepresentative salesRepresentative in _salesRepresentativesDb)
            {
                if (salesRepresentative.Id.Equals(salesRepresentativeInfo.Id))
                {
                    salesRepresentative.DepartmentRegion = salesRepresentativeInfo.DepartmentRegion;
                    salesRepresentative.Email = salesRepresentativeInfo.Email;
                    salesRepresentative.Name = salesRepresentativeInfo.Name;
                    return $"Sales representative with id {salesRepresentativeInfo.Id} updated successfully!";
                }
            }

            throw new KeyNotFoundException("Update operation failed. Sales representative with " + salesRepresentativeInfo.Id + " id does not exist.");
        }

        public string DeleteSalesRepresentative(string id)
        {
            int totalSalesRepresentatives = _salesRepresentativesDb.Count;
            for (var i = 0; i < totalSalesRepresentatives; i++)
            {
                if (_salesRepresentativesDb[i].Id.Equals(id))
                {
                    _salesRepresentativesDb.RemoveAt(i);
                    return $"Sales representative with id {id} deleted successfully!";
                }
            }
            throw new KeyNotFoundException("Delete operation failed. Sales Representative with " + id + " id does not exist.");
        }
    }
}
