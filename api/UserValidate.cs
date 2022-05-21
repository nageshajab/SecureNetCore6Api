using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api
{
    public class UserValidate
    {
        public static string GenerateToken(string username)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a secret that needs to be at least 16 characters long"));

            var claims = new Claim[] {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role,"admin"),
            new Claim(JwtRegisteredClaimNames.Email, "john.doe@blinkingcaret.com")
             };

            var token = new JwtSecurityToken(
                issuer: "issuer nagesh",
                audience: "audience",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(28),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }

        public static bool IsValidUserAndPasswordCombination(string username, string password)
        {
            if (username == "nagesh" && password == "password")
            {
                return true;
            }
            return false;
        }
    }
}
