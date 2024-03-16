using Infrastructure.Core.MessageBroken;
using Infrastructure.EventStores;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Event
{
    public class EventBus : IEventBus
    {
        private IMediator _mediator;
        private IEventListener _eventListener;

        public EventBus(IMediator mediator, IEventListener eventListener)
        {
            _mediator = mediator;
            _eventListener = eventListener;
        }


        public virtual async Task Commit(params IEvent[] events)
        {
            if (_eventListener != null && events.Any())
            {
                foreach (var item in events)
                {
                    await _eventListener.Publish(item);
                }
            }

        }

        public virtual async Task Commit(StreamState state)
        {
            if (_eventListener != null)
            {
                await _eventListener.Publish(state.Data, state.Type);
            }
        }

        public virtual async Task PublishLocal(params IEvent[] events)
        {
            foreach (var item in events)
            {
                try
                {
                    if (item == null)
                    {
                        Log.Error("item is null");
                    }
                    else
                    {
                        await _mediator.Publish(item);
                    }
                }
                catch (Exception ex)
                {

                    Log.Error(ex.ToString());
                }
            }
        }
    }
}
