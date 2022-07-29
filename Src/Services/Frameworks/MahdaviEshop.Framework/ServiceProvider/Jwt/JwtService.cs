using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MahdaviEshop.Framework.Dtos.Settings;
using MahdaviEshop.Framework.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MahdaviEshop.Framework.ServiceProvider.Jwt
{
    public class JwtService: IJwtService
    {
        private readonly SiteSettings _siteSettings;
        public JwtService(IOptionsSnapshot<SiteSettings> siteSettings)
        {
            _siteSettings = siteSettings.Value;
        }

        public string Generate(User user)
        {           
            var roles = _getRoles(user.UserId);
            var claims = _getClaims();
            IEnumerable<string> _getRoles(long userId)
            {
                List<string> roles = new List<string>();
                roles.Add("Admin");
                roles.Add("Writer");
                return roles;
            }
            IEnumerable<Claim> _getClaims()
            {
                List<Claim> claimsData = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.MobilePhone,user.Mobile),
                    new Claim("Address",user.Address)   
                };

                foreach (var role in roles)
                {
                    claimsData.Add(new Claim(ClaimTypes.Role,role));
                }

                return claimsData;
            }

            byte[] key =Encoding.UTF8.GetBytes(_siteSettings.SecurityKey); //longer than 16 char
            var signingCredential = new SigningCredentials(key:new SymmetricSecurityKey(key),algorithm:SecurityAlgorithms.HmacSha512Signature);
            var descriptor = new SecurityTokenDescriptor()
            {
                Issuer=_siteSettings.Issuer,
                Audience= _siteSettings.Audience,
                IssuedAt=DateTime.Now.AddMinutes(_siteSettings.IssuedAt),
                NotBefore=DateTime.Now.AddMinutes(_siteSettings.NotBefore),
                Expires=DateTime.Now.AddMinutes(_siteSettings.Expires),
                SigningCredentials=signingCredential,
                Subject=new ClaimsIdentity(claims)
            };

          var tokenHandler= new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);
            var jwt = tokenHandler.WriteToken(securityToken);
            return jwt;          

        }
    }
}

