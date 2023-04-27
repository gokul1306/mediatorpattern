using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Mediator_pattern.Repo;
using Microsoft.IdentityModel.Tokens;

namespace Mediator_pattern.TokenService
{
    public class TokenServices 
    {
        private readonly UserDal userdal;
        private IConfiguration _configuration;
        public TokenServices(UserDal _userdal,IConfiguration configuration)
        {
           userdal = _userdal;
           _configuration=configuration;
        }
        public object AuthToken(string Email,string Password)
        {
            var user = userdal.CheckUser(Email,Password);
               var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Email",user.Email),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("UserName", user.FirstName!.ToString()),
                       
                    };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var encryptingCredentials = new EncryptingCredentials(key, JwtConstants.DirectKeyUseAlg, SecurityAlgorithms.Aes256CbcHmacSha512);
                var token = new JwtSecurityTokenHandler().CreateJwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    new ClaimsIdentity(claims),
                    null,
                    expires: DateTime.UtcNow.AddHours(6),
                    null,
                    signingCredentials: signIn,
                    encryptingCredentials: encryptingCredentials
                    );
                var Result = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpiryInMinutes = 360,
                    
                    // IsAdmin = user.RoleId == 10 ? true : false,
                    // IsTAC = user.RoleId == 9 ? true : false,
                    // IsManagement=user.Role!.IsManagement? true : false,
                    UserName=user.FirstName,
                    UserId=user.Id
                };
                return Result;

        }
    }
}