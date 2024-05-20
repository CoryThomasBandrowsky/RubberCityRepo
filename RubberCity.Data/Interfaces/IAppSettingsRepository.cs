// IAppSettingsRepository.cs
using System.Threading.Tasks;

public interface IAppSettingsRepository
{
    Task<string> GetAppSettingsJsonAsync();
}
