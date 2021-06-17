using Bespoke.AzureQueueLibrary.Infrastructure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bespoke.AzureQueueLibrary.QueueConnection
{
    public interface ICloudQueueClientFactory
    {
        CloudQueueClient GetClient();
    }
    public class CloudQueueClientFactory : ICloudQueueClientFactory
    {
        private readonly QueueConfig _queueConfig;
        private CloudQueueClient _cloudQueueClient;
        public CloudQueueClientFactory(QueueConfig queueConfig)
        {
            _queueConfig = queueConfig;
        }

        public CloudQueueClient GetClient()
        {
            //throw new NotImplementedException();
            if (_cloudQueueClient != null)
                return _cloudQueueClient;

            var storageAccount = CloudStorageAccount.Parse(_queueConfig.QueueConnectionString);
            _cloudQueueClient = storageAccount.CreateCloudQueueClient();
            return _cloudQueueClient;
        }

    }
}
