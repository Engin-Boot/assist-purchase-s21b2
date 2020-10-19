using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseAssistantWebApp.Utilities
{
    public class AlertByEmail : IAlerter
    {
        public string CreateEmailMessageBody(CallSetupRequest requestInfo)
        {
            StringBuilder emailBodyStringBuilder = new StringBuilder();

            emailBodyStringBuilder.Append(requestInfo.PointOfContactName + " from " + requestInfo.Region +
                " region is interested in following Philips products from Continuous Patient Monitoring Systems range:\n");

            foreach (string productFullName in requestInfo.SelectedModels)
            {
                emailBodyStringBuilder.Append(productFullName + "\n");
            }

            emailBodyStringBuilder.Append("\nCustomer details are as follows: \n");
            emailBodyStringBuilder.Append("Point of Contact: " + requestInfo.PointOfContactName + "\n");
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
    }
}
