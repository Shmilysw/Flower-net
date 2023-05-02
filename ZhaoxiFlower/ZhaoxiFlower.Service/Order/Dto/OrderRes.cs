using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhaoxiFlower.Service
{
    public class OrderRes
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 鲜花标题
        /// </summary>
        public string FlowerTitle { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 配送地址
        /// </summary>
        public string OrderPlace { get; set; }
        /// <summary>
        /// 订单人姓名
        /// </summary>
        public string OrderUserName { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string OrderUserNumber { get; set; }
    }
}
