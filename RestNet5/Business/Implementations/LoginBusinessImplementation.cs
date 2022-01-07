using RestNet5.Configurations;
using RestNet5.Data.VO;
using RestNet5.Repository;
using RestNet5.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestNet5.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyy-MM-dd HH:mm:ss";

        private TokenConfiguration _config;

        private IUserRepository _userRepository;

        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration config, IUserRepository userRepository, ITokenService tokenService)
        {
            _config = config;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _userRepository.ValidadeCredentials(userCredentials);

            if (user == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);               

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_config.DaysToExpire);
            
            _userRepository.RefreshUserInfo(user);

            DateTime expirationDate = DateTime.Now.AddMinutes(_config.Minutes);

            return new TokenVO(
                true,
                DateTime.Now.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                user.RefreshToken
                );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            
            var principal = _tokenService.GetPrincipalFromExpiredToken(token.AccessToken);

            var user = _userRepository.ValidadeCredentials(principal.Identity.Name);

            if (user == null || 
                user.RefreshToken != token.RefreshToken || 
                user.RefreshTokenExpiryTime <= DateTime.Now
                ) return null;

            user.RefreshToken = _tokenService.GenerateRefreshToken();

            _userRepository.RefreshUserInfo(user);

            DateTime expirationDate = DateTime.Now.AddMinutes(_config.Minutes);

            return new TokenVO(
                true,
                DateTime.Now.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                _tokenService.GenerateAccessToken(principal.Claims),
                user.RefreshToken
                );
        }
    }
}
