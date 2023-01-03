using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WikiAccessFunction.Models;

namespace WikiAccessFunction
{
    public class ServiceBusFunction
    {
        [FunctionName("ServiceBusFunction")]
        public void Run([ServiceBusTrigger("wikis", Connection = "ServiceBus")]string QueueItem, ILogger log, Int32 deliveryCount,
          DateTime enqueuedTimeUtc,
          string messageId)
        {

            Wiki wiki = new Wiki
            {
                Description = "description",
                Id = Guid.NewGuid(),
                Name = "Wiki-Title"
            };

            List<Wiki> wikis = new List<Wiki>();
            wikis.Add(wiki);


            var message = JsonConvert.DeserializeObject<WikiServiceBusMessage>(QueueItem);

            switch (message.MessageIdentifier)
            {
                case "AddWiki":
                    var article = message.SentWiki;

                    break;
                case "DeleteWiki":
                    var deleteGuid = message.SentGuid;
                    break;
                case "GetWiki":
                    var getGuid = message.SentGuid;
                    ServiceBusMessenger serviceBusMessenger = new ServiceBusMessenger();
                    serviceBusMessenger.sentGetWikiResponseAsync(wiki).Wait();
                    break;
                case "GetWikis":
                    var wikiGuid = message.SentGuid;
                    serviceBusMessenger = new ServiceBusMessenger();
                    serviceBusMessenger.sentGetWikiListResponseAsync(wikis).Wait();
                    break;
            }

        }
    }
}
