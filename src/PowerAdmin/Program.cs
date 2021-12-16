using PowerAdmin.Business.Identity.Extensions;
using PowerAdmin.EntityFramework.Configuration.Extensions;
using PowerAdmin.EntityFramework.Shared.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// 配置 Furion
builder.Inject();

// Add services to the container.

// 添加数据库上下文
builder.Services.AddDbContexts<UserIdentityDbContext>();

// 添加用户身份服务
builder.Services.AddIdentityServices<UserIdentityDbContext>();

builder.Services.AddControllers();

// 添加 Furion 服务
builder.Services.AddInject();

var app = builder.Build();

// Configure the HTTP request pipeline.

// 数据库迁移
app.EnsureDatabasesMigrated<UserIdentityDbContext>();

// 使用静态文件，默认路径是 wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseBlazorFrameworkFiles();

app.UseAuthorization();

// 使用 Furion 中间件
app.UseInject("api");

app.MapControllers();

await app.RunAsync();
