// AppSettingsRepository.cs
using Microsoft.EntityFrameworkCore;
using RubberCity.Data;
using System.Threading.Tasks;

public class AppSettingsRepository : IAppSettingsRepository
{
    private readonly RubberCityContext _context;

    public AppSettingsRepository(RubberCityContext context)
    {
        _context = context;
    }

    public async Task<string> GetAppSettingsJsonAsync()
    {
        var appSettings = await _context.AppSettings.FirstOrDefaultAsync();
        return appSettings?.Json;
    }
}
