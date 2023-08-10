using InfluencerAPI.Models.UsersDTO;
using InfuencerAPI.Data;
using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.Users;
using InfuencerAPI.Models.UsersDTO;
using Microsoft.EntityFrameworkCore;

namespace InfuencerAPI.Services
{
    public class UsersService: IUsersService
    {
        private readonly InfluencerDbContext dbContext;

        public UsersService(InfluencerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MainResponse> GetAll()
        {
            var response = new MainResponse();
            try
            {
                response.Content = await dbContext.Users.ToListAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> GetById(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await dbContext.Users.Where(b => b.Id == id).FirstOrDefaultAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<MainResponse> GetByEmail(string email)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await dbContext.Users.Where(b => b.Email == email).FirstOrDefaultAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> Create(CreateUserRequest createUserRequest)
        {
            var response = new MainResponse();
            try
            {
                if (dbContext.Users.Any(b =>
                   b.Email == createUserRequest.Email
                ))
                {
                    response.ErrorMessage = "Record already exists.";
                    response.IsSuccess = false;
                }
                else
                {
                    var _Users = new Users()
                    {
                        Email = createUserRequest.Email,
                        TypeId = createUserRequest.TypeId,
                        FirstName = createUserRequest.FirstName,
                        LastName = createUserRequest.LastName,
                        Name = createUserRequest.Name,
                        ImagePath = createUserRequest.ImagePath,
                        Number = createUserRequest.Number,
                        IndustryId = createUserRequest.IndustryId,
                        Size = createUserRequest.Size,
                        Address = createUserRequest.Address
                    };

                    await dbContext.Users.AddAsync(_Users);
                    await dbContext.SaveChangesAsync();

                    var _Login = new Login()
                    {
                        UserId = _Users.Id,
                        UserName = _Users.Email,
                        Password = createUserRequest.Password,
                        UserTypeId = new Guid("E49B53A7-374B-4F88-8200-6463AA3A5F1A")
                    };
                    //var _CreateLoginRequest = dbContext.Users
                    //    .Where(b => b.Email == createUserRequest.Email)
                    //    .Select(v => new CreateLoginRequest()
                    //    { UserId = v.Id, UserName = v.Email, Password = createUserRequest.Password  }).ToList();

                    try
                    {
                        if (dbContext.UsersLogin.Any(b =>
                            b.UserName == _Users.Email
                            && b.Password == createUserRequest.Password
                        ))
                        {
                            response.ErrorMessage = "Record already exists.";
                            response.IsSuccess = false;
                        }
                        else
                        {
                            await dbContext.UsersLogin.AddAsync(_Login);
                            await dbContext.SaveChangesAsync();

                            response.IsSuccess = true;
                            response.Content = "Record successfully added.";
                        }
                    }
                    catch (Exception ex)
                    {
                        response.ErrorMessage = ex.Message;
                        response.IsSuccess = false;
                    }

                    response.IsSuccess = true;
                    response.Content = "Record successfully created.";
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<MainResponse> Update(UpdateUserRequest updateUserRequest)
        {
            var response = new MainResponse();
            try
            {
                var User = dbContext.Users.Where(b =>
                    b.Id == updateUserRequest.Id ||
                    (b.Id != updateUserRequest.Id && b.Email == updateUserRequest.Email)).FirstOrDefault();

                if (User != null)
                {
                    User.Email = updateUserRequest.Email;
                    User.TypeId = updateUserRequest.TypeId;
                    User.FirstName = updateUserRequest.FirstName;
                    User.LastName = updateUserRequest.LastName;
                    User.Name = updateUserRequest.Name;
                    User.ImagePath = updateUserRequest.ImagePath;
                    User.Number = updateUserRequest.Number;
                    User.IndustryId = updateUserRequest.IndustryId;
                    User.Size = updateUserRequest.Size;
                    User.Address = updateUserRequest.Address;
                    await dbContext.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Record successfully updated.";

                    try
                    {
                        var Login = dbContext.UsersLogin.Where(b => b.UserId == updateUserRequest.Id).FirstOrDefault();

                        if (Login != null)
                        {
                            Login.UserName = updateUserRequest.Email;
                            Login.Password = updateUserRequest.Password;
                            await dbContext.SaveChangesAsync();

                            response.IsSuccess = true;
                            response.Content = "Record successfully updated.";
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Content = "Record not found.";
                        }

                    }
                    catch (Exception ex)
                    {
                        response.ErrorMessage = ex.Message;
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Content = "Record update failed.";
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<MainResponse> Delete(DeleteUserRequest deleteUserRequest)
        {
            var response = new MainResponse();
            try
            {
                var User = dbContext.Users.Where(b => b.Id == deleteUserRequest.Id).FirstOrDefault();

                if (User != null)
                {
                    dbContext.Remove(User);
                    await dbContext.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Record successfully deleted.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Content = "Record not found.";
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
