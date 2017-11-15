using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;

namespace ExchangeEmailClient
{
    public class ExEmailSender : ExEmailWorker
    {
        // http://msdn.microsoft.com/en-us/library/dd633628(v=exchg.80)
        public ExEmailSender(Version version = Version.Exchange2010) : base(version)
        {
            ListSeparators = new char[] { ',', ';' };
        }

        public char[] ListSeparators { get; set; }

        // this method takes comma-separator or semicolon-separated lists of addresses and file names
        public void Send(string addressList, string subject, string body, string attachmentFileNameList = "")
        {
            string[] toAddresses = addressList.Split(ListSeparators);
            string[] attachmentFileNames = attachmentFileNameList.Split(ListSeparators);
            // known case: Split() translates empty string to string[1] array with single empty string
            Send(toAddresses, subject, body, attachmentFileNames);
        }

        // string arrays don't propagate too nicely across the .Net - Jade boundary
        public void Send(string[] toAddresses, string subject, string body, string[] attachmentFileNames)
        {
            EmailMessage message = new EmailMessage(service);

            // subject
            message.Subject = subject;

            // body
            message.Body = body;

            // recipient addresses - ignore empty entries
            foreach (string toAddress in toAddresses)
            {
                if (toAddress.Trim().Length > 0)
                    message.ToRecipients.Add(new EmailAddress(toAddress.Trim())); 
            }

            // attachments - ignore empty entries
            foreach (string fileName in attachmentFileNames)
            {
                if (fileName.Trim().Length > 0)
                    message.Attachments.AddFileAttachment(fileName.Trim());
            }

            // despatch, without copy
            message.Send();
            // message.SendAndSaveCopy();
        }

    }
}
