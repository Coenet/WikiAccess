using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WikiAccessFunction.Models;

namespace WikiAccessFunction
{
    public class ServiceBusMessenger
    {
        public async Task sentGetWikiResponseAsync(Wiki wiki)
        {
            var queueclient = new QueueClient("Endpoint=sb://fandomsucks-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=4stYbSJP1f+1jfd1KX5+nqCP4tF+O+n0O6fElW1df5U=", "wiki-response");

            string body = JsonSerializer.Serialize(wiki);
            var message = new Message(Encoding.UTF8.GetBytes(body));
            message.ReplyTo = "wiki-response";

            await queueclient.SendAsync(message);

        }

        public async Task sentGetWikiListResponseAsync(List<Wiki> wikis)
        {
            var queueclient = new QueueClient("Endpoint=sb://fandomsucks-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=4stYbSJP1f+1jfd1KX5+nqCP4tF+O+n0O6fElW1df5U=", "wikis-response");


            string body = JsonSerializer.Serialize(wikis);
            var message = new Message(Encoding.UTF8.GetBytes(body));
            message.ReplyTo = "wikis-response";


            await queueclient.SendAsync(message);

        }

    }
}
