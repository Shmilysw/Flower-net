using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Service;
using ZhaoxiFlower.Service.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
//设置JSON返回日期格式
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//添加跨域策略
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-Pagination"));
});

//注册AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));

//注册JWT(JSON Web Token)目前最流行的跨域身份验证解决方案
builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));

//注册Service层服务(抽象跟实例之间的关系)
builder.Services.AddTransient<IFlowerService, FlowerService>();
builder.Services.AddTransient<IUserService, UserService>(); // 500错误就是没有注册服务等
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IShopService, ShopService>();
builder.Services.AddTransient<ICustomJWTService, CustomJWTService>();


#region jwt校验 
{
    //第二步，增加鉴权逻辑
    JWTTokenOptions tokenOptions = new JWTTokenOptions();
    builder.Configuration.Bind("JWTTokenOptions", tokenOptions);
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//Scheme
     .AddJwtBearer(options =>  //这里是配置的鉴权的逻辑
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             //JWT有一些默认的属性，就是给鉴权时就可以筛选了
             ValidateIssuer = true,//是否验证Issuer
             ValidateAudience = true,//是否验证Audience
             ValidateLifetime = true,//是否验证失效时间
             ValidateIssuerSigningKey = true,//是否验证SecurityKey
             ValidAudience = tokenOptions.Audience,//
             ValidIssuer = tokenOptions.Issuer,//Issuer，这两项和前面签发jwt的设置一致
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))//拿到SecurityKey 
         };
     });
}
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region 鉴权授权
app.UseAuthentication();
app.UseAuthorization();
#endregion


//使用跨域策略
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
