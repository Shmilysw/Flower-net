using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhaoxiFlower.Model.Entitys
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Users
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string UserName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string NickName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public string Password { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int UserType { get; set; }

    }
}
