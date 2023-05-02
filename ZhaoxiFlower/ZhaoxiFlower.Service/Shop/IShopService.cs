using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhaoxiFlower.Service
{
    public interface IShopService
    {
        List<ShopRes> GetShop(ShopReq req);

        bool CreateShop(ShopReq req, ref string msg);

        bool DeleteShop(ShopReq req);
    }
}
