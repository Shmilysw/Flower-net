using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhaoxiFlower.Service.User.Dto
{
    public  class UserRes
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary> 
        public string UserName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary> 
        public string NickName { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }
    }
}
