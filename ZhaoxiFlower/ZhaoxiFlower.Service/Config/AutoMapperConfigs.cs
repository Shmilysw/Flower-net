using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhaoxiFlower.Model.Entitys;
using ZhaoxiFlower.Service.User.Dto;

namespace ZhaoxiFlower.Service.Config
{
    public class AutoMapperConfigs: Profile
    {
        /// <summary>
        /// 在构造函数中配置映射关系
        /// </summary>
        public AutoMapperConfigs()
        {
            //从 A => B , 从 A 映射到 B
            CreateMap<Flower, FlowerRes>();
            CreateMap<Users, UserRes>();
            CreateMap<RegisterReq, Users>();
            CreateMap<Shop, ShopRes>();
        }
    }
}
