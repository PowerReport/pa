using PowerAdmin.EntityFramework.Configuration.Extensions;
using PowerAdmin.EntityFramework.Identity.DbContext;

var builder = WebApplication.CreateBuilder(args);

// ���� Furion
builder.Inject();

// Add services to the container.

var services = builder.Services;

// ������ݿ�������
services.AddDbContexts<UserIdentityDbContext>();

services.AddControllers();

// ��� Furion ����
services.AddInject();

var app = builder.Build();

// Configure the HTTP request pipeline.

// ���ݿ�Ǩ��
app.EnsureDatabasesMigrated<UserIdentityDbContext>();

app.UseAuthorization();

// ʹ�� Furion �м��
app.UseInject("api");

app.MapControllers();

app.Run();
