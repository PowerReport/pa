var builder = WebApplication.CreateBuilder(args);

// ���� Furion
builder.Inject();

// Add services to the container.

var services = builder.Services;

services.AddControllers();

// ���� Furion ����
services.AddInject();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

// ʹ�� Furion �м��
app.UseInject("api");

app.MapControllers();

app.Run();