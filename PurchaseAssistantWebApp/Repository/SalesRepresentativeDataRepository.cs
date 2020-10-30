using JetBrains.Annotations;
using PurchaseAssistantWebApp.Database;
using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseAssistantWebApp.Repository
{
    public class SalesRepresentativeDataRepository : ISalesRepresentativeDataRepository
    {
        private readonly AppDbContext _context;
        public SalesRepresentativeDataRepository(AppDbContext context)
        {
            _context = context;
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
            return _context.SalesRepresentatives;
        }

        public IEnumerable<SalesRepresentative> GetAllSalesRepresentativeByRegion(string region)
        {
            return _context.SalesRepresentatives.Where(salesRepresentative => salesRepresentative.DepartmentRegion.Equals(region));
        }

        public string AddNewSalesRepresentative(SalesRepresentative newSalesRepresentativeInfo)
        {
            ValidateSalesRepresentativetData(newSalesRepresentativeInfo);
            if (GetSalesRepresentative(newSalesRepresentativeInfo.Id) != null)
            {
                throw new ArgumentException("A Sales Representative with " + newSalesRepresentativeInfo.Id + " id already exists.", nameof(newSalesRepresentativeInfo.Id));
            }
            _context.SalesRepresentatives.Add(newSalesRepresentativeInfo);
            _context.SaveChanges();
            return $"Sales representative with id {newSalesRepresentativeInfo.Id} added successfully!";
            
        }

        public string UpdateSalesRepresentative(SalesRepresentative salesRepresentativeInfo)
        {
            ValidateSalesRepresentativetData(salesRepresentativeInfo);
            if (GetSalesRepresentative(salesRepresentativeInfo.Id) == null)
            {
                throw new KeyNotFoundException("Update operation failed. Sales representative with " + salesRepresentativeInfo.Id + " id does not exist.");
            }
            var old = GetSalesRepresentative(salesRepresentativeInfo.Id);
            old.Name = salesRepresentativeInfo.Name;
            old.DepartmentRegion = salesRepresentativeInfo.DepartmentRegion;
            old.Email = salesRepresentativeInfo.Email;
            _context.SaveChanges();
            return $"Sales representative with id {salesRepresentativeInfo.Id} updated successfully!";
        }

        public string DeleteSalesRepresentative(string id)
        {
            if (GetSalesRepresentative(id) == null)
            {
                throw new KeyNotFoundException("Delete operation failed. Sales Representative with " + id + " id does not exist.");
            }
            _context.SalesRepresentatives.Remove(GetSalesRepresentative(id));
            _context.SaveChanges();
            return $"Sales representative with id {id} deleted successfully!";
            
        }

        public SalesRepresentative GetSalesRepresentative(string id)
        {
            return _context.SalesRepresentatives.Find(id);
        }
    }
}
