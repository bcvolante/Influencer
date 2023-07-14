using InfuencerAPI.Models.MasterDTO;

namespace InfuencerAPI.Services
{
    public interface ISettingsService
    {
        Task<MainResponse> GetAll();
        Task<MainResponse> GetById(Guid id);
        Task<MainResponse> FilterBy(Guid typeId);
        Task<MainResponse> Create(CreateSettingsRequest createSettingsRequest);
        Task<MainResponse> Update(UpdateSettingsRequest updateSettingsRequest);
        Task<MainResponse> Delete(DeleteSettingsRequest deleteSettingsRequest);
        Task<MainResponse> GetIndustryWithData(Guid typeId);
    }
}
