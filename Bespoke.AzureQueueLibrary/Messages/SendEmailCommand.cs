using Bespoke.AzureQueueLibrary.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bespoke.AzureQueueLibrary.Messages
{
    public class SendEmailCommand : BaseQueueMessage
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public SendEmailCommand()
            : base(RouteNames.EmailBox)
        {

        }

    }

    public class SendTPCommand : BaseQueueMessage
    {
        public string TrackingPayload { get; set; }
        public SendTPCommand()
            : base(RouteNames.EmailBox)
        {

        }

    }
}
