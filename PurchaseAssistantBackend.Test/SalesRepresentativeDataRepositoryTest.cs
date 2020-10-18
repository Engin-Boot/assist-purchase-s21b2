using PurchaseAssistantWebApp.Models;
using PurchaseAssistantWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PurchaseAssistantBackend.Test
{
    public class SalesRepresentativeDataRepositoryTest
    {
        private ISalesRepresentativeDataRepository repository;
        public SalesRepresentativeDataRepositoryTest()
        {
            var salesRepresentativeTestDb = new List<SalesRepresentative>();
            salesRepresentativeTestDb.Add(new SalesRepresentative { Id = "SR001", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "India" });
            salesRepresentativeTestDb.Add(new SalesRepresentative { Id = "SR002", Name = "Sam", Email = "samuel@gmail.com", DepartmentRegion = "Switzerland" });

            repository = new SalesRepresentativeDataRepository(salesRepresentativeTestDb);
        }
        [Fact]
        public void WhenGetAllSalesRepresentativeThenReturnAllRecords()
        {
            var salesRepresentatives = repository.GetAllSalesRepresentative() as List<SalesRepresentative>;

            Assert.Equal(2, salesRepresentatives.Count);

            Assert.Equal("SR001", salesRepresentatives[0].Id);
            Assert.Equal("Ellie", salesRepresentatives[0].Name);
            Assert.Equal("ellie@gmail.com", salesRepresentatives[0].Email);
            Assert.Equal("India", salesRepresentatives[0].DepartmentRegion);

            Assert.Equal("SR002", salesRepresentatives[1].Id);
            Assert.Equal("Sam", salesRepresentatives[1].Name);
            Assert.Equal("samuel@gmail.com", salesRepresentatives[1].Email);
            Assert.Equal("Switzerland", salesRepresentatives[1].DepartmentRegion);
        }
        
        [Fact]
        public void WhenGetAllSalesRepresentativeByRegionWithExistingRegionThenReturnRecordsWithMatchingRegion()
        {
            var salesRepresentatives = repository.GetAllSalesRepresentativeByRegion("India");
            
            Assert.Single(salesRepresentatives);

            SalesRepresentative salesRepresentativeInRegion = salesRepresentatives.First();

            Assert.Equal("SR001", salesRepresentativeInRegion.Id);
            Assert.Equal("Ellie", salesRepresentativeInRegion.Name);
            Assert.Equal("ellie@gmail.com", salesRepresentativeInRegion.Email);
            Assert.Equal("India", salesRepresentativeInRegion.DepartmentRegion);
        }
        
        [Fact]
        public void WhenGetAllSalesRepresentativeByRegionWithNonExistingRegionThenReturnZeroRecords()
        {
            var salesRepresentatives = repository.GetAllSalesRepresentativeByRegion("abc");

            Assert.Empty(salesRepresentatives);
        }
        
        [Fact]
        public void WhenAddNewSalesRepresentativeWithValidFieldsAndUniqueIdThenReturnSuccessMessage()
        {
            var message = repository.AddNewSalesRepresentative(
                new SalesRepresentative { Id = "SR003", Name = "Adam", Email = "adam@ymail.com", DepartmentRegion = "USA" });

            Assert.Equal("Sales representative with id SR003 added successfully!", message);
        }
        
        [Fact]
        public void WhenAddNewSalesRepresentativeWithValidFieldsAndDuplicateIdThenThrowArgumentException()
        {
            try
            {
                var message = repository.AddNewSalesRepresentative(
                    new SalesRepresentative { Id = "SR001", Name = "Adam", Email = "adam@ymail.com", DepartmentRegion = "USA" });
            }
            catch(ArgumentException exception)
            {
                Assert.Equal("id", exception.ParamName);
                Assert.Equal("A Sales Representative with SR001 id already exists. (Parameter 'id')", exception.Message);
            } 
        }
        
        [Fact]
        public void WhenAddNewSalesRepresentativeWithInvalidFieldsThenThrowArgumentException()
        {
            try
            {
                var message = repository.AddNewSalesRepresentative(
                    new SalesRepresentative { Id = "SR003", Name = "Adam", Email = "", DepartmentRegion = "USA" });
            }
            catch (ArgumentNullException exception)
            {
                Assert.Equal("email", exception.ParamName);
                Assert.Equal("Sales Representative details required: email cannot be null or empty. (Parameter 'email')", exception.Message);
            }
        }
        
        [Fact]
        public void WhenUpdateSalesRepresentativeWithValidFieldsAndExistingIdThenReturnSuccessMessage()
        {
            var message = repository.UpdateSalesRepresentative(
                new SalesRepresentative { Id = "SR001", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "USA" });

            Assert.Equal("Sales representative with id SR001 updated successfully!", message);
        }
        
        [Fact]
        public void WhenUpdateSalesRepresentativeWithNonExistingIdThenThrowKeyNotFoundException()
        {
            try
            {
                var message = repository.UpdateSalesRepresentative(
                    new SalesRepresentative { Id = "SR005", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "USA" });
            }
            catch (KeyNotFoundException exception)
            {
                Assert.Equal("Update operation failed. Sales representative with SR005 id does not exist.", exception.Message);
            }
        }
        
        [Fact]
        public void WhenUpdateSalesRepresentativeWithInvalidFieldsThenThrowArgumentException()
        {
            try
            {
                var message = repository.UpdateSalesRepresentative(
                    new SalesRepresentative { Id = "SR002", Name = "Samuel", Email = "samuel@gmail.com" });
            }
            catch (ArgumentNullException exception)
            {
                Assert.Equal("departmentRegion", exception.ParamName);
                Assert.Equal("Sales Representative details required: departmentRegion cannot be null or empty. (Parameter 'departmentRegion')", exception.Message);
            }
        }
        
        [Fact]
        public void WhenDeleteSalesRepresentativeWithExistingIdThenReturnSuccessMessage()
        {
            var message = repository.DeleteSalesRepresentative("SR001");

            Assert.Equal("Sales representative with id SR001 deleted successfully!", message);
        }

        [Fact]
        public void WhenDeleteSalesRepresentativeWithNonExistingIdThenThrowKeyNotFoundException()
        {
            try
            {
                var message = repository.DeleteSalesRepresentative("SR004");
            }
            catch (KeyNotFoundException exception)
            {
                Assert.Equal("Delete operation failed. Sales Representative with SR004 id does not exist.", exception.Message);
            }
        }

        [Fact]
        public void WhenRepositoryCreatedWithDefaultConstructorThenNonEmptyRepository()
        {
            ISalesRepresentativeDataRepository repository = new SalesRepresentativeDataRepository();
            Assert.NotNull(repository);
        }
    }
}
