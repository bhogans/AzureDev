using System;
using System.Collections.Generic;
using System.Text;

namespace Bespoke.AzureQueueLibrary.Infrastructure
{
    public class QueueConfig
    {
        public string QueueConnectionString { get; set; }
        public QueueConfig()
        {
        }

        public QueueConfig(string queueConnectionString)
        {
            QueueConnectionString = queueConnectionString;
        }
    }
}
