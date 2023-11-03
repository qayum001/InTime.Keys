using InTime.Keys.Infrastructure.Refit.InTimeModels;
using InTime.Keys.Infrastructure.Refit.InTimeModels.User;
using Refit;

namespace InTime.Keys.Infrastructure.Refit.Interfaces
{
    public interface IInTimeClient
    {
        /// <summary>
        /// Get user profile, need access token
        /// </summary>
        /// <returns></returns>
        [Get("/v1/user/profile")]
        Task<InTimeUserProfile> GetProfile([Authorize("Bearer")] string token);

        /// <summary>
        /// Get all professors
        /// </summary>
        /// <returns></returns>
        [Get("/v1/professors")]
        Task<IEnumerable<InTimeProfessor>> GetProfessorsAsync();

        /// <summary>
        /// Get list of building
        /// </summary>
        /// <returns></returns>
        [Get("/v1/buildings")]
        Task<IEnumerable<InTimeBuilding>> GetBuildingsAsync();

        /// <summary>
        /// Get list of building audiences
        /// </summary>
        /// <param name="buildingId"></param>
        /// <returns></returns>
        [Get("/v1/buildings/{buildingId}/audiences")]
        Task<IEnumerable<InTimeAudience>> GetAudiencesAsync(Guid buildingId);

        /// <summary>
        /// Get List of Schedule
        /// </summary>
        /// <param name="type">target, may be "group", "professor", "audience"</param>
        /// <param name="id">id of target</param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        [Get("/v1/schedule/{type}")]
        Task<IEnumerable<InTimeSchedule>> GetSchedulesAsync(string type, Guid id, string dateFrom, string dateTo);
    }
}
