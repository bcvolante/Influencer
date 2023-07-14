using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.UsersDTO;

namespace InfuencerAPI.Services
{
    public interface IUsersService
    {
        Task<MainResponse> GetAll();
        Task<MainResponse> GetById(Guid id);
        Task<MainResponse> GetByEmail(string email);
        Task<MainResponse> Create(CreateUserRequest createUserRequest);
        Task<MainResponse> Update(UpdateUserRequest updateUserRequest);
        Task<MainResponse> Delete(DeleteUserRequest deleteUserRequest);
    }
}
