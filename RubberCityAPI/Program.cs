using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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

builder.Services.AddScoped<IUserRepository<User>, UserRepository>(sp =>
    new UserRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<IRepository<HelpRequestModel>, HelpRequestRepository>(sp =>
    new HelpRequestRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<IRepository<UserMessage>, UserMessagesRepository>(sp =>
    new UserMessagesRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<IRepository<Case>, CaseRepository>(sp =>
    new CaseRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<IEventRepository<Event>, EventRepository>(sp =>
    new EventRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<IDonationRepository<Donation>, DonationRepository>(sp =>
    new DonationRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<HelpRequestService>();
builder.Services.AddScoped<UserMessageService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<CaseService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<DonationService>();
builder.Services.AddScoped<PayPalService>();


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