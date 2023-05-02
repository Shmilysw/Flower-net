using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Common;

namespace ZhaoxiFlower.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        [HttpGet]
        public void InitDatabase()
        {
            DbContext.InitDataBase();
        }
    }
}
