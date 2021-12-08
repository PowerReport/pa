using PowerAdmin.EntityFramework.Identity.DbContext;
using PowerAdmin.EntityFramework.Postgres.Extensions;

var builder = WebApplication.CreateBuilder(args);

// ���� Furion
builder.Inject();

// Add services to the container.

var services = builder.Services;

// ������ݿ�������
services.AddPostgresDbContext<UserIdentityDbContext>();

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
