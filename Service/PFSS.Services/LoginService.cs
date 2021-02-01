using PrivateFileStorageService;
using PFSS.Models;
using PFSS.Helpers;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PFSS.Models.Auth;

namespace PFSS.Services
{

    public class LoginService : BaseService<User>
    {
        private readonly JwtSettings _jwtSettings;

        public LoginService(IDatabaseSettings settings,IJwtSettings jwtSettings) : base(settings)
        {
            _jwtSettings = (JwtSettings)jwtSettings;
        }

        public async Task<User> Login(LoginParams loginParams)
        {
            var result = await this.GetByCondition(user=>user.email == loginParams.email && user.password == SecurityHelper.computeHash(loginParams.password));
            if(result==null && result.Count < 1)
            {
                return null;
            }
            var user = result[0];

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)

            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

            var token = new JwtSecurityToken(
                   issuer: _jwtSettings.ValidIssuer,
                   audience: _jwtSettings.ValidAudience,
                   expires: DateTime.Now.AddHours(3),
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                   );
            user.token = new JwtSecurityTokenHandler().WriteToken(token);

            
            return new User()
            {
                name=user.name,
                surname=user.surname,
                email=user.email,
                token=user.token
            };
        }

        public Task SignUp(User user)
        {
            user.password = SecurityHelper.computeHash(user.password);
            return this.Add(user);
        }
    }
}