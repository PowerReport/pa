using PowerAdmin.EntityFramework.Identity.DbContext;
using PowerAdmin.EntityFramework.Postgres.Extensions;

var builder = WebApplication.CreateBuilder(args);

// 配置 Furion
builder.Inject();

// Add services to the container.

var services = builder.Services;

// 添加数据库上下文
services.AddPostgresDbContext<UserIdentityDbContext>();

services.AddControllers();

// 添加 Furion 服务
services.AddInject();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

// 使用 Furion 中间件
app.UseInject("api");

app.MapControllers();

app.Run();
