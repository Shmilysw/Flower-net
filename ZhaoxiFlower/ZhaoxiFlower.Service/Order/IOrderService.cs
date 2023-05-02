using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhaoxiFlower.Service
{
    public interface IOrderService
    {
        // 创建订单
        bool CreateOrder(OrderReq req, long userId, ref string msg);
        // 获取订单
        List<OrderRes> GetOrder(long userId);
    }
}
