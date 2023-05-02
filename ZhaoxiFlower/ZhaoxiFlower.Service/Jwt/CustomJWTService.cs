using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Service.User.Dto;

namespace ZhaoxiFlower.Service
{
    public class CustomJWTService: ICustomJWTService
    {
        private readonly JWTTokenOptions _JWTTokenOptions;
        /// <summary>
        ///  
        /// </summary>
        /// <param name="jwtTokenOptions"></param>
        public CustomJWTService(IOptionsMonitor<JWTTokenOptions> jwtTokenOptions) // 构造函数
        {
            _JWTTokenOptions = jwtTokenOptions.CurrentValue;
        }
        /// <summary>
        /// 获取token
        /// token的意思是“令牌”，是服务端生成的（一串字符串），作为客户端进行请求的一个标识。
        /// 当用户第一次登录后，服务器生成一个token并将此token返回给客户端，
        /// 以后客户端只需带上这个token前来请求数据即可，无需再次带上用户名和密码。
        /// taken 的主要作用市身份认证
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetToken(UserRes user) // 获取taken
        {
            // taken里面存下面的四个值
            #region
            var claims = new[]
            {
                new Claim("Id",user.Id.ToString()),
                new Claim("NickName",user.NickName),
                new Claim("UserName",user.UserName),
                new Claim("UserType",user.UserType.ToString()),
            };

            //需要加密：需要加密key:
            //Nuget引入：Microsoft.IdentityModel.Tokens
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTTokenOptions.SecurityKey));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Nuget引入：System.IdentityModel.Tokens.Jwt
            JwtSecurityToken token = new JwtSecurityToken(
             issuer: _JWTTokenOptions.Issuer,
             audience: _JWTTokenOptions.Audience,
             claims: claims,
             expires: DateTime.Now.AddMinutes(10),//5分钟有效期
             signingCredentials: creds);

            string returnToken = new JwtSecurityTokenHandler().WriteToken(token);
            return returnToken;
            #endregion
        }
    }
}
