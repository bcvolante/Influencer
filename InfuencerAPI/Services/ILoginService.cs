using InfluencerAPI.Models.UsersDTO;
using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.UsersDTO;

namespace InfuencerAPI.Services
{
    public interface ILoginService
    {
        Task<MainResponse> GetAll();
        Task<MainResponse> GetById(Guid id);
        Task<LoginViewResponse> AuthenticateUser(AuthenticateUserRequest _AuthenticateUserRequest);
        Task<MainResponse> Create(CreateLoginRequest createLoginRequest);
        Task<MainResponse> Update(UpdateLoginRequest updateLoginRequest);
        Task<MainResponse> Delete(DeleteLoginRequest deleteLoginRequest);
        Task<MainResponse> UpdateRefreshToken(string email, string refreshToken);
        Task<MainResponse> UpdateLogin(Guid id, string email, string password);
    }
}
