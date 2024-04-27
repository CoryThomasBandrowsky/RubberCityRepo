using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RubberCity.Data.Interfaces;
using RubberCity.Data.Repositories;
using RubberCity.Services.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var allowOrigins = "_allowOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigins,
                      policyBuilder =>
                      {
                          var corsOrigins = configuration["CorsOrigins"];
                          if (corsOrigins == "*")
                          {
                              policyBuilder
                                 .AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                          }
                          else
                          {
                              var specificOrigins = configuration.GetSection("CorsOrigins").Get<string[]>();
                              if (specificOrigins != null)
                              {
                                  policyBuilder
                                     .WithOrigins(specificOrigins)
                                     .AllowAnyHeader()
                                     .AllowAnyMethod();
                              }
                          }
                      });
});


var connectionString = configuration.GetConnectionString("RubberCityMaster");
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Values"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RubberCityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RubberCityMaster")));

builder.Services.AddScoped<IRepository<User>, UserRepository>(sp =>
    new UserRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<UserService>();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(allowOrigins);
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();
