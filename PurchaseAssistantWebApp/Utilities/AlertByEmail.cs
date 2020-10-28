using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;
using System.Text;

namespace PurchaseAssistantWebApp.Utilities
{
    public class AlertByEmail : IAlerter
    {
        public string CreateEmailMessageBody(CallSetupRequest requestInfo)
        {
            StringBuilder emailBodyStringBuilder = new StringBuilder();

            emailBodyStringBuilder.Append(requestInfo.CoustomerName + " from " + requestInfo.Region +
                " region is interested in following Philips products from Continuous Patient Monitoring Systems range:\n");

            foreach (string productFullName in requestInfo.SelectedModels)
            {
                emailBodyStringBuilder.Append(productFullName + "\n");
            }

            emailBodyStringBuilder.Append("\nCustomer details are as follows: \n");
            emailBodyStringBuilder.Append("Point of Contact: " + requestInfo.CoustomerName + "\n");
            emailBodyStringBuilder.Append("Organisation: " + requestInfo.Organisation + "\n");
            emailBodyStringBuilder.Append("Email Id: " + requestInfo.Email + "\n");
            emailBodyStringBuilder.Append("\nLets add one more happy customer to our list!");

            return emailBodyStringBuilder.ToString();
        }

        public MimeMessage ComposeEmail(string senderAddress, List<string> receiverAddresses, string subject, string message)
        {
            // create email message
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(senderAddress),
                Subject = subject,
                Body = new TextPart(TextFormat.Plain) { Text = message }
            };

            foreach (string receiverAddress in receiverAddresses)
            {
                email.To.Add(MailboxAddress.Parse(receiverAddress));
            }
            
            return email;
        }
        public bool SendAlert(CallSetupRequest requestInfo, IEnumerable<SalesRepresentative> salesRepresentativesInCustomerRegion)
        {
            List<string> receivers = new List<string>();

            foreach (SalesRepresentative salesRepresentative in salesRepresentativesInCustomerRegion)
            {
                receivers.Add(salesRepresentative.Email);
            }

            if(receivers.Count == 0)
            {
                return false;
            }

            var emailBodyStr = CreateEmailMessageBody(requestInfo);

            //var email = ComposeEmail("s21b2team@gmail.com", receivers, "New Call Setup Request Received", emailBodyStr);
            _ = ComposeEmail("s21b2team@gmail.com", receivers, "New Call Setup Request Received", emailBodyStr);

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate("s21b2team@gmail.com", "");
            //smtp.Send(email);
            smtp.Disconnect(true);
            
            return true;
        }

        public bool SendAlert(SalesRepresentative salesRepresentative, string customerEmail )
        {
            List<string> receivers = new List<string>();

            receivers.Add(customerEmail);

            if (receivers.Count == 0)
            {
                return false;
            }

            var emailBodyStr = new StringBuilder();
            emailBodyStr.Append("\nThank You, for choosing Philips \n");
            emailBodyStr.Append("Our Sales Representative " + salesRepresentative.Name + " has accepted your order\n");
            emailBodyStr.Append("He Will contact you soon..\n");
            emailBodyStr.Append("Sales Representative Email Id: " + salesRepresentative.Email + "\n");
            emailBodyStr.Append("\nThanks and Regards..!\n");
            emailBodyStr.Append("Philips\n");
            emailBodyStr.Append("Innovation and You!\n");

            //var email = ComposeEmail("s21b2team@gmail.com", receivers, "New Call Setup Request Received", emailBodyStr);
            _ = ComposeEmail("s21b2team@gmail.com", receivers, "New Call Setup Request Received", emailBodyStr.ToString());

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate("s21b2team@gmail.com", "");
            //smtp.Send(email);
            smtp.Disconnect(true);
            return true;
        }
    }
}
