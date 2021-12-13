using PowerAdmin.Business.Identity.Extensions;
using PowerAdmin.EntityFramework.Configuration.Extensions;
using PowerAdmin.EntityFramework.Shared.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// ���� Furion
builder.Inject();

// Add services to the container.

// ������ݿ�������
builder.Services.AddDbContexts<UserIdentityDbContext>();

// ����û���ݷ���
builder.Services.AddIdentityServices<UserIdentityDbContext>();

builder.Services.AddControllers();

// ��� Furion ����
builder.Services.AddInject();

var app = builder.Build();

// Configure the HTTP request pipeline.

// ���ݿ�Ǩ��
app.EnsureDatabasesMigrated<UserIdentityDbContext>();

app.UseAuthorization();

// ʹ�� Furion �м��
app.UseInject("api");

app.MapControllers();

app.Run();
