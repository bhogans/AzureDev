using System;
using System.Collections.Generic;
using System.Text;
using Bespoke.AzureQueueLibrary.MessageSerializer;
using Bespoke.AzureQueueLibrary.QueueConnection;
using Microsoft.Extensions.DependencyInjection;

namespace Bespoke.AzureQueueLibrary.Infrastructure
{
    public static class DependencyInjectionRegistry
    {
		public static IServiceCollection AddAzureQueueLibrary(this IServiceCollection services, string queueConnectionString)
		{
			services.AddSingleton(new QueueConfig(queueConnectionString));
			services.AddSingleton<ICloudQueueClientFactory, CloudQueueClientFactory>();
			services.AddSingleton<IMessageSerializer, JsonMessageSerializer>();
			services.AddTransient<IQueueCommunicator, QueueCommunicator>();

			return services;
		}
	}
}
