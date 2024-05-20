using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RubberCity.Data.Interfaces;
using RubberCity.Data.Repositories;
using RubberCity.Services.Services;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("RubberCityMaster");

builder.Services.AddDbContext<RubberCityContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAppSettingsRepository, AppSettingsRepository>();
builder.Services.AddScoped<IAppSettingsService, AppSettingsService>();

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var appSettingsService = scope.ServiceProvider.GetRequiredService<IAppSettingsService>();
    await appSettingsService.LoadAppSettingsAsync();
    AppServiceStatic.Initialize(appSettingsService.GetSettingsDictionary());
}

var allowOrigins = "_allowOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigins,
                      policyBuilder =>
                      {
                          var corsOrigins = AppServiceStatic.GetSetting("CorsOrigins");
                          if (corsOrigins == "*")
                          {
                              policyBuilder
                                 .AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                          }
                          else
                          {
                              var specificOrigins = corsOrigins?.Split(",");
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddScoped<IEmailRepository<EmailLog>, EmailRepository>(sp =>
    new EmailRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<IEmailTemplateRepository<EmailTemplate>, EmailTemplateRepository>(sp =>
    new EmailTemplateRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<ILocalHelpRepository<LocalHelp>, LocalHelpRepository>(sp =>
    new LocalHelpRepository(sp.GetRequiredService<RubberCityContext>()));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<HelpRequestService>();
builder.Services.AddScoped<UserMessageService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<CaseService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<DonationService>();
builder.Services.AddScoped<PayPalService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<LocalHelpService>();

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
