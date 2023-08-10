using InfluencerAPI.Models.UsersDTO;
using InfuencerAPI.Data;
using InfuencerAPI.Models.Master;
using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.Users;
using InfuencerAPI.Models.UsersDTO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace InfuencerAPI.Services
{
    public class LoginService: ILoginService
    {
        private readonly InfluencerDbContext dbContext;

        public LoginService(InfluencerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MainResponse> GetAll()
        {
            var response = new MainResponse();
            try
            {
                response.Content = await dbContext.UsersLogin.ToListAsync();
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
                    await dbContext.UsersLogin.Where(b => b.Id == id).FirstOrDefaultAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        //public async Task<AccountViewResponse> GetById(Guid id)
        //{
        //    var response = new AccountViewResponse();
        //    try
        //    {
        //        //var _AuthenticateUserResponse = dbContext.UsersLogin
        //        //    .Where(b =>
        //        //        b.UserName == _AuthenticateUserRequest.Email
        //        //        && b.Password == _AuthenticateUserRequest.Password)
        //        //    .Select(v => new AuthenticateUserResponse()
        //        //    { Id = v.UserId, UserName = v.UserName, Password = v.Password })
        //        //    .ToList();
        //        var _login = new AccountViewResponse();

        //        _login = await (
        //            from b in dbContext.UsersLogin
        //                //.Where(b =>
        //                //    b.UserName == _AuthenticateUserRequest.Email
        //                //    && b.Password == _AuthenticateUserRequest.Password)
        //            join v in dbContext.Users on b.UserId equals v.Id
        //            select new
        //            {
        //                b.Id,
        //                b.UserId,
        //                b.UserName,
        //                b.Password,
        //                b.EmailVerified,
        //                b.PasswordVerified,
        //                b.IsActive,
        //                b.RefreshToken,
        //                v.TypeId,
        //                v.FirstName,
        //                v.LastName,
        //                v.Name,
        //                v.Number,
        //                v.ImagePath,
        //                v.IndustryId,
        //                v.Size
        //            })
        //            .Select(v => new AccountViewResponse()
        //            {
        //                Id = v.Id,
        //                UserId = v.UserId,
        //                UserName = v.UserName,
        //                Password = v.Password,
        //                EmailVerified = v.EmailVerified,
        //                PasswordVerified = v.PasswordVerified,
        //                IsActive = v.IsActive,
        //                RefreshToken = v.RefreshToken,
        //                TypeId = v.TypeId,
        //                FirstName = v.FirstName,
        //                LastName = v.LastName,
        //                Name = v.Name,
        //                Number = v.Number,
        //                ImagePath = v.ImagePath,
        //                IndustryId = v.IndustryId,
        //                Size = v.Size

        //            })
        //            .Where(b =>
        //                b.Id == id)
        //            .FirstOrDefaultAsync();
        //        //response.Content = dbContext.Users.Where(b =>
        //        //   b.Email == _AuthenticateUserRequest.Email).FirstOrDefaultAsync();
        //        if (_login == null)
        //        {
        //            response.ErrorMessage = "Record not found.";
        //            response.IsSuccess = false;
        //        }
        //        else
        //        {
        //            response.UserId = _login.UserId;
        //            response.UserName = _login.UserName;
        //            response.Password = _login.Password;
        //            response.EmailVerified = _login.EmailVerified;
        //            response.PasswordVerified = _login.PasswordVerified;
        //            response.IsActive = _login.IsActive;
        //            response.RefreshToken = "";
        //            //response.RefreshToken = _login.RefreshToken;
        //            response.TypeId = _login.TypeId;
        //            response.FirstName = _login.FirstName;
        //            response.LastName = _login.LastName;
        //            response.Name = _login.Name;
        //            response.Number = _login.Number;
        //            response.ImagePath = _login.ImagePath;
        //            response.IndustryId = _login.IndustryId;
        //            response.Size = _login.Size;
        //            //response.Content = await dbContext.UsersLogin
        //            //    .Where(b =>
        //            //        b.UserName == _AuthenticateUserRequest.Email
        //            //        && b.Password == _AuthenticateUserRequest.Password).ToListAsync();
        //            response.Content = "Record is authorized.";
        //            //response.Content = "Record successfully authorized.";
        //            //response.Content = "Welcome!";
        //            //await dbContext.Users
        //            //.Where(b => b.Id == _AuthenticateUserResponse.)
        //            //.Select(v => { v. })
        //            //.FirstOrDefaultAsync();
        //            response.IsSuccess = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = ex.Message;
        //        response.IsSuccess = false;
        //    }
        //    return response;
        //}

        public async Task<LoginViewResponse> AuthenticateUser(AuthenticateUserRequest _AuthenticateUserRequest)
        {
            var response = new LoginViewResponse();
            try
            {
                //var _AuthenticateUserResponse = dbContext.UsersLogin
                //    .Where(b =>
                //        b.UserName == _AuthenticateUserRequest.Email
                //        && b.Password == _AuthenticateUserRequest.Password)
                //    .Select(v => new AuthenticateUserResponse()
                //    { Id = v.UserId, UserName = v.UserName, Password = v.Password })
                //    .ToList();
                var _login = new LoginViewResponse();

                _login = await (
                    from b in dbContext.UsersLogin
                        //.Where(b =>
                        //    b.UserName == _AuthenticateUserRequest.Email
                        //    && b.Password == _AuthenticateUserRequest.Password)
                    join v in dbContext.Users on b.UserId equals v.Id
                    select new
                    {
                        b.UserId,
                        b.UserName,
                        b.Password,
                        b.EmailVerified,
                        b.PasswordVerified,
                        b.IsActive,
                        b.RefreshToken,
                        v.TypeId,
                        v.FirstName,
                        v.LastName,
                        v.Name,
                        v.Number,
                        v.ImagePath,
                        v.IndustryId,
                        v.Size,
                        b.InfluencerId,
                        b.UserTypeId
                    })
                    .Select(v => new LoginViewResponse()
                    {
                        UserId           = v.UserId,
                        UserName         = v.UserName,
                        Password         = v.Password,
                        EmailVerified    = v.EmailVerified,
                        PasswordVerified = v.PasswordVerified,
                        IsActive         = v.IsActive,
                        RefreshToken     = v.RefreshToken,
                        TypeId           = v.TypeId,
                        FirstName        = v.FirstName,
                        LastName         = v.LastName,
                        Name             = v.Name,
                        Number           = v.Number,
                        ImagePath        = "",
                        IndustryId       = v.IndustryId,
                        Size             = v.Size,
                        InfluencerId     = v.InfluencerId,
                        UserTypeId       = v.UserTypeId

                    })
                    .Where(b =>
                        b.UserName == _AuthenticateUserRequest.Email
                        && b.Password == _AuthenticateUserRequest.Password)
                    .FirstOrDefaultAsync();
                //response.Content = dbContext.Users.Where(b =>
                //   b.Email == _AuthenticateUserRequest.Email).FirstOrDefaultAsync();
                bool flag = false;

                if (_login == null)
                {
                    _login = await (
                        from b in dbContext.UsersLogin
                            //.Where(b =>
                            //    b.UserName == _AuthenticateUserRequest.Email
                            //    && b.Password == _AuthenticateUserRequest.Password)
                        join v in dbContext.Influencer on b.InfluencerId equals v.Id
                        select new
                        {
                            b.UserId,
                            b.UserName,
                            b.Password,
                            b.EmailVerified,
                            b.PasswordVerified,
                            b.IsActive,
                            b.RefreshToken,
                            v.Name,
                            v.ImagePath,
                            v.IndustryId,
                            b.InfluencerId,
                            b.UserTypeId
                        })
                        .Select(v => new LoginViewResponse()
                        {
                            UserId = v.UserId,
                            UserName = v.UserName,
                            Password = v.Password,
                            EmailVerified = v.EmailVerified,
                            PasswordVerified = v.PasswordVerified,
                            IsActive = v.IsActive,
                            RefreshToken = v.RefreshToken,
                            TypeId = v.InfluencerId,
                            FirstName = v.Name,
                            LastName = v.Name,
                            Name = v.Name,
                            Number = "0",
                            ImagePath = "",
                            IndustryId = v.IndustryId,
                            Size = 1,
                            InfluencerId = v.InfluencerId,
                            UserTypeId = v.UserTypeId

                        })
                        .Where(b =>
                            b.UserName == _AuthenticateUserRequest.Email
                            && b.Password == _AuthenticateUserRequest.Password)
                        .FirstOrDefaultAsync();

                    await Task.Delay(100);
                    if(_login == null)
                    {
                        response.ErrorMessage = "Record not found.";
                        response.IsSuccess = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = true;
                }
                if (flag == true)
                {
                    response.UserId = _login.UserId;
                    response.UserName = _login.UserName;
                    response.Password = _login.Password;
                    response.EmailVerified = _login.EmailVerified;
                    response.PasswordVerified = _login.PasswordVerified;
                    response.IsActive = _login.IsActive;
                    response.RefreshToken = "";
                    //response.RefreshToken = _login.RefreshToken;
                    response.TypeId = _login.TypeId;
                    response.FirstName = _login.FirstName;
                    response.LastName = _login.LastName;
                    response.Name = _login.Name;
                    response.Number = _login.Number;
                    response.ImagePath = _login.ImagePath;
                    response.IndustryId = _login.IndustryId;
                    response.Size = _login.Size;
                    response.InfluencerId = _login.InfluencerId;
                    response.UserTypeId = _login.UserTypeId;
                    //response.Content = await dbContext.UsersLogin
                    //    .Where(b =>
                    //        b.UserName == _AuthenticateUserRequest.Email
                    //        && b.Password == _AuthenticateUserRequest.Password).ToListAsync();
                    response.Content = "Record is authorized.";
                    //response.Content = "Record successfully authorized.";
                    //response.Content = "Welcome!";
                    //await dbContext.Users
                    //.Where(b => b.Id == _AuthenticateUserResponse.)
                    //.Select(v => { v. })
                    //.FirstOrDefaultAsync();
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> Create(CreateLoginRequest createLoginRequest)
        {
            var response = new MainResponse();
            try
            {
                if (dbContext.UsersLogin.Any(b =>
                    b.UserName == createLoginRequest.UserName
                    && b.Password == createLoginRequest.Password
                ))
                {
                    response.ErrorMessage = "Record already exists.";
                    response.IsSuccess = false;
                }
                else
                {
                    await dbContext.AddAsync(new Login
                    {
                        UserName = createLoginRequest.UserName,
                        Password = createLoginRequest.Password,
                        UserId = createLoginRequest.UserId
                    });
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

            return response;
        }
        public async Task<MainResponse> Update(UpdateLoginRequest updateLoginRequest)
        {
            var response = new MainResponse();
            try
            {
                var Login = dbContext.UsersLogin.Where(b => b.Id == updateLoginRequest.Id).FirstOrDefault();

                if (Login != null)
                {
                    Login.UserName = updateLoginRequest.UserName;
                    Login.Password = updateLoginRequest.Password;
                    Login.UserId = updateLoginRequest.UserId;
                    Login.IsActive = updateLoginRequest.IsActive;
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

            return response;
        }
        public async Task<MainResponse> UpdateRefreshToken(string email, string refreshToken)
        {
            var response = new MainResponse();
            try
            {
                var Login = dbContext.UsersLogin.Where(b => b.UserName == email).FirstOrDefault();

                if (Login != null)
                {
                    Login.RefreshToken = refreshToken;
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

            return response;
        }
        public async Task<MainResponse> UpdateLogin(Guid id, string email, string password)
        {
            var response = new MainResponse();
            try
            {
                var Login = dbContext.UsersLogin.Where(b => b.UserId == id).FirstOrDefault();

                if (Login != null)
                {
                    Login.UserName = email;
                    Login.Password = password;
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

            return response;
        }
        public async Task<MainResponse> Delete(DeleteLoginRequest deleteLoginRequest)
        {
            var response = new MainResponse();
            try
            {
                var Login = dbContext.UsersLogin.Where(b => b.Id == deleteLoginRequest.Id).FirstOrDefault();

                if (Login != null)
                {
                    dbContext.Remove(Login);
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
