using System;
using System.Collections.Generic;
using System.Text;
using WebCalendar.Services.Models.Event;

namespace WebCalendar.Services.Contracts
{
    public interface IEventService : IAsyncService<EventServiceModel>
    {
    }
}
