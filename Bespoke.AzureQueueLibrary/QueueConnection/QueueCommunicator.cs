using Bespoke.AzureQueueLibrary.Messages;
using Bespoke.AzureQueueLibrary.MessageSerializer;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Threading.Tasks;


namespace Bespoke.AzureQueueLibrary.QueueConnection
{
    public interface IQueueCommunicator
    {
        T Read<T>(string message);
        Task SendAsync<T>(T obj) where T : BaseQueueMessage;

	}

	public class QueueCommunicator : IQueueCommunicator
	{
		private readonly IMessageSerializer _messageSerializer;
		private readonly ICloudQueueClientFactory _cloudQueueClientFactory;

		public QueueCommunicator(IMessageSerializer messageSerializer,
			ICloudQueueClientFactory cloudQueueClientFactory)
		{
			_messageSerializer = messageSerializer;
			_cloudQueueClientFactory = cloudQueueClientFactory;
		}

		public T Read<T>(string message)
		{
			return _messageSerializer.Deserialize<T>(message);
		}

		public async Task SendAsync<T>(T obj) where T : BaseQueueMessage
		{
			var queueReference = _cloudQueueClientFactory.GetClient().GetQueueReference(obj.Route);
			await queueReference.CreateIfNotExistsAsync();

			var serializedMessage = _messageSerializer.Serialize(obj);
			var queueMessage = new CloudQueueMessage(serializedMessage);

			await queueReference.AddMessageAsync(queueMessage);
		}
	}
}
