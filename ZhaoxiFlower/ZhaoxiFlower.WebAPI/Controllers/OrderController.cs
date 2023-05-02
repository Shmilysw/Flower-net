using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Service;

namespace ZhaoxiFlower.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class OrderController : ControllerBase
    {
        // 内置IOC的使用
        /// <summary>
        ///（控制反转（Inversion of Control）一种面向对象编程中的一种设计原则）
        /// 可以用来减低计算机代码之间的耦合度。其中最常见的方式叫做依赖注入（Dependency Injection，简称DI），
        /// 还有一种方式叫“依赖查找”（Dependency Lookup）。通过控制反转，对象在被创建的时候，由一个调控系统内所有对象的外界实体将其所依赖的对象的引用传递给它。
        /// 也可以说，依赖被注入到对象中
        /// </summary>
        private readonly ILogger<OrderController> _logger;
        private IOrderService _orderService;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            //_logger = logger;
        }
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize] // 这个就是授权标记，如果授权不通过，就不提供服务，就会报401（未授权）（简单来说就是调用这个接口的时候，必须授权）
        public ApiResult CreateOrder(OrderReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (req.FlowerId == 0)
            {
                apiResult.Msg = "参数不可以为空！";
            }
            else
            {
                string msg = string.Empty;
                long userId = Convert.ToInt32(HttpContext.User.Claims.ToList()[0].Value);
                bool res = _orderService.CreateOrder(req,userId, ref msg); // 
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
        [Authorize]
        public ApiResult GetOrder()
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = true };
            try
            {
                long userId = Convert.ToInt32(HttpContext.User.Claims.ToList()[0].Value);
                apiResult.Result = _orderService.GetOrder(userId);
                //_logger.LogInformation("this is GetOrder。。。");
            }
            catch (Exception ex)
            {
                apiResult.IsSuccess = false;
                apiResult.Msg = ex.Message;
            }
            return apiResult;
        }
    }
}
