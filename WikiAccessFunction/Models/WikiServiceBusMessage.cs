using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiAccessFunction.Models
{
    public class WikiServiceBusMessage
    {
        public string MessageIdentifier { get; set; }

        public Wiki? SentWiki { get; set; }

        public Guid? SentGuid { get; set; }

    }
}
