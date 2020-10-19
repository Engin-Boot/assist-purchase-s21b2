using MimeKit;
using PurchaseAssistantWebApp.Models;
using PurchaseAssistantWebApp.Utilities;
using System.Collections.Generic;
using Xunit;

namespace PurchaseAssistantBackend.Test
{
    public class AlertByEmailTest
    {
        private readonly AlertByEmail _alerter;
        public AlertByEmailTest()
        {
            _alerter = new AlertByEmail();
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

            var message = _alerter.CreateEmailMessageBody(request);

            Assert.NotNull(message);
        }

        [Fact]
        public void ComposeEmail_WhenValidEmailIdAreGivenThenReturnMimeMesage()
        {
            MimeMessage email = _alerter.ComposeEmail("s21b2team@gmail.com", new List<string> { "sainitripti5@gmail.com" }, "Test Request", "Test Message");

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
                new SalesRepresentative { Id = "SR005", Name = "Tripti", Email = "sainitripti5@gmail.com", DepartmentRegion = "India" } };
            
            var isEmailSent = _alerter.SendAlert(request, testDb);

            Assert.True(isEmailSent);
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

            var isEmailSent = _alerter.SendAlert(request, testDb);

            Assert.True(isEmailSent);
        }
    }
}
