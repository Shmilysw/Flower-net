using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Service;

namespace ZhaoxiFlower.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        public IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpPost]
        public ApiResult GetShop(ShopReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = true };
            apiResult.Result = _shopService.GetShop(req);
            return apiResult;
        }

        [HttpPost]
        //[Authorize] // 这个就是授权标记，如果授权不通过，就不提供服务，就会报401（未授权）（简单来说就是调用这个接口的时候，必须授权）
        public ApiResult CreateShop(ShopReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (req.Id == 0)
            {
                apiResult.Msg = "参数不可以为空！";
            }
            else
            {
                string msg = string.Empty;
                bool res = _shopService.CreateShop(req, ref msg); // 
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = res;
                }
            }
            return apiResult;
        }

        [HttpPost]
        public ApiResult DeleteShop(ShopReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (req.Id == 0)
            {
                apiResult.Msg = "参数不可以为空！";
            }
            else
            {
                string msg = string.Empty;
                bool res = _shopService.DeleteShop(req); // 
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = res;
                }
            }
            return apiResult;
        }

    }
}
