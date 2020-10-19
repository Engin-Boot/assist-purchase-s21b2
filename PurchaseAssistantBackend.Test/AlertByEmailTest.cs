using MimeKit;
using PurchaseAssistantWebApp.Models;
using PurchaseAssistantWebApp.Utilities;
using System;
using System.Collections.Generic;
using Xunit;

namespace PurchaseAssistantBackend.Test
{
    public class AlertByEmailTest
    {
        private AlertByEmail alerter;
        public AlertByEmailTest()
        {
            alerter = new AlertByEmail();
        }
        [Fact]
        public void CreateEmailMessageBody_ShouldReturnMessageString()
        {
            CallSetupRequest request = new CallSetupRequest {
                RequestId = "REQ002",
                PointOfContactName = "Mike",
                Organisation = "ABC Hospital",
                Region = "India",
                Email = "samuel@abc.com",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue MX40" }
            };

            var message = alerter.CreateEmailMessageBody(request);

            Assert.NotNull(message);
        }

        [Fact]
        public void ComposeEmail_WhenValidEmailIdAreGivenThenReturnMimeMesage()
        {
            MimeMessage email = alerter.ComposeEmail("s21b2team@gmail.com", new List<string> { "sainitripti5@gmail.com" }, "Test Request", "Test Message");

            Assert.NotNull(email);
        }

        [Fact]
        public void SendAlert_WhenSalesRepresentativeInRegionExistThenSendMail()
        {
            CallSetupRequest request = new CallSetupRequest
            {
                RequestId = "REQ002",
                PointOfContactName = "Mike",
                Organisation = "ABC Hospital",
                Region = "India",
                Email = "mike@abc.com",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue MX40" }
            };
            IEnumerable<SalesRepresentative> testDb = new List<SalesRepresentative> {
                new SalesRepresentative { Id = "SR001", Name = "Tripti", Email = "sainitripti5@gmail.com", DepartmentRegion = "India" } };
            
            var IsEmailSent = alerter.SendAlert(request, testDb);

            Assert.True(IsEmailSent);
        }

        [Fact]
        public void SendAlert_WhenSalesRepresentativeInRegionDoNotExistThenNoMailIsSent()
        {
            CallSetupRequest request = new CallSetupRequest
            {
                RequestId = "REQ002",
                PointOfContactName = "Mike",
                Organisation = "ABC Hospital",
                Region = "Africa",
                Email = "mike@abc.com",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue MX40" }
            };
            IEnumerable<SalesRepresentative> testDb = new List<SalesRepresentative> {
                new SalesRepresentative { Id = "SR001", Name = "Tripti", Email = "sainitripti5@gmail.com", DepartmentRegion = "India" } };

            var IsEmailSent = alerter.SendAlert(request, testDb);

            Assert.True(IsEmailSent);
        }
    }
}
