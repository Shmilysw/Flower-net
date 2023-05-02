using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhaoxiFlower.Common;
using ZhaoxiFlower.Model.Entitys;
using ZhaoxiFlower.Model.Enum;
using ZhaoxiFlower.Service.User.Dto;

namespace ZhaoxiFlower.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper; 
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public UserRes GetUsers(UserReq req)
        {
            // 读取数据库，判断信息
            var user = DbContext.db.Queryable<Users>().First(p => p.UserName == req.UserName && p.Password == req.Password); // where 和 first 一样里面写一个Lambda表达式
            if (user != null)
            {
                return _mapper.Map<UserRes>(user);
            }
            return new UserRes();
        }
        public UserRes RegisterUser(RegisterReq req, ref string msg)
        {
            // 读取数据库，判断信息
            var user = DbContext.db.Queryable<Users>().First(p => p.UserName == req.UserName);
            if (user != null)
            {
                msg = "账号已存在！";
                return _mapper.Map<UserRes>(user);
            }
            else
            {
                try
                {
                    Users users = _mapper.Map<Users>(req);
                    users.CreateTime = DateTime.Now;
                    users.UserType = (int)EnumUserType.普通用户;
                    bool res = DbContext.db.Insertable(users).ExecuteCommand() > 0;
                    if (res)
                    {
                        user = DbContext.db.Queryable<Users>().First(p => p.UserName == req.UserName && p.Password == req.Password);
                        return _mapper.Map<UserRes>(user);
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message; 
                }
            }
            return new UserRes();
        }
    }
}
