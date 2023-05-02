using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhaoxiFlower.Service.User.Dto;

namespace ZhaoxiFlower.Service
{
    public interface ICustomJWTService
    {
        //获取token
        string GetToken(UserRes user);
    }
}
