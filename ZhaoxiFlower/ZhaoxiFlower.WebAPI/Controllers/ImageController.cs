using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZhaoxiFlower.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        //获取图片列表的方法
        [HttpGet]
        public List<ImageModel> GetImages()
        {
            List<ImageModel> list = new List<ImageModel>()
            {
                new ImageModel(){ ImageUrl="https://img02.hua.com/slider/22_xmas_banner_pc.jpg",CourseUrl="http://localhost:8080/" },
                new ImageModel(){ ImageUrl="https://img02.hua.com/slider/21_brand_banner_pc.jpg",CourseUrl="http://localhost:8080/" },
                new ImageModel(){ ImageUrl="https://img02.hua.com/slider/22_birthday_pc.jpg",CourseUrl="http://localhost:8080/birthdayflower" },
                new ImageModel(){ ImageUrl="https://img02.hua.com/slider/20_sheshou_banner_pc.jpg",CourseUrl="http://localhost:8080/loveflower" },
                new ImageModel(){ ImageUrl="https://img02.hua.com/zhuanti/birthday/pc/banner_lover.png",CourseUrl="http://localhost:8080/birthdayflower" },
                new ImageModel(){ ImageUrl="https://img02.hua.com/zhuanti/birthday/pc/banner_male.png",CourseUrl="http://localhost:8080/birthdayflower" },
            };
            return list;
        }
    }
}
