using Infrastructure.EventStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Event
{
    public interface IEventBus
    {
        Task PublishLocal(params IEvent[] events);

        Task Commit(params IEvent[] events);

        Task Commit(StreamState state);
    }
}
