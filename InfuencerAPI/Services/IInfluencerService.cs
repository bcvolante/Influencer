using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.OrdersDTO;

namespace InfluencerAPI.Services
{
    public interface IInfluencerService
    {
        Task<MainResponse> GetInfluencerByRanking();
        Task<MainResponse> GetInfluencerById(Guid id);
        Task<MainResponse> GetInfluencerServiceById(Guid id);
        Task<MainResponse> GetInfluencerRestDayById(Guid id);
        Task<MainResponse> GetInfluencerTimeTypeById(Guid id);
        Task<MainResponse> GetInfluencerByFilter(string genderId, string industryId, string nationalityId, string name);
	}
}
