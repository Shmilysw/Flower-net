using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Service.User.Dto;
using ZhaoxiFlower.Service;
using ZhaoxiFlower.Common;
using ZhaoxiFlower.Model.Entitys;

namespace ZhaoxiFlower.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUserService _userService;
        public ICustomJWTService _customJWTService;
        public LoginController(IUserService userService, ICustomJWTService customJWTService) // 任何使用构造函数注入的时候，都需要全局文件（Program）里面注册一下
        {
            _userService = userService;
            _customJWTService = customJWTService;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetValidateCodeImages(string t)
        {
            var validateCodeString = Tools.CreateValidateString();
            //将验证码记入缓存中
            MemoryHelper.SetMemory(t, validateCodeString, 5); // 有效期 5 分钟
            //接收图片返回的二进制流
            byte[] buffer = Tools.CreateValidateCodeBuffer(validateCodeString);
            return File(buffer, @"image/jpeg");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Check(UserReq req)
        {
            var currCode = MemoryHelper.GetMemory(req.ValidateKey); // 获取缓存里的验证码，在 MemoryHelper 里
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.ValidateKey) || string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "参数不能为空！";
            }
            else if (currCode == null)
            {
                apiResult.Msg = "验证码不存在，请刷新验证码！";
            }
            else if (currCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "验证码错误，请重新输入或刷新重试！";
            }
            else
            {
                UserRes user = _userService.GetUsers(req);
                if (string.IsNullOrEmpty(user.UserName))
                {
                    apiResult.Msg = "账号不存在，用户名或密码错误！";
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = _customJWTService.GetToken(user); // 传递taken
                }
            }
            return apiResult;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Register(RegisterReq req)
        {
            var currCode = MemoryHelper.GetMemory(req.ValidateKey); // 获取缓存里的验证码，在 MemoryHelper 里
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (string.IsNullOrEmpty(req.UserName) || string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.NickName) || string.IsNullOrEmpty(req.ValidateKey) || string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "参数不能为空！";
            }
            else if (currCode == null)
            {
                apiResult.Msg = "验证码不存在，请刷新验证码！";
            }
            else if (currCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "验证码错误，请重新输入或刷新重试！";
            }
            else
            {
                string msg = string.Empty;
                // req 就是用户名，密码，昵称 这三个参数
                var res = _userService.RegisterUser(req, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = _customJWTService.GetToken(res); // 传递taken
                }
            }
            return apiResult;
        }
    }
}
