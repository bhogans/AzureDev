using System;
using System.Collections.Generic;
using System.Text;

namespace Bespoke.AzureQueueLibrary.MessageSerializer
{
    public interface IMessageSerializer
    {
        T Deserialize<T>(string message);
        string Serialize(object obj);
    }
}
