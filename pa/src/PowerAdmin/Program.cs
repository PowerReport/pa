using PowerAdmin.Admin.Extensions;
using PowerAdmin.EntityFramework.Configuration.Extensions;
using PowerAdmin.EntityFramework.Identity.Extensions;
using PowerAdmin.EntityFramework.Shared.DbContexts;
using Serilog;
using Serilog.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 添加配置文件
builder.Configuration.AddJsonFile("identity_data.json");

// 配置 Furion
builder.Inject();
// 配置 Serilog
builder.WebHost.UseSerilogDefault(options =>
{
#if DEBUG
    options.MinimumLevel.Debug()
#else
    options.MinimumLevel.Information()
#endif
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
        .WriteTo.Console()
        .WriteTo.File("logs/application.log", LogEventLevel.Information, rollingInterval: RollingInterval.Day, retainedFileCountLimit: null, encoding: Encoding.UTF8);
});

// Add services to the container.

// 注册数据库上下文
builder.Services.AddDbContexts<UserIdentityDbContext>();

// 添加用户身份的仓储相关服务
builder.Services.AddIdentityRepository<UserIdentityDbContext>();

// 注册用户身份服务
builder.Services.AddIdentityApplicationServices();

builder.Services.AddControllers();

// 注册 Furion 服务
builder.Services.AddInject(options =>
{
    options.SpecificationDocumentConfigure = config =>
    {
        config.SwaggerGenConfigure = swaggerConfig =>
        {
            // 由于 Usecases 使用了嵌套类，会导致 Swagger 的重名报错，如果是嵌套类则加上嵌套类的名称
            swaggerConfig.CustomSchemaIds(selector => selector.DeclaringType?.Name + selector.Name);
        };
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

// 使用数据库迁移
app.EnsureDatabasesMigrated<UserIdentityDbContext>();
// 使用初始化管理员账号
await app.EnsureSeedIdentityData();

// 使用静态文件，默认路径是 wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseBlazorFrameworkFiles();

app.UseAuthorization();

// 使用 Furion 中间件
app.UseInject("api");

app.MapControllers();

await app.RunAsync();
