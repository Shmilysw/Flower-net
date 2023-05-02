using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhaoxiFlower.Model
{
    // 添加这个，方便前台判断
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public string Msg { get; set; }
    }
}
