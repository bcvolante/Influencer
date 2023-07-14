using InfluencerAPI.Models.MasterDTO;
using InfluencerAPI.Models.UsersDTO;
using InfuencerAPI.Data;
using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.Users;
using InfuencerAPI.Models.UsersDTO;
using InfuencerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InfuencerAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService LoginService;
        private readonly IConfiguration _config;

        public LoginController(ILoginService LoginService, IConfiguration configuration)
        {
            this.LoginService = LoginService;
            _config = configuration;
        }

        private string GenerateToken(LoginViewResponse _LoginViewResponse)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyDetail = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, _LoginViewResponse.UserName),
                    new Claim("pw", _LoginViewResponse.Password),
                    new Claim("ev", _LoginViewResponse.EmailVerified.ToString()),
                    new Claim("ui", _LoginViewResponse.UserId.ToString()),
                    new Claim("pv", _LoginViewResponse.PasswordVerified.ToString()),
                    new Claim("ia", _LoginViewResponse.IsActive.ToString()),
                    new Claim("rt", _LoginViewResponse.RefreshToken),
                    new Claim("ti", _LoginViewResponse.TypeId.ToString()),
                    new Claim("fn", _LoginViewResponse.FirstName),
                    new Claim("ln", _LoginViewResponse.LastName),
                    new Claim("nm", _LoginViewResponse.Name),
                    new Claim("nr", _LoginViewResponse.Number),
                    new Claim("mp", _LoginViewResponse.ImagePath),
                    new Claim("ii", _LoginViewResponse.IndustryId.ToString()),
                    new Claim("sz", _LoginViewResponse.Size.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _config["JWT:Audience"],
                Issuer = _config["JWT:Issuer"],
                Expires = DateTime.UtcNow.AddMinutes(43200),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyDetail), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private string GenerateRefreshToken()
        {

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        //[AllowAnonymous]
        //[HttpPost("RefreshToken")]
        //public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        //{
        //    var response = new MainResponse();
        //    if (refreshTokenRequest is null)
        //    {
        //        response.ErrorMessage = "Invalid request";
        //        return BadRequest(response);
        //    }

        //    var principal = GetPrincipalFromExpiredToken(refreshTokenRequest.AccessToken);

        //    if (principal != null)
        //    {
        //        var email = principal.Claims.FirstOrDefault(f => f.Type == ClaimTypes.Email);

        //        var user = await _userManager.FindByEmailAsync(email?.Value);

        //        if (user is null || user.RefreshToken != refreshTokenRequest.RefreshToken)
        //        {
        //            response.ErrorMessage = "Invalid Request";
        //            return BadRequest(response);
        //        }

        //        string newAccessToken = GenerateToken(user);
        //        string refreshToken = GenerateRefreshToken();

        //        await LoginService.UpdateRefreshToken(_AuthenticateUserRequest.Email, refreshToken);

        //        await _userManager.UpdateAsync(user);

        //        response.IsSuccess = true;
        //        response.Content = new AuthenticationResponse
        //        {
        //            RefreshToken = refreshToken,
        //            AccessToken = newAccessToken
        //        };
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return ErrorResponse.ReturnErrorResponse("Invalid Token Found");
        //    }

        //}
        //private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var keyDetail = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        //    var tokenValidationParameter = new TokenValidationParameters
        //    {
        //        ValidateIssuer = false,
        //        ValidateAudience = false,
        //        ValidateLifetime = false,
        //        ValidateIssuerSigningKey = true,
        //        ValidIssuer = _configuration["JWT:Issuer"],
        //        ValidAudience = _configuration["JWT:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(keyDetail),
        //    };

        //    SecurityToken securityToken;
        //    var principal = tokenHandler.ValidateToken(token, tokenValidationParameter, out securityToken);
        //    var jwtSecurityToken = securityToken as JwtSecurityToken;
        //    if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        //        throw new SecurityTokenException("Invalid token");
        //    return principal;
        //}

        [AllowAnonymous]
        [HttpPost("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserRequest _AuthenticateUserRequest)
        {
            try
            {
                var response = await LoginService.AuthenticateUser(_AuthenticateUserRequest);
                if (response.IsSuccess == true)
                {
                    string accessToken = GenerateToken(response);
                    var refreshToken = GenerateRefreshToken();
                    await LoginService.UpdateRefreshToken(_AuthenticateUserRequest.Email, refreshToken);

                    var returnResponse = new MainResponse
                    {
                        Content = new RefreshTokenRequest
                        {
                            RefreshToken = refreshToken,
                            AccessToken = accessToken
                        },
                        IsSuccess = true,
                        ErrorMessage = "Record successfully authorized."
                    };

                    return Ok(returnResponse);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }


        // GET ALL RECORDS
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await LoginService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET RECORD BY ID
        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var response = await LoginService.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateLoginRequest createLoginRequest)
        {
            try
            {
                var response = await LoginService.Create(createLoginRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLoginRequest updateLoginRequest)
        {
            try
            {
                var response = await LoginService.Update(updateLoginRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLoginRequest deleteLoginRequest)
        {
            try
            {
                var response = await LoginService.Delete(deleteLoginRequest);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }

        }
    }
}
