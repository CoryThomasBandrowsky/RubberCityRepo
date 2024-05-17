using Domain.Models;
using RubberCity.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RubberCity.Services.Services
{
    public class EventService
    {
        private readonly IEventRepository<Event> _eventRepository;

        public EventService(IEventRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventRepository.GetAll();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _eventRepository.GetById(id);
        }

        public async Task AddEvent(Event eventEntity)
        {
            await _eventRepository.Add(eventEntity);
        }

        public async Task UpdateEvent(Event eventEntity)
        {
            await _eventRepository.Update(eventEntity);
        }

        public async Task DeleteEvent(int id)
        {
            var eventEntity = await _eventRepository.GetById(id);
            if (eventEntity != null)
            {
            await _eventRepository.Delete(eventEntity);
        }
    }
}
}
