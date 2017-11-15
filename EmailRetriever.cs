using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;

// this is a slim wrapper for fetching email from Exchange
// it uses credentials passed in, not the user currently logged in to Windows
// it searches only the Inbox
// it numbers attachments 1..n not 0..n-1
namespace ExchangeEmailClient
{
    public class ExEmailResult
    {
        public ExEmailResult() { }

        public ExEmailResult(ExEmailRetriever retriever, EmailMessage msg)
        {
            // "You must load or assign a value before you can read this property"
            // occurs where properties are not initialised on the EmailMessage object
            FromAddress     = GetEmailAddress(msg.From);
            HasAttachments  = msg.HasAttachments;
            Received        = msg.DateTimeReceived;
            SenderAddress   = GetEmailAddress(msg.Sender);
            SenderName      = GetName(msg.Sender);
            Subject         = msg.Subject;
            _email          = msg;
            _id             = msg.Id;
            _isRead         = msg.IsRead;
            _retriever      = retriever;
        }

        // Extracts email address as a string
        private static string GetEmailAddress(EmailAddress ea)
        {
            string result = ea.Address;
            if (result == null || result == "")
            {
                result = ea.ToString();
                if (result == null || result == "")
                {
                    result = ea.Name;
                    if (result == null)
                        result = "";
                    // else
                        // result = "Name=" + result;
                }
                // else
                    // result = "ToString()=" + result;
            }
            // else
                // result = "Address=" + result;
            return result;
        }

        private static string GetName(EmailAddress ea)
        {
            return ea.Name;
        }

        // public properties
        public string Body
        {
            // this is fetched on demand - requires a web service call
            get
            {
                _email.Load(new PropertySet(ItemSchema.Body));
                return _email.Body;
            }
        }
        public DateTime Received;
        public string FromAddress; // possibly different from SenderAddress
        public bool IsRead
        {
            get { return _isRead; }
            set
            {
                if (_isRead != value)
                {
                    _email.IsRead = value; // updating
                    _isRead = value;
                    _email.Update(ConflictResolutionMode.AutoResolve); // seems to be necessary
                }
            }
        }
        public bool HasAttachments;
        public string SenderAddress;
        public string SenderName;
        public string Subject;

        public int AttachmentCount
        {
            get
            {
                if (HasAttachments)
                {
                    _email.Load(new PropertySet(ItemSchema.Attachments));
                    return _email.Attachments.Count;
                }
                else return 0;
            }
        }

        public string AttachmentName(int index) // 1..n
        {
            return _email.Attachments[index-1].Name;
        }

        public string GetAttachmentNames(string separator = ";") // separated list
        {
            StringBuilder result = new StringBuilder();
            if (HasAttachments)
            {
                int count = AttachmentCount;
                for (int index = 0; index < count; index++)
                {
                    if (index != 0) result.Append(separator);
                    result.Append(AttachmentName(index+1));
                }
            }
            return result.ToString();
        }

        public void SaveAttachmentFile(int index, string fileName) // 1..n
        {
            Attachment attachment = _email.Attachments[index-1];
            if (!(attachment is FileAttachment))
                _retriever.RaiseException("Cannot save attachment", "Attachment " + index.ToString() + " is not a file.");

            FileAttachment fa = attachment as FileAttachment;
            fa.Load(fileName);
        }

        public void HardDeleteEmail()
        {
            _email.Delete(DeleteMode.HardDelete); // updating
            _email.Update(ConflictResolutionMode.AutoResolve); // not yet confirmed as necessary
        }

        // private
        private bool _isRead;
        private ItemId _id;
        private EmailMessage _email;
        private ExEmailRetriever _retriever;
    }

    internal class ExEmailResultArray : List<ExEmailResult> { }

    public class ExEmailRetriever : ExEmailWorker
    {
        public ExEmailRetriever(Version version = Version.Exchange2010) : base(version)
        {
            FromFolder = Folder.Inbox;
            HasAttachments = false;
            NameOfSender = "";
            OnlyUnreadEmail = false;
            SubjectContains = "";
            PageSize = 10;
        }

        // filters
        public Folder FromFolder { get; set; } // EWS type WellKnownFolderName
        public WellKnownFolderName GetWellKnownFolderName { get { return (WellKnownFolderName)FromFolder; } }
        public bool HasAttachments { get; set; }
        public string NameOfSender { get; set; }
        public bool OnlyUnreadEmail { get; set; }
        public string SubjectContains { get; set; }

        // settings
        public int PageSize { get; set; }

        // results
        private ExEmailResultArray Results = new ExEmailResultArray();
        public int ResultsCount
        {
            get { return Results.Count; }
        }
        public ExEmailResult GetResult(int index) // 1..n
        {
            return Results[index - 1];
        }

        public int Retrieve()
        {
            Results.Clear();

            if (service == null) RaiseException("Cannot retrieve email", "Connection has not been established");

            // select properties to retrieve
            ItemView view = BuildView(PageSize);

            // build query to filter by NameOfSender and SubjectContains if required
            string qstring = BuildQueryString();

            // send first request and get items
            FindItemsResults<Item> items = service.FindItems(GetWellKnownFolderName, qstring, view);

            // select, accumulate, build EmailResult wrappers, iterate until done
            AccumulateResults(Results, items);
            while (items.MoreAvailable)
            {
                view.Offset = view.Offset + view.PageSize;
                items = service.FindItems(GetWellKnownFolderName, qstring, view);
                AccumulateResults(Results, items);
            }
            return Results.Count;
        }

        // select items of interest, build wrapper EmailResults, add to results array
        private void AccumulateResults(ExEmailResultArray results, FindItemsResults<Item> items)
        {
            foreach (Item item in items)
            {
                if (item is EmailMessage)
                {
                    EmailMessage email = item as EmailMessage;
                    if (WantEmail(email))
                    {
                        results.Add(new ExEmailResult(this, email));
                    }
                }
            }
        }

        private ItemView BuildView(int pageSize)
        {
            ItemView view = new ItemView(pageSize);

            // Identify the item properties to return
            // this must cover all properties we intend to use
            // Note: the property Body can't be used in FindItem requests
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly,
                ItemSchema.DateTimeReceived,
                EmailMessageSchema.From,
                EmailMessageSchema.IsRead,
                ItemSchema.HasAttachments,
                EmailMessageSchema.Sender,
                EmailMessageSchema.Subject);

            return view;
        }

        // apply post-fetch filters
        private bool WantEmail(EmailMessage email)
        {
            if (OnlyUnreadEmail && email.IsRead)
                return false;

            if (HasAttachments && !email.HasAttachments)
                return false;

            return true;
        }

        // The QueryString element was introduced in Exchange Server 2010 to surface the preferred alternative for performing ad hoc Exchange mailbox searches.
        // I don't see a way to filter by HasAttachments or OnlyUnreadEmails
        // http://msdn.microsoft.com/en-us/library/ee693615.aspx
        private string BuildQueryString()
        {
            StringBuilder query = new StringBuilder("Kind:email");
            
            // Subject
            if (SubjectContains != "") query.Append(" subject:" + SubjectContains);

            // From - only works with names, not email addresses!
            if (NameOfSender != "") query.Append(" from:\"" + NameOfSender + "\"");

            return query.ToString();
        }

    }
}
