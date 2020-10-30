using PurchaseAssistantWebApp.Models;
using PurchaseAssistantWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PurchaseAssistantBackend.Test
{
    public class SalesRepresentativeDataRepositoryTest : InMemoryContext
    {
        private readonly ISalesRepresentativeDataRepository _repository;
        public SalesRepresentativeDataRepositoryTest()
        {
            _repository = new SalesRepresentativeDataRepository(Context);
        }
        [Fact]
        public void WhenGetAllSalesRepresentativeThenReturnAllRecords()
        {
            var salesRepresentatives = _repository.GetAllSalesRepresentative().ToList();

            Assert.NotNull(salesRepresentatives);
            Assert.Equal(2, salesRepresentatives.Count);

            Assert.Equal("SR001", salesRepresentatives[1].Id);
            Assert.Equal("Ellie", salesRepresentatives[1].Name);
            Assert.Equal("ellie@gmail.com", salesRepresentatives[1].Email);
            Assert.Equal("India", salesRepresentatives[1].DepartmentRegion);

            Assert.Equal("SR002", salesRepresentatives[0].Id);
            Assert.Equal("Sam", salesRepresentatives[0].Name);
            Assert.Equal("samuel@gmail.com", salesRepresentatives[0].Email);
            Assert.Equal("Switzerland", salesRepresentatives[0].DepartmentRegion);
        }
        
        [Fact]
        public void WhenGetAllSalesRepresentativeByRegionWithExistingRegionThenReturnRecordsWithMatchingRegion()
        {
            var salesRepresentatives = _repository.GetAllSalesRepresentativeByRegion("India").ToList();
            
            Assert.Single(salesRepresentatives);

            SalesRepresentative salesRepresentativeInRegion = salesRepresentatives[0];

            Assert.Equal("SR001", salesRepresentativeInRegion.Id);
            Assert.Equal("Ellie", salesRepresentativeInRegion.Name);
            Assert.Equal("ellie@gmail.com", salesRepresentativeInRegion.Email);
            Assert.Equal("India", salesRepresentativeInRegion.DepartmentRegion);
        }
        
        [Fact]
        public void WhenGetAllSalesRepresentativeByRegionWithNonExistingRegionThenReturnZeroRecords()
        {
            var salesRepresentatives = _repository.GetAllSalesRepresentativeByRegion("abc");

            Assert.Empty(salesRepresentatives);
        }
        
        [Fact]
        public void WhenAddNewSalesRepresentativeWithValidFieldsAndUniqueIdThenReturnSuccessMessage()
        {
            var message = _repository.AddNewSalesRepresentative(
                new SalesRepresentative { Id = "SR003", Name = "Adam", Email = "adam@ymail.com", DepartmentRegion = "USA" });

            Assert.Equal("Sales representative with id SR003 added successfully!", message);
            Assert.NotNull(_repository.GetSalesRepresentative("SR003"));
        }
        
        [Fact]
        public void WhenAddNewSalesRepresentativeWithValidFieldsAndDuplicateIdThenThrowArgumentException()
        {
            try
            {
                _ = _repository.AddNewSalesRepresentative(
                    new SalesRepresentative { Id = "SR001", Name = "Adam", Email = "adam@ymail.com", DepartmentRegion = "USA" });
            }
            catch(ArgumentException exception)
            {
                Assert.Equal("Id", exception.ParamName);
                Assert.Equal("A Sales Representative with SR001 id already exists. (Parameter 'Id')", exception.Message);
            } 
        }
        
        [Fact]
        public void WhenAddNewSalesRepresentativeWithInvalidFieldsThenThrowArgumentException()
        {
            try
            {
                _ = _repository.AddNewSalesRepresentative(
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
            var message = _repository.UpdateSalesRepresentative(
                new SalesRepresentative { Id = "SR001", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "USA" });

            Assert.Equal("Sales representative with id SR001 updated successfully!", message);
            Assert.Equal("USA", _repository.GetSalesRepresentative("SR001").DepartmentRegion);
        }
        
        [Fact]
        public void WhenUpdateSalesRepresentativeWithNonExistingIdThenThrowKeyNotFoundException()
        {
            try
            {
                _ = _repository.UpdateSalesRepresentative(
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
                _ = _repository.UpdateSalesRepresentative(
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
            var message = _repository.DeleteSalesRepresentative("SR001");

            Assert.Equal("Sales representative with id SR001 deleted successfully!", message);
            Assert.Null(_repository.GetSalesRepresentative("SR001"));
        }

        [Fact]
        public void WhenDeleteSalesRepresentativeWithNonExistingIdThenThrowKeyNotFoundException()
        {
            try
            {
                _ = _repository.DeleteSalesRepresentative("SR004");
            }
            catch (KeyNotFoundException exception)
            {
                Assert.Equal("Delete operation failed. Sales Representative with SR004 id does not exist.", exception.Message);
            }
        }
    }
}
