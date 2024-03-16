using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.MessageBroken.Kafka
{
    public class KafkaOptions
    {
        public ConsumerConfig Consumer { get; set; }

        public ProducerConfig Producer { get; set; }

        public string Topic { get; set; }
        public string Topics { get; set; }
    }
}
