using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using FlowerCode.Common;
using FlowerCode.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net(@"Config/log4net.config");
// Add services to the container.
builder.Services.AddDbContext<FlowerDbContext>(x => x.UseSqlServer(builder.Configuration.GetSection("ConnectionString").Value));
// builder.Services.AddDbContextPool<FlowerDbContext>(x=>x.UseSqlServer(builder.Configuration.GetSection("ConnectionString").Value));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(FlowerCode.Service.Config.AutoMapperConfigs));
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
