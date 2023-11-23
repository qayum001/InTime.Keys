using InTime.Keys.Application.DTOs.KeyDTOs;

namespace InTime.Keys.Application.Interfaces.Services.KeyServices
{
    public interface IKeyGetService
    {
        public Task<List<KeyDto>> GetAllKeys();
        public Task<List<TimeSlotKeyDto>> GetConcreteTimeSlotKeys(DateTime date, int timeSlot, int page, int size);
    }
}
