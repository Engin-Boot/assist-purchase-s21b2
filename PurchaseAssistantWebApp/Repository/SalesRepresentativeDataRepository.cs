﻿using PurchaseAssistantWebApp.Models;
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
        private void ValidateField(string name, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name, "Sales Representative details required: " + name + " cannot be null or empty.");
            }
        }

        private void ValidateSalesRepresentativetData(SalesRepresentative salesRepresentative)
        {
            ValidateField("id", salesRepresentative.Id);
            ValidateField("email", salesRepresentative.Email);
            ValidateField("name", salesRepresentative.Name);
            ValidateField("departmentRegion", salesRepresentative.DepartmentRegion);    
        }

        public void AddNewSalesRepresentative(SalesRepresentative newSalesRepresentativeInfo)
        {
            ValidateSalesRepresentativetData(newSalesRepresentativeInfo);

            for (var i = 0; i < _salesRepresentativesDb.Count; i++)
            {
                if (_salesRepresentativesDb[i].Id.Equals(newSalesRepresentativeInfo.Id))
                {
                    throw new ArgumentException("A Sales Representative with " + newSalesRepresentativeInfo.Id + " id already exists.", "id");
                }
            }
            _salesRepresentativesDb.Add(newSalesRepresentativeInfo);
        }

        public void DeleteSalesRepresentative(string id)
        {
            int totalSalesRepresentatives = _salesRepresentativesDb.Count;
            for (var i = 0; i < totalSalesRepresentatives; i++)
            {
                if (_salesRepresentativesDb[i].Id.Equals(id))
                {
                    _salesRepresentativesDb.RemoveAt(i);
                    return;
                }
            }
            throw new KeyNotFoundException("Delete operation failed. Sales Representative with " + id + " id does not exist.");
        }

        public IEnumerable<SalesRepresentative> GetAllSalesRepresentative()
        {
            return _salesRepresentativesDb;
        }

        public IEnumerable<SalesRepresentative> GetAllSalesRepresentativeByRegion(string region)
        {
            return _salesRepresentativesDb.Where(salesRepresentative => salesRepresentative.DepartmentRegion.Equals(region));
        }

        public void UpdateSalesRepresentative(SalesRepresentative salesRepresentativeInfo)
        {
            ValidateSalesRepresentativetData(salesRepresentativeInfo);

            for (var i = 0; i < _salesRepresentativesDb.Count; i++)
            {
                if (_salesRepresentativesDb[i].Id.Equals(salesRepresentativeInfo.Id))
                {
                    _salesRepresentativesDb[i].DepartmentRegion = salesRepresentativeInfo.DepartmentRegion;
                    _salesRepresentativesDb[i].Email = salesRepresentativeInfo.Email;
                    _salesRepresentativesDb[i].Name = salesRepresentativeInfo.Name;
                    return;
                }
            }

            throw new KeyNotFoundException("Update operation failed. Sales representative with " + salesRepresentativeInfo.Id + " id does not exist.");
        }
    }
}
