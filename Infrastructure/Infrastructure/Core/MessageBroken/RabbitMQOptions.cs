using RawRabbit.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.MessageBroken
{
    public class RabbitMQOptions 
    {

        public QueueOptions Queue { get; set; }
        public ExchangeOptions Exchange { get; set; }

        public class QueueOptions 
        {
            public string Name { get; set; }
        }

        public class ExchangeOptions
        {
            public string Name { get; set; }
        }
    }
}
