using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhaoxiFlower.Common;
using ZhaoxiFlower.Model.Entitys;

namespace ZhaoxiFlower.Service
{
    public class ShopService : IShopService
    {
        public readonly IMapper _mapper;

        public ShopService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool CreateShop(ShopReq req, ref string msg)
        {
            var flower = DbContext.db.Queryable<Flower>().First(p => p.Id == req.ProductId); // 这里查询flower表 // 下面都是查询shop表
            // 为啥这里只能用first方法，where为啥用不了，有bug，不懂，但是可以实现效果要求。
            var res = DbContext.db.Queryable<Shop>().First(x => x.UserId == req.UserId && x.ProductId == req.ProductId && x.Type == req.Type);
            if (res == null)
            {
                if (flower == null)
                {
                    msg = "商品信息不存在！";
                    return false;
                }
                Shop shop = new Shop()
                {
                    UserId = req.UserId,
                    Title = flower.Title,
                    ProductId = req.Id,
                    Type = req.Type,
                    Image = flower.Image,
                    BigImage = flower.BigImage,
                    Description = flower.Description,
                    Price = flower.Price,
                    Language = flower.Language,
                    Material = flower.Material,
                    Packing = flower.Packing,
                    DeliveryRemarks = flower.DeliveryRemarks,
                };
                return DbContext.db.Insertable(shop).ExecuteCommand() > 0;
            }
            msg = "已经添加到收藏了！";
            return false;
        }

        public bool DeleteShop(ShopReq req)
        {
            var flower = DbContext.db.Queryable<Shop>().First(p => p.Id == req.Id);
            if (flower == null)
            {
                return false;
            }
            return DbContext.db.Deleteable(flower).ExecuteCommand() > 0;
            //return true;
        }

        //AutoMapper的使用

        public List<ShopRes> GetShop(ShopReq req)
        {
            var res = DbContext.db.Queryable<Shop>().WhereIF(req.UserId > 0, x => x.UserId == req.UserId).WhereIF(req.Type > 0, x => x.Type == req.Type).ToList();
            return _mapper.Map<List<ShopRes>>(res);
        }
    }
}
