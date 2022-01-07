using Microsoft.IdentityModel.Tokens;
using RestNet5.Configurations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RestNet5.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private TokenConfiguration _configToken;

        public TokenService(TokenConfiguration configToken)
        {
            _configToken = configToken;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configToken.Secret));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configToken.Issuer,
                audience: _configToken.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_configToken.Minutes),
                signingCredentials: signInCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParam = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configToken.Secret)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;

            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParam, out securityToken);

            var jwtToken = securityToken as JwtSecurityToken;

            if (jwtToken == null ||
                !jwtToken.Header.Alg.Equals(
                    SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCulture)) throw new SecurityTokenException("Invalid Token");
            

            return principal;
        }
    }
}
