using backendpreguntas.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace backendpreguntas.Utils
{
    public class JwtConfigurator
    {
        public static string GetToken(Usuario user,IConfiguration config)
        {
            string secretKey = config["Jwt:SecretKey"];
            string Issuer = config["Jwt:Issuer"];
            string Audience = config["Jwt:Audience"];
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.usuario),
                new Claim("id",user.Id.ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);



        }
        public static int GetTokenIdUsuario(ClaimsIdentity identity)
        {
            if(identity != null)
            {
                IEnumerable<Claim>claims= identity.Claims;
                foreach (var item in claims)
                {
                    if (item.Type=="id")
                    {
                        return int.Parse(item.Value);
                    }

                }
            }
            return 0;
        }
    }
}
