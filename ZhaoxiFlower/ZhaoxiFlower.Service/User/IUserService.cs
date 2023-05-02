using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhaoxiFlower.Model.Entitys;
using ZhaoxiFlower.Service.User.Dto;

namespace ZhaoxiFlower.Service
{
    public interface IUserService
    {
        UserRes GetUsers(UserReq req); // 登录
        UserRes RegisterUser(RegisterReq req, ref string msg); // 注册
    }
}
