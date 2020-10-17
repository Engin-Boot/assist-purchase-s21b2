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
        public void SendAlert(CallSetupRequest requestInfo, IEnumerable<SalesRepresentative> salesRepresentativesInCustomerRegion)
        {
            StringBuilder emailBodyStringBuilder = new StringBuilder();
            
            emailBodyStringBuilder.Append(requestInfo.Organisation + " from " + requestInfo.Region + 
                " region is interested in following Philips products from Continuous Patient Monitoring Systems range:\n");
            
            foreach(string productFullName in requestInfo.SelectedModels)
            {
                emailBodyStringBuilder.Append(productFullName + "\n");
            }

            emailBodyStringBuilder.Append("\nCustomer details are as follows: \n");
            emailBodyStringBuilder.Append("Point of Contact: " + requestInfo.PointOfContactName + "\n");
            emailBodyStringBuilder.Append("Organisation: " + requestInfo.Organisation + "\n");
            emailBodyStringBuilder.Append("Email Id: " + requestInfo.Email + "\n");
            emailBodyStringBuilder.Append("\nLets add one more happy customer to our list!");

            string emailBodyStr = emailBodyStringBuilder.ToString();
;

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("s21b2team@gmail.com", "");

            foreach(SalesRepresentative salesRepresentative in salesRepresentativesInCustomerRegion)
            {
                // create email message
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse("s21b2team@gmail.com");
                email.To.Add(MailboxAddress.Parse(salesRepresentative.Email));
                email.Subject = "New Service Request Received";
                string message = "Hi " + salesRepresentative.Name + "\n\n" + emailBodyStr;
                email.Body = new TextPart(TextFormat.Plain) { Text = message };
                smtp.Send(email);
            }
         
            smtp.Disconnect(true);
        }
    }
}
