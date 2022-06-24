using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService
    {
        public string CreateToken(User user){
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            //Signing key for JWTs
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret key token"));
            //Credentials to sign the token
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha512);

            //This describes the type of token we area creating
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };

            //Creating a token with a token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            //Creates the actual token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //Serializes the token on returning
            return tokenHandler.WriteToken(token);
        }
    }
}