using Confluent.Kafka;
using Infrastructure.Core.Event;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Core.MessageBroken
{
    public class RabbitMQListener : IEventListener
    {
        private RabbitMQOptions _options;
        private IModel _model;
        private readonly IServiceScopeFactory _serviceFactory;

        public RabbitMQListener(IOptions<RabbitMQOptions> options, IServiceScopeFactory serviceScopeFactory)
        {
             GetConnection();
            _options = options.Value;
            _serviceFactory = serviceScopeFactory;
        }

        private void GetConnection()
        {
            _model = initModel();
        }

        private IModel initModel()
        {

            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            var connection = factory.CreateConnection();

            var chanel = connection.CreateModel();

            return chanel;
        }

        public void Subscribe<TEvent>() where TEvent : IEvent
        {
            Subscribe(typeof(TEvent));
        }

        public virtual void Subscribe(Type type)
        {

            _model.QueueDeclare(_options.Queue.Name, exclusive: false);

            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var data = Encoding.UTF8.GetString(body);

                using (var scope = _serviceFactory.CreateScope())
                {
                    var eventBus = scope.ServiceProvider.GetService<IEventBus>();

                    var @event = JsonConvert.DeserializeObject(data, type) as IEvent;

                    await eventBus.PublishLocal(@event);
                }
            };

            _model.BasicConsume(queue: _options.Queue.Name, autoAck: false, consumer: consumer);
        }

        public virtual Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            if (@event == null)
            {
                Log.Error(nameof(@event), "Event can not be null.");
            }

            _model.QueueDeclare(_options.Queue.Name, exclusive: false);
            var json = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(json);

            _model.BasicPublish(exchange: "", routingKey: _options.Queue.Name, body: body);

            return Task.CompletedTask;
        }

        public virtual Task Publish(string message, string type)
        {
            _model.QueueDeclare(_options.Queue.Name, exclusive: false);

            var body = Encoding.UTF8.GetBytes(message);

            _model.BasicPublish(exchange: "", routingKey: _options.Queue.Name, body: body);

            return Task.CompletedTask;
        }

    }
}
