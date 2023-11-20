using InTime.Keys.Application.DTOs.KeyDTOs;

namespace InTime.Keys.Application.Interfaces.Services.KeyServices
{
    public interface IKeyService
    {
        public Task<List<KeyDto>> GetAllKeys();
    }
}
