using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhaoxiFlower.Service
{
    public class OrderReq
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int FlowerId { get; set; }
        /// <summary>
        /// 配送地址
        /// </summary>
        public string OrderPlace { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string OrderUserName { get; set; }
        /// <summary>
        /// 收货人手机号码
        /// </summary>
        public string OrderUserNumber { get; set; }
    }
}
