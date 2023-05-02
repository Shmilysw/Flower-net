using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhaoxiFlower.Service.User.Dto
{
    public class UserReq
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码key
        /// </summary>
        public string ValidateKey { get; set; }
        /// <summary>
        /// 验证码code
        /// </summary>
        public string ValidateCode { get; set; }
    }
}
