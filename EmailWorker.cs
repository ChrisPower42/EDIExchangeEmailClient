using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;

namespace ExchangeEmailClient
{
    public class ExEmailException : Exception
    {
        public ExEmailException(string message, Exception inner = null)
            : base(message, inner) { }
    }

    // this has common facilities for Sender and Retriever
    // it owns an ExchangeService object for doing the business
    // it provides methods for connecting
    public class ExEmailWorker
    {
        public ExEmailWorker(Version version = Version.Exchange2010)
        {
            TargetExchangeVersion = version;
        }

        // Exchange Versions - expose Microsoft.Exchange.WebServices.Data.ExchangeVersion
        public enum Version {
            Exchange2007_SP1    = ExchangeVersion.Exchange2007_SP1,
            Exchange2010        = ExchangeVersion.Exchange2010,
            Exchange2010_SP1    = ExchangeVersion.Exchange2010_SP1,
            Exchange2010_SP2    = ExchangeVersion.Exchange2010_SP2,
            Exchange2013        = ExchangeVersion.Exchange2013
        };

        // Well known folders - expose selected Microsoft.Exchange.WebServices.Data.WellKnownFolderName
        public enum Folder
        {
            Inbox               = WellKnownFolderName.Inbox,
            PublicFoldersRoot   = WellKnownFolderName.PublicFoldersRoot,
            Root                = WellKnownFolderName.Root
        };

        // state
        protected ExchangeService service = null;
        public string LastError { get; set; }
        public string Url
        {
            get { return (service != null) ? service.Url.ToString() : ""; }
        }
        public Version TargetExchangeVersion { get; set; }

        // utility
        public void RaiseException(string context, string message, Exception inner = null)
        {
            LastError = context + "\n" + message;
            throw new ExEmailException(LastError, inner);
        }

        // connection
        // We recommend that you use the Autodiscover service because it determines the best endpoint for a specific user.
        // When you use the Autodiscover service, if the EWS URL changes, your code will not be affected.
        public void ConnectByEmailAddress(string emailAddress, string userName, string password, string domain = "")
        {
            try
            {
                // latest supported version of EWS, system's current time zone
                //  If you do not specify a version, EWS will use the latest version of Exchange Server that is known to the EWS Managed API.
                service = new ExchangeService((ExchangeVersion)TargetExchangeVersion);
                service.Credentials = new WebCredentials(userName, password, domain);
                service.AutodiscoverUrl(emailAddress);
            }
            catch (Exception ex)
            {
                service = null; // dispose
                RaiseException("Connection failed.", ex.Message, ex);
            }
        }

        public void ConnectToServer(string serverName, string userName, string password, string domain = "")
        {
            try
            {
                // latest supported version of EWS, system's current time zone
                service = new ExchangeService();
                service.Url = new Uri(serverName);
                service.Credentials = new WebCredentials(userName, password, domain);
            }
            catch (Exception ex)
            {
                service = null; // dispose
                RaiseException("Connection failed.", ex.Message, ex);
            }
        }


    }
}
